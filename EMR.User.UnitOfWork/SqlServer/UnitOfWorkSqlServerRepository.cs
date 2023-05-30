using EMR.UnitOfWork.Interfaces;
using EMR.Repository.Interfaces;
using EMR.Repository.SqlServer;
using EMR.Data.Context;

namespace EMR.UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        #region Properties

        #region Private Properties

        private EmrContext _context { get; set; }

        private IAuthRepostiroy? _authRepository = null;
        private IConfigRepository? _configRepository = null;
        private IOrganizationRepository? _organizationRepository = null;
        private IPatientRepository? _patientRepository = null;
        private IUserRepository? _userRepository = null;

        #endregion Private Properties

        #region Public Properties

        public IAuthRepostiroy AuthRepository
        {
            get
            {
                if (_authRepository == null)
                {
                    _authRepository = new AuthRepository(_context);
                }

                return _authRepository;
            }
        }
        public IConfigRepository ConfigRepository
        {
            get
            {
                if (_configRepository == null)
                {
                    _configRepository = new ConfigRepository(_context);
                }

                return _configRepository;
            }
        }
        public IOrganizationRepository OrganizationRepository
        {
            get
            {
                if (_organizationRepository == null)
                {
                    _organizationRepository = new OrganizationRepository(_context);
                }

                return _organizationRepository;
            }
        }
        public IPatientRepository PatientRepository
        {
            get
            {
                if (_patientRepository == null)
                {
                    _patientRepository = new PatientRepository(_context);
                }

                return _patientRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }

                return _userRepository;
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Constructor

        public UnitOfWorkSqlServerRepository(EmrContext context)
        {
            this._context = context;
        }

        public void Dispose()
        {
            _authRepository = null;
            _configRepository = null;
            _organizationRepository = null;
            _userRepository = null;
        }

        #endregion Constructor
    }
}
