using Microsoft.EntityFrameworkCore;
using MVCITE.ObjectModel.DataContext;
using MVCITE.ObjectModel.DataModels;
using MVCITE.ObjectModel.IRepository;

namespace MVCITE.ObjectModel.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly MvcContext _context;

        public RoleRepository(IDbContextFactory<MvcContext> contextFactory)
        {
            _context = contextFactory.CreateDbContext();
        }
        public async Task<List<Role>> GetRolesAsync()
        {
            return await _context.Role.ToListAsync();
        }
    }
}
