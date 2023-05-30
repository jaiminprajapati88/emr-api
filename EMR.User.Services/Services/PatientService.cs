using AutoMapper;
using EMR.Common.Constant;
using EMR.Common.Extension;
using EMR.Data.Context;
using EMR.Data.Model.Exception;
using EMR.Data.Model.Patient;
using EMR.Data.Model.Patient.Request;
using EMR.Data.Model.User;
using EMR.Data.Model.User.Request;
using EMR.Services.Interfaces;
using EMR.UnitOfWork.Interfaces;
using System.Net;
using System.Net.Mail;

namespace EMR.Services.Services
{
    public class PatientService : IPatientService
    {
        #region Properties

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        #endregion Properties

        #region Constuctor

        public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constuctor

        #region Service Methods

        public async Task<IEnumerable<PatientDetailModel>> GetPatientsByOrganization(Guid organizationDetailId)
        {
            using (var context = _unitOfWork.Create())
            {
                var patients = await context.Repositories.PatientRepository.GetAllByOrganization(organizationDetailId);
                return _mapper.Map<IEnumerable<PatientDetailModel>>(patients);
            }
        }

        public async Task<IEnumerable<PatientDetailModel>> Search(SearchPatientRequestModel search)
        {
            using (var context = _unitOfWork.Create())
            {
                var patients = await context.Repositories.PatientRepository.Search(search);
                return _mapper.Map<IEnumerable<PatientDetailModel>>(patients);
            }
        }

        public async Task<PatientDetailModel> GetDetails(Guid patientDetailId)
        {
            using (var context = _unitOfWork.Create())
            {
                var details = await context.Repositories.PatientRepository.GetDetails(patientDetailId);
                var model = _mapper.Map<PatientDetailModel>(details);

                if (details.PatientAddresses.Any())
                {
                    details.PatientAddresses.ToArray()[0].CopyProperties(model);
                }

                if (details.PatientIdentities.Any())
                {
                    details.PatientIdentities.ToArray()[0].CopyProperties(model);
                }

                return model;
            }
        }

        public async Task<bool> Save(SavePatientRequestModel patient)
        {
            using (var context = _unitOfWork.Create())
            {
                var patientEntity = _mapper.Map<PatientDetail>(patient);
                var isUpdatePatient = patient.PatientDetailId != null && patient.PatientDetailId != Guid.Empty;
                var searchModel = new SearchPatientRequestModel(patient.OrganizationDetailId, patient.CellNo);
                var patients = context.Repositories.PatientRepository.Search(searchModel);

                if ((isUpdatePatient && patients.Result.Count() > 1) || (!isUpdatePatient && patients.Result.Count() > 0))
                {
                    BusinessException exception = new BusinessException(HttpStatusCode.Conflict);
                    exception.AddErrorDetail("PTNT002", "Patient '" + string.Join(" ", patient.FirstName, patient.LastName) + "' already exists.");
                    throw exception;
                }

                if (isUpdatePatient)
                {
                    patientEntity = patients.Result.SingleOrDefault(p => p.PatientDetailId == patient.PatientDetailId);
                    patient.CopyProperties(patientEntity);
                }
                else
                {
                    patientEntity.PatientOrganizations.Add(new PatientOrganization()
                    {
                        OrganizationDetailId = patient.OrganizationDetailId
                    });
                }

                patientEntity.PatientAddresses.Clear();
                patientEntity.PatientIdentities.Clear();

                var address = new PatientAddress();
                patient.CopyProperties(address);
                patientEntity.PatientAddresses.Add(address);

                var identity = new PatientIdentity();
                patient.CopyProperties(identity);
                patientEntity.PatientIdentities.Add(identity);

                var result = await context.Repositories.PatientRepository.Save(patientEntity);
                await context.CommitTransaction();

                return result;
            }
        }

        #endregion Service Methods
    }
}
