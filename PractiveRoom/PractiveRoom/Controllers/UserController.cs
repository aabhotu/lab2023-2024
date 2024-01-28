using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PractiveRoom.Contracts;
using PractiveRoom.Entities.DTO;
using PractiveRoom.Models;

namespace PractiveRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repository;
        public UserController(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllUers()
        {
            try {
                var users = _repository.User.GetAllUser();
                var userResult = _mapper.Map<IEnumerable<userDto>>(users);
                return Ok(userResult);
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name ="GetUser")]
        public ActionResult GetUsers(Guid id)
        {
            //var user = UserDatas.UserList.FirstOrDefault(i => i.id == id);
            var user = _repository.User.GetUserById(id);
            if(user == null)
            {
                return NotFound();
            }
            var userResult = _mapper.Map<userDto>(user);
            return Ok(userResult);
        }
        [HttpPost]
        public ActionResult<User> AddUser([FromBody] UserForChange user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid");
            }
            var userEntity = _mapper.Map<User>(user);
            _repository.User.CreateUser(userEntity);
            _repository.save();
            var userCreate = _mapper.Map<userDto>(userEntity);
            return CreatedAtRoute("GetUser", new {id = userCreate.id }, userCreate);
        }
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _repository.User.GetUserById(id);
            _repository.User.DeleteUser(user);
            _repository.User.SaveChanges();

            return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UserForChange user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var userEntity = _repository.User.GetUserById(id);
            if (userEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(user, userEntity);
            _repository.User.UpdateUser(userEntity);
            _repository.User.SaveChanges();
            return NoContent();
        }
    }
}
