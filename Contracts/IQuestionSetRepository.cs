using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IQuestionSetRepository : IRepositoryBase<QuestionSet>
    {
        Task<IEnumerable<QuestionSet>> GetAllQuestionSetsAsync();
        Task<QuestionSet> GetQuestionSetByIdAsync(int id);
        Task CreateQuestionSetAsync(QuestionSet questionSet);
    }
}
