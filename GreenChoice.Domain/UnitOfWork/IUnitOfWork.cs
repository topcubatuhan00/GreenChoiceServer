namespace GreenChoice.Domain.UnitOfWork;

public interface IUnitOfWork
{
    IUnitOfWorkAdapter Create();
}
