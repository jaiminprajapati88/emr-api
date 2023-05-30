using AutoMapper;
using EMR.Common.Extension;
using EMR.Data.Context;
using EMR.Data.Model.Exception;
using EMR.Data.Model.Organization.Request;
using EMR.Services.Interfaces;
using EMR.UnitOfWork.Interfaces;
using System.Net;

namespace EMR.Services.Services
{
    public class OrganizationService : IOrganizationService
    {
        #region Properties

        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        #endregion Properties

        #region Constuctor

        public OrganizationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Constuctor

        #region Service Methods

        public async Task<OrganizationDetail> GetOrganizationById(Guid organizationDetailId)
        {
            using (var context = _unitOfWork.Create())
            {
                return await context.Repositories.OrganizationRepository.GetOrganizationById(organizationDetailId);
            }
        }

        public async Task<IEnumerable<OrganizationDetail>> Serach(SearchOrganizationRequestModel search)
        {
            using (var context = _unitOfWork.Create())
            {
                return await context.Repositories.OrganizationRepository.Serach(search);
            }
        }

        public async Task<bool> Save(SaveOrganizationRequestModel model)
        {
            using (var context = _unitOfWork.Create())
            {
                var organization = _mapper.Map<OrganizationDetail>(model);
                var searchModel = new SearchOrganizationRequestModel(model.OrganizationDetailId, model.OrganizationName);
                var organizations = context.Repositories.OrganizationRepository.Serach(searchModel);
                var isUpdateOrganization = model.OrganizationDetailId != Guid.Empty;

                if ((isUpdateOrganization && organizations.Result.Any(org => org.OrganizationDetailId != model.OrganizationDetailId)) ||
                    (!isUpdateOrganization && organizations.Result.Any(org => org.OrganizationName.ToLower() == model.OrganizationName.ToLower())))
                {
                    BusinessException exception = new BusinessException(HttpStatusCode.Conflict);
                    exception.AddErrorDetail("ORG001", "Organization '" + model.OrganizationName + "' already exists.");
                    throw exception;
                }

                if (isUpdateOrganization)
                {
                    organization = organizations.Result.SingleOrDefault(org => org.OrganizationDetailId == model.OrganizationDetailId);
                    model.CopyProperties(organization);
                }

                var result = await context.Repositories.OrganizationRepository.Save(organization);
                await context.CommitTransaction();

                return result;
            }
        }

        public async Task<bool> Delete(Guid organizationDetailId)
        {
            using (var context = _unitOfWork.Create())
            {
                var result = false;
                var organization = await context.Repositories.OrganizationRepository.GetOrganizationById(organizationDetailId);

                if (organization != null)
                {
                    organization.IsActive = false;
                    result = await context.Repositories.OrganizationRepository.Save(organization);
                    await context.CommitTransaction();
                }

                return result;
            }
        }

        #endregion Service Methods
    }
}
