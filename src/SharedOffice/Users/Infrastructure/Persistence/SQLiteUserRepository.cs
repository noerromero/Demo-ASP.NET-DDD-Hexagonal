using Microsoft.EntityFrameworkCore;
using SharedOffice.Shared.Infrastructure.Persistence.EntityFramework;
using SharedOffice.Users.Domain;

namespace SharedOffice.Users.Infrastructure.Persistence
{
	public class SQLiteUserRepository : IUserRepository
	{
        private SharedOfficeContext _context;

        public SQLiteUserRepository(SharedOfficeContext context)
		{
            _context = context ?? throw new ArgumentNullException(nameof(context));
		}

        public async Task<IEnumerable<Helper>> SearchAllHelpers()
        {
            return await _context.Helpers.ToListAsync();
        }

        public async Task<Helper?> SearchHelperById(Guid helperId)
        {
            return await _context.Helpers.FirstOrDefaultAsync(x => x.Id == helperId);
        }
    }
}

