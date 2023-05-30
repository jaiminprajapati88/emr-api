using EMR.Data.Context;
using EMR.Repository.Core;
using EMR.Repository.Interfaces;
using Npgsql;

namespace EMR.Repository.SqlServer
{
    public class AuthRepository : BaseRepository, IAuthRepostiroy
    {
        #region Constuctor

        public AuthRepository(EmrContext context) : base(context) { }

        #endregion Constuctor

        #region Repository Methods

        #endregion Repository Methods
    }
}
