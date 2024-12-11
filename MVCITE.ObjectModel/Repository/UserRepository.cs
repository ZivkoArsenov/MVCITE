using Microsoft.EntityFrameworkCore;
using MVCITE.ObjectModel.DataContext;
using MVCITE.ObjectModel.DataModels;
using MVCITE.ObjectModel.DTOs;
using MVCITE.ObjectModel.IRepository;

namespace MVCITE.ObjectModel.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MvcContext _context;

        public UserRepository(IDbContextFactory<MvcContext> contextFactory)
        {
            _context = contextFactory.CreateDbContext();
        }

        public async Task<User>? DoesUserExistsAsync(string username, string password)
        {
            try
            {
                User? user = null;


                user = await _context.User.Where(x => x.Username == username && x.Password == password).AsNoTracking().FirstOrDefaultAsync();

                if (user is null) throw new CustomException($"The user: {username}, does not exist in the database.");
                if (!user.IsActive) throw new CustomException($"The user: {username}, is not active.");

                return user;

            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.User.ToListAsync();
        }
        public async Task<bool?> InsertUserAsync(User user)
        {
            bool result = false;
            try
            {
                await _context.User.AddAsync(user);
                int res = await _context.SaveChangesAsync();

                if (res < 1) throw new CustomException($"Error inserting user. Data for the user: {user.Username}, has not been recorded in the database.");
                result = true;
            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public async Task<bool?> UpdateUserAsync(User user)
        {
            bool result = false;
            try
            {
                User? existUser = await _context.User.Where(x => x.ID == user.ID).FirstOrDefaultAsync();

                if (existUser is null) throw new CustomException($"The user {user.Username} does not exist in the database.");
                if (!existUser.IsActive) throw new CustomException($"The user {user.Username} is not active.");

                existUser.Username = user.Username;
                existUser.Password = user.Password;
                existUser.Email = user.Email;
                existUser.FullName = user.FullName;
                existUser.RoleID = user.RoleID;

                int res = await _context.SaveChangesAsync();

                if (res < 0) throw new CustomException($"Error updateing user. Data for the user: {user.Username}, has not been recorded in the database.");
                result = true;
            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public async Task<bool?> DeleteUserAsync(int id)
        {
            bool result = false;
            try
            {
                User? existUser = await _context.User.Where(x => x.ID == id).FirstOrDefaultAsync();

                if (existUser is null) throw new CustomException($"The user does not exist in the database.");
                if (!existUser.IsActive) throw new CustomException($"The user is not active.");
                
                _context.Remove(existUser);

                int res = await _context.SaveChangesAsync();

                if (res < 0) throw new CustomException($"Error deleting user.");

                result = true;
            }
            catch (CustomException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public async Task<User> GetUserByIDAsync(int id)
        {
            return await _context.User.Where(x => x.ID == id).FirstOrDefaultAsync();
        }
    }
}
