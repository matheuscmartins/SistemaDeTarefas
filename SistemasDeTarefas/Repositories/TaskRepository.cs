using Microsoft.EntityFrameworkCore;
using SistemasDeTarefas.Data;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSistemDBContext _dbContext;
        public TaskRepository(TaskSistemDBContext taskSistemDbContext)
        {
            _dbContext = taskSistemDbContext;
        }
        public async Task<TaskModel> FindById(int id)
        {
            TaskModel? taskModel = await _dbContext.TaskModels
                .Include(x => x.UserModel)
                .FirstOrDefaultAsync(x => x.Id == id);
            return taskModel;
        }

        public async Task<List<TaskModel>> FindAllTasks()
        {
            return await _dbContext.TaskModels
                .Include(x => x.UserModel)
                .ToListAsync();
        }

        
        public async Task<TaskModel> AddTask(TaskModel task)
        {
           await _dbContext.TaskModels.AddAsync(task);
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskById = await FindById(id);
            if (taskById == null)
            {
                throw new Exception($"Task not found by ID:{id} in Data Base");
            }
            _dbContext.TaskModels.Remove(taskById);
           await _dbContext.SaveChangesAsync();
            return true;
        }     

        public async Task<TaskModel> UpdateTask(TaskModel task, int id)

        {
            TaskModel taskById = await FindById(id);
            if (taskById == null)
            {
                throw new Exception($"Task not found by ID:{id} in Data Base");
            }
            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;
            _dbContext.TaskModels.Update(taskById);
            await _dbContext.SaveChangesAsync();
            return taskById;
        }
    }
}
