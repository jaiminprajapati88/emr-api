using EMR.Data.Context;
using EMR.Data.Model.Exception;
using EMR.Data.Model.Patient.Request;
using EMR.Repository.Core;
using EMR.Repository.Extension;
using EMR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EMR.Repository.SqlServer
{
    public class PatientRepository : BaseRepository, IPatientRepository
    {
        #region Constuctor

        public PatientRepository(EmrContext context) : base(context) { }

        #endregion Constuctor

        #region Repository Methods

        public async Task<IEnumerable<PatientDetail>> GetAllByOrganization(Guid organizationDetailId)
        {
            var query = from patient in _context.PatientDetails
                        from org in patient.PatientOrganizations
                        where org.OrganizationDetailId == organizationDetailId && patient.IsActive == true
                        select patient;

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<PatientDetail>> Search(SearchPatientRequestModel search)
        {
            var query = from patient in _context.PatientDetails
                        from org in patient.PatientOrganizations
                        where org.OrganizationDetailId == search.OrganizationDetailId && patient.IsActive == true
                        select patient;

            if(!string.IsNullOrEmpty(search.FirstName)) { query = query.Where(patient => patient.FirstName.ToLower().Contains(search.FirstName.ToLower())); }
            if (!string.IsNullOrEmpty(search.LastName)) { query = query.Where(patient => patient.LastName.ToLower().Contains(search.LastName.ToLower())); }
            if (!string.IsNullOrEmpty(search.CellNo)) { query = query.Where(patient => patient.CellNo == search.CellNo); }

            return await query.AsQueryable().ToListAsyncSafe();
        }

        public async Task<PatientDetail> GetDetails(Guid patientDetailId)
        {
            var patient = await _context.PatientDetails.SingleOrDefaultAsync(p => p.PatientDetailId == patientDetailId && p.IsActive == true);

            if (patient == null)
            {
                BusinessException exception = new BusinessException(HttpStatusCode.Conflict);
                exception.AddErrorDetail("PTNT001", "Patient does not exists.");
                throw exception;
            }

            return patient;
        }

        public async Task<bool> Save(PatientDetail patient)
        {
            int result = 0;

            if (patient.PatientDetailId != null && patient.PatientDetailId != Guid.Empty)
            {
                base.Update<PatientDetail>(patient);
            }
            else
            {
                await base.Add<PatientDetail>(patient);
            }

            result = _context.SaveChanges();
            return result > 0;
        }

        #endregion Repository Methods
    }
}
