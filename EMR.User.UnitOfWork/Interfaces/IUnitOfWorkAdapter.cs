using System;

namespace EMR.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkAdapter : IDisposable
    {
        IUnitOfWorkRepository Repositories { get; }

        /// <summary>
        /// Commits the current transaction
        /// </summary>
        Task<bool> CommitTransaction();

        /// <summary>
        /// Rolls back the current transaction
        /// </summary>
        Task RollbackTransaction();
    }
}
