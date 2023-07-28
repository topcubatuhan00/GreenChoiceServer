namespace GreenChoice.Domain.UnitOfWork;

public interface IUnitOfWorkAdapter : IDisposable
{
    IUnitOfWorkRepository Repositories { get; }
    void SaveChanges();
}
