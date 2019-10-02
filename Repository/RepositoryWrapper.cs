using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext m_RepositoryContext;
        private IQuestionSetRepository m_QuestionSetRepository;
        private IAnswerSetRepository m_AnswerSetRepository;

        public IQuestionSetRepository QuestionSet
        {
            get
            {
                if (m_QuestionSetRepository == null)
                    m_QuestionSetRepository = new QuestionSetRepository(m_RepositoryContext);
                return m_QuestionSetRepository;
            }
        }

        public IAnswerSetRepository AnswerSet
        {
            get
            {
                if (m_AnswerSetRepository == null)
                    m_AnswerSetRepository = new AnswerSetRepository(m_RepositoryContext);
                return m_AnswerSetRepository;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            m_RepositoryContext = repositoryContext;
        }

        public void Save()
        {
            m_RepositoryContext.SaveChanges();
        }
    }
}
