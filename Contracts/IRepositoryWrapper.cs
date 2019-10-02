namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IQuestionSetRepository QuestionSet { get; }
        IAnswerSetRepository AnswerSet { get; }
        void Save();
    }
}
