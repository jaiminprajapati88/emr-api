using EMR.Data.Context;
using EMR.Data.Model.Organization.Request;

namespace EMR.Repository.Interfaces
{
    public interface IOrganizationRepository
    {
        Task<OrganizationDetail> GetOrganizationById(Guid organizationDetailId);
        Task<IEnumerable<OrganizationDetail>> Serach(SearchOrganizationRequestModel search);
        Task<bool> Save(OrganizationDetail organization);
        Task<bool> Delete(OrganizationDetail organization);
    }
}
