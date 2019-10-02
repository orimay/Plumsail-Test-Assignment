using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace SPA.Controllers
{
    [Route("api/answerset")]
    [ApiController]
    public class AnswerSetController : ControllerBase
    {
        private readonly IRepositoryWrapper m_repoWrapper;

        public AnswerSetController(IRepositoryWrapper repoWrapper)
        {
            m_repoWrapper = repoWrapper;
        }

        // GET: api/answerset/list
        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<AnswerSet>>> GetAnswerSetList(string searchValue = null)
        {
            return Ok(
                await m_repoWrapper.AnswerSet.SearchAnswerSetsAsync(searchValue)
            );
        }

        // GET: api/answerset/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerSet>> GetAnswerSet(int id)
        {
            var answerSet = await m_repoWrapper.AnswerSet.GetAnswerSetByIdAsync(id);

            if (answerSet == null)
                return NotFound();

            return Ok(answerSet);
        }

        // POST: api/answerset
        [HttpPost]
        public async Task<ActionResult<AnswerSet>> PostAnswerSet([FromBody] AnswerSet answerSet)
        {
            // At first, it was receiving a dictionary of fieldId/value as it was specified in the task, but later I decided to
            // switch the model over AnswerSet, that is properly mapped to questions. Alos, this helps to support multiple checkboxes per question
            // and values hidden behind dropwowns, radio buttons and checkboxes

            // I would implement answer set mapping to the corresponding question set (if the answers and options of those match), but I will not,
            // since it's already a bit over-engineered for an assignment task

            if (answerSet.Answers.Count < 1)
                return BadRequest();

            await m_repoWrapper.AnswerSet.CreateAnswerSetAsync(answerSet);

            return CreatedAtAction(nameof(GetAnswerSet), new { id = answerSet.AnswerSetId }, answerSet);
        }
    }
}
