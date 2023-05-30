using System.Data;

namespace EMR.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create(IsolationLevel level = IsolationLevel.ReadCommitted);
    }
}
