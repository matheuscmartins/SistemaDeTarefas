using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasDeTarefas.Models;
using SistemasDeTarefas.Repositories.Interfaces;

namespace SistemasDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> FindaAllUsers()
        {
            List<UserModel> userModels = await _userRepository.FindAllUsers();
            return Ok(userModels);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> FindById(int id)
        {
            UserModel userModel = await _userRepository.FindById(id);
            return Ok(userModel);
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> AddUsers([FromBody] UserModel userModel)
        {
            UserModel userNew = await _userRepository.AddUser(userModel);
            return Ok(userNew);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody] UserModel userModel, int id)
        {
            userModel.Id = id;
            UserModel userNew = await _userRepository.AddUser(userModel);
            return Ok(userNew);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUser(int id)
        {
            bool deleted = await _userRepository.DeleteUser(id);
            return Ok(deleted);
        }
    }
}
