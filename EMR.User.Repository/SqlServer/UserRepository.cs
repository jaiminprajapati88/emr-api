using EMR.Repository.Interfaces;
using EMR.Repository.Core;
using EMR.Repository.Constant;
using EMR.Data.Model.User.Request;
using EMR.Data.Context;
using EMR.Data.Model.Exception;
using EMR.Common.Extension;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EMR.Repository.SqlServer
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        #region Constuctor

        public UserRepository(EmrContext context) : base(context) { }

        #endregion Constuctor

        #region Repository Methods

        public async Task<IEnumerable<UserDetail>> GetAll()
        {
            return await base.GetAll<UserDetail>();
        }

        public async Task<IEnumerable<UserDetail>> Search(SearchUserRequestModel search)
        {
            var query = from user in _context.UserDetails
                        from orgUser in user.UserOrganizations
                        where orgUser.OrganizationDetailId == search.OrganizationDetailId
                              && user.IsActive == true
                        select user;

            if (!string.IsNullOrEmpty(search.FirstName)) { query = query.Where(user => user.FirstName.ToLower().Contains(search.FirstName.ToLower())); }
            if (!string.IsNullOrEmpty(search.LastName)) { query = query.Where(user => user.LastName.ToLower().Contains(search.LastName.ToLower())); }
            if (!string.IsNullOrEmpty(search.EmailAddress)) { query = query.Where(user => user.EmailAddress.ToLower() == search.EmailAddress.ToLower()); }
            if (search.UserRoleId != null) { query = query.Where(user => user.UserRoleId == search.UserRoleId); }

            return await query.ToListAsync();
        }

        public async Task<UserDetail> GetDetails(string emailAddress)
        {
            var user = await _context.UserDetails.SingleOrDefaultAsync(user => user.EmailAddress.ToLower() == emailAddress.ToLower() && user.IsActive == true);

            if (user == null)
            {
                BusinessException exception = new BusinessException(HttpStatusCode.Conflict);
                exception.AddErrorDetail("USR001", "User '" + emailAddress + "' does not exists.");
                throw exception;
            }

            return user;
        }

        public async Task<bool> ResetPassword(string emailAddress, string newPassword)
        {
            var result = 0;
            var newPasswordSalt = SecurityConstant.KeySize.GenerateSalt();
            var newPasswordHash = newPassword.GenerateHash(newPasswordSalt);
            var userDetail = await _context.UserDetails.FirstOrDefaultAsync(user => user.EmailAddress.ToLower() == emailAddress.ToLower() && user.IsActive == true);

            if (userDetail != null)
            {
                userDetail.PasswordHash = newPasswordHash;
                userDetail.PasswordSalt = newPasswordSalt;
                base.Update<UserDetail>(userDetail);

                result = _context.SaveChanges();
            }

            return result > 0;
        }

        public async Task<bool> Save(UserDetail user)
        {
            int result = 0;            

            if (user.UserDetailId != Guid.Empty)
            {
                base.Update<UserDetail>(user);
            }
            else
            {
                await base.Add<UserDetail>(user);
            }

            result = _context.SaveChanges();
            return result > 0;
        }

        #endregion Repository Methods
    }
}
