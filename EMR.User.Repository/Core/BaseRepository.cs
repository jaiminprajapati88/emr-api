using EMR.Data.Context;
using EMR.Repository.Extension;
using Microsoft.EntityFrameworkCore;

namespace EMR.Repository.Core
{
    public abstract class BaseRepository
    {
        #region Properties

        protected EmrContext _context;

        #endregion Properties

        #region Constuctor

        internal BaseRepository(EmrContext context)
        {
            _context = context;
        }

        #endregion Constuctor

        #region Generic Methods

        public async Task<T> GetById<T>(int id) where T : class => await _context.Set<T>().FindAsync(id);

        public async Task<T> GetById<T>(Guid id) where T : class => await _context.Set<T>().FindAsync(id);

        public async Task<List<T>> GetAll<T>(Func<T, bool>? predicate = null) where T : class => await _context.Set<T>().Where(predicate).AsQueryable().ToListAsyncSafe();

        public async Task<IEnumerable<T>> Search<T>(Func<T, bool> predicate) where T : class => await _context.Set<T>().Where(predicate).AsQueryable().ToListAsyncSafe();

        public async Task Add<T>(T entity) where T : class => await _context.Set<T>().AddAsync(entity);

        public void Update<T>(T entity) where T : class => _context.Set<T>().Update(entity);

        public void Delete<T>(T entity) where T : class => _context.Set<T>().Remove(entity);

        #endregion Generic Methods
    }
}
