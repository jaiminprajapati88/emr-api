using EMR.Data.Model.Patient;
using EMR.Data.Model.Patient.Request;

namespace EMR.Services.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientDetailModel>> GetPatientsByOrganization(Guid organizationDetailId);
        Task<IEnumerable<PatientDetailModel>> Search(SearchPatientRequestModel search);
        Task<PatientDetailModel> GetDetails(Guid patientDetailId);
        Task<bool> Save(SavePatientRequestModel patient);
    }
}
