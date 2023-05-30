using EMR.Repository.Interfaces;

namespace EMR.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        IAuthRepostiroy AuthRepository { get; }
        IConfigRepository ConfigRepository { get; }
        IOrganizationRepository OrganizationRepository { get; }
        IPatientRepository PatientRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
