using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskSistemDBContext _dbContext;
        public UserRepository(TaskSistemDBContext taskSistemDbContext)
        {
            _dbContext = taskSistemDbContext;
        }
        public async Task<UserModel> FindById(int id)
        {
            UserModel? userModel = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            return userModel;
        }

        public async Task<List<UserModel>> FindAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        
        public async Task<UserModel> AddUser(UserModel user)
        {
           await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await FindById(id);
            if (userById == null)
            {
                throw new Exception($"User not found by ID:{id} in Data Base");
            }
            _dbContext.Users.Remove(userById);
           await _dbContext.SaveChangesAsync();
            return true;
        }     

        public async Task<UserModel> UpdateUser(UserModel user, int id)

        {
            UserModel userById = await FindById(id);
            if (userById == null)
            {
                throw new Exception($"User not found by ID:{id} in Data Base");
            }
            userById.Name = user.Name;
            userById.Email = user.Email;
            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();
            return userById;
        }
    }
}
