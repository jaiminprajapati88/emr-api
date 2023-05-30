using EMR.Data.Context;
using EMR.Data.Model.Exception;
using EMR.Data.Model.Organization.Request;
using EMR.Repository.Core;
using EMR.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EMR.Repository.SqlServer
{
    public class OrganizationRepository : BaseRepository, IOrganizationRepository
    {
        #region Constuctor

        public OrganizationRepository(EmrContext context) : base(context) { }

        #endregion Constuctor

        #region Repository Methods

        public async Task<OrganizationDetail> GetOrganizationById(Guid organizationDetailId)
        {
            var organization = await base.GetById<OrganizationDetail>(organizationDetailId);

            if (organization == null)
            {
                BusinessException exception = new BusinessException(HttpStatusCode.Conflict);
                exception.AddErrorDetail("ORG002", "Organization does not exists.");
                throw exception;
            }

            return organization;
        }

        public async Task<IEnumerable<OrganizationDetail>> Serach(SearchOrganizationRequestModel search)
        {
            var query = from org in _context.OrganizationDetails
                        where org.IsActive == true
                        select org;

            if (search.OrganizationDetailId != null && search.OrganizationDetailId != Guid.Empty) { query = query.Where(org => org.OrganizationDetailId == search.OrganizationDetailId); }
            if (!string.IsNullOrEmpty(search.OrganizationName)) { query = query.Where(org => org.OrganizationName.ToLower().Contains(search.OrganizationName.ToLower())); }
            if (search.OrganizationTypeId != null) { query = query.Where(org => org.OrganizationTypeId == search.OrganizationTypeId); }

            return await query.ToListAsync();
        }

        public async Task<bool> Save(OrganizationDetail organization)
        {
            int result = 0;

            if (organization.OrganizationDetailId != Guid.Empty)
            {
                base.Update<OrganizationDetail>(organization);
            }
            else
            {
                await base.Add<OrganizationDetail>(organization);
            }

            result = _context.SaveChanges();
            return result > 0;
        }

        public Task<bool> Delete(OrganizationDetail organization)
        {
            int result = 0;
            base.Delete<OrganizationDetail>(organization);
            result = _context.SaveChanges();

            return Task.FromResult(result > 0);
        }

        #endregion Repository Methods
    }
}
