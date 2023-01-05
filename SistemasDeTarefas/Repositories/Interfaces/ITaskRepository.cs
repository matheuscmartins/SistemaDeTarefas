using SistemasDeTarefas.Models;

namespace SistemasDeTarefas.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskModel>> FindAllTasks();
        Task<TaskModel> FindById(int id);
        Task<TaskModel> AddTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task, int id);
        Task<bool> DeleteTask(int id);
    }
}
