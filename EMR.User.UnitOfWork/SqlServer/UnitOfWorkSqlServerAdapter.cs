using EMR.Data.Context;
using EMR.UnitOfWork.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace EMR.UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerAdapter : IUnitOfWorkAdapter
    {
        private bool disposed = false;
        private EmrContext context { get; set; }
        private IDbContextTransaction transaction { get; set; }

        public IUnitOfWorkRepository? Repositories { get; private set; }

        public UnitOfWorkSqlServerAdapter(EmrContext context)
        {
            this.context = context;
            transaction = context.Database.BeginTransaction();

            Repositories = new UnitOfWorkSqlServerRepository(this.context);
        }

        /// <summary>
        /// Commits the current transaction
        /// </summary>
        public Task<bool> CommitTransaction()
        {
            var success = false;

            try
            {
                if (transaction != null)
                {                    
                    transaction.Commit();
                }

                success = true;
            }
            catch (Exception e)
            {
                try
                {
                    this.RollbackTransaction();
                }
                catch (Exception innerEx)
                {
                    if (transaction != null)
                    {
                        Console.WriteLine("An exception of type " + innerEx.GetType() + " was encountered while attempting to roll back the transaction.");
                    }
                }

                Console.WriteLine("An exception of type " + e.GetType() + " was encountered while committing transaction.");

                success = false;
            }

            return Task.FromResult(success);
        }

        /// <summary>
        /// Rolls back the current transaction
        /// </summary>
        public Task RollbackTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }

            return Task.CompletedTask;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                    }

                    if (context != null)
                    {
                        context.Dispose();
                    }

                    Repositories = null;
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
