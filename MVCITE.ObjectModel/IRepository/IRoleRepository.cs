using MVCITE.ObjectModel.DataModels;

namespace MVCITE.ObjectModel.IRepository
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetRolesAsync();
    }
}
