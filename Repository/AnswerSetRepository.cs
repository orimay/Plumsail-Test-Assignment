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
    public class AnswerSetRepository : RepositoryBase<AnswerSet>, IAnswerSetRepository
    {
        public AnswerSetRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateAnswerSetAsync(AnswerSet answerSet)
        {
            answerSet.CreatedDate = DateTime.UtcNow;
            Create(answerSet);
            await SaveAsync();
        }

        public async Task<IEnumerable<AnswerSet>> SearchAnswerSetsAsync(string searchValue)
        {
            // Here we search answers by value. We either have the answer text or the option text matching the search term
            // Picked options are stored as ids, so we map those to the question options to pull the option text and search by it

            // We, surely, could search by values on client side, since we load all the answers on view load anyways, but I wanted to show what I am capable of
            return await FindByCondition(x =>
                    string.IsNullOrEmpty(searchValue)
                    || x.Answers.Any(
                        y => y.Value != null && y.Value.Contains(searchValue)
                        || y.Options.Any(z => z.QuestionOption.Text.Contains(searchValue))
                    )
                )
                .Include(x => x.Answers)
                .ThenInclude(x => x.Options)
                .OrderByDescending(x => x.CreatedDate)
                .ToListAsync();
        }

        public async Task<AnswerSet> GetAnswerSetByIdAsync(int id)
        {
            return await FindByCondition(x => x.AnswerSetId == id)
                .Include(x => x.Answers)
                .FirstOrDefaultAsync();
        }
    }
}
