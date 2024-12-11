using MVCITE.ObjectModel.DataModels;

namespace MVCITE.ObjectModel.IRepository
{
    public interface IUserRepository
    {
        Task<User>? DoesUserExistsAsync(string username, string password);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIDAsync(int id);
        Task<bool?> InsertUserAsync(User user);
        Task<bool?> UpdateUserAsync(User user);
        Task<bool?> DeleteUserAsync(int id);
    }
}
