using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class QuestionSetRepository : RepositoryBase<QuestionSet>, IQuestionSetRepository
    {
        public QuestionSetRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateQuestionSetAsync(QuestionSet questionSet)
        {
            questionSet.CreatedDate = DateTime.UtcNow;
            Create(questionSet);
            await SaveAsync();
        }

        public async Task<IEnumerable<QuestionSet>> GetAllQuestionSetsAsync()
        {
            return await FindAll()
                .Include(x => x.Questions)
                .ThenInclude(x => x.Options)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
        }

        public async Task<QuestionSet> GetQuestionSetByIdAsync(int id)
        {
            return await FindByCondition(x => x.QuestionSetId == id)
                .Include(x => x.Questions)
                .ThenInclude(x => x.Options)
                .Include(x => x.Questions)
                .ThenInclude(x => x.Validators)
                .ThenInclude(x => x.Arguments)
                .FirstOrDefaultAsync();
        }
    }
}
