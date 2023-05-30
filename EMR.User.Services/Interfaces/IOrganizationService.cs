using EMR.Data.Context;
using EMR.Data.Model.Organization.Request;

namespace EMR.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<OrganizationDetail> GetOrganizationById(Guid organizationDetailId);
        Task<IEnumerable<OrganizationDetail>> Serach(SearchOrganizationRequestModel search);
        Task<bool> Save(SaveOrganizationRequestModel model);
        Task<bool> Delete(Guid organizationDetailId);
    }
}
