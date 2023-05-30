using EMR.UnitOfWork.Interfaces;
using System.Data;
using EMR.Data.Context;
using EMR.Data.Model.Settings;

namespace EMR.UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServer : IUnitOfWork
    {
        #region Properties

        private readonly EmrContext _context;
        private readonly AppSettings _appSettings;

        #endregion Properties

        #region Constructor

        public UnitOfWorkSqlServer(EmrContext context, AppSettings appSettings)
        {
            _appSettings = appSettings;
            _context = context;
        }

        #endregion Constructor

        #region Class Methods

        public IUnitOfWorkAdapter Create(IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            var connectionString = GetConnectionString(_appSettings.ConnectionString);
            return new UnitOfWorkSqlServerAdapter(_context);
        }

        #endregion Class Methods

        #region Private Methods

        private string GetConnectionString(ConnectionString connection)
        {
            return String.Format(
                    "Server={0};Database={1};Port={2};Username={3};Password={4};SSLMode=Prefer",
                    connection.Host,
                    connection.DatabaseName,
                    connection.Port,
                    connection.User,
                    connection.Password);
        }

        #endregion Private Methods
    }
}
