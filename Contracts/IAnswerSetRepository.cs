using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAnswerSetRepository : IRepositoryBase<AnswerSet>
    {
        Task<IEnumerable<AnswerSet>> SearchAnswerSetsAsync(string searchValue);
        Task<AnswerSet> GetAnswerSetByIdAsync(int id);
        Task CreateAnswerSetAsync(AnswerSet answerSet);
    }
}
