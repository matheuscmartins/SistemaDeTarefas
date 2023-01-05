using Microsoft.AspNetCore.Mvc;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository) {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> FindaAllTasks()
        {
            List<TaskModel> taskModel = await _taskRepository.FindAllTasks();
            return Ok(taskModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> FindById(int id)
        {
            TaskModel taskModel = await _taskRepository.FindById(id);
            return Ok(taskModel);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> Addtask([FromBody] TaskModel taskModel)
        {
            TaskModel taskNew = await _taskRepository.AddTask(taskModel);
            return Ok(taskNew);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskModel>> UpdateTask([FromBody] TaskModel taskModel, int id)
        {
            taskModel.Id = id;
            TaskModel taskNew = await _taskRepository.UpdateTask(taskModel, id);
            return Ok(taskNew);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskModel>> DeleteTask(int id)
        {
            bool deleted = await _taskRepository.DeleteTask(id);
            return Ok(deleted);
        }
    }
}
