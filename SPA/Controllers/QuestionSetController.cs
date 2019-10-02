using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace SPA.Controllers
{
    [Route("api/questionset")]
    [ApiController]
    public class QuestionSetController : ControllerBase
    {
        private readonly IRepositoryWrapper m_repoWrapper;

        public QuestionSetController(IRepositoryWrapper repoWrapper)
        {
            m_repoWrapper = repoWrapper;
        }

        // GET: api/questionset/list
        [HttpGet("list")]
        public async Task<ActionResult<List<QuestionSet>>> GetQuestionSetList()
        {
            return Ok(
                await m_repoWrapper.QuestionSet.GetAllQuestionSetsAsync()
            );
        }

        // GET: api/questionset/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionSet>> GetQuestionSet(int id)
        {
            var questionSet = await m_repoWrapper.QuestionSet.GetQuestionSetByIdAsync(id);

            if (questionSet == null)
                return NotFound();

            return Ok(questionSet);
        }

        // POST: api/questionset
        [HttpPost]
        public async Task<ActionResult<QuestionSet>> PostQuestionSet([FromBody] QuestionSet questionSet)
        {
            if (questionSet.Questions.Count < 1)
                return BadRequest();

            await m_repoWrapper.QuestionSet.CreateQuestionSetAsync(questionSet);

            return CreatedAtAction(nameof(GetQuestionSet), new { id = questionSet.QuestionSetId }, questionSet);
        }
    }
}
