using EMR.Data.Context;
using EMR.Data.Model.Patient.Request;
using EMR.Data.Model.User.Request;

namespace EMR.Repository.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<PatientDetail>> GetAllByOrganization(Guid organizationDetailId);

        Task<IEnumerable<PatientDetail>> Search(SearchPatientRequestModel search);
        Task<PatientDetail> GetDetails(Guid patientDetailId);
        Task<bool> Save(PatientDetail patient);
    }
}
