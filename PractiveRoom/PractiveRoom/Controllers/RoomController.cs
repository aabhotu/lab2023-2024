using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PractiveRoom.Contracts;
using PractiveRoom.Entities;
using PractiveRoom.Entities.DTO;
using PractiveRoom.Models;

namespace PractiveRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController: ControllerBase
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repository;
        public RoomController(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllRoom()
        {
            try
            {
                var room = _repository.Room.GetAllRoom();
                var roomResult = _mapper.Map<IEnumerable<roomDto>>(room);
                return Ok(roomResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name ="GetRoom")]
        public IActionResult GetRoom(int id)
        {
            try
            {
                var room = _repository.Room.GetRoomById(id);
                if (room == null)
                    return NotFound();
                var roomResult = _mapper.Map<roomDto>(room);
                return Ok(roomResult);
            }
           catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateRoom([FromBody] RoomForChange room)
        {
            try
            {
                if (room == null)
                    return BadRequest();
                if (!ModelState.IsValid)
                    return BadRequest("Valid");
                var roomEntity = _mapper.Map<Room>(room);
                roomEntity.roomId = _repository.Room.GetAllRoom().OrderByDescending(i => i.roomId).FirstOrDefault().roomId + 1;
                _repository.Room.CreateRoom(roomEntity);
                _repository.save();
                var roomCreate = _mapper.Map<roomDto>(roomEntity);
                return CreatedAtRoute("GetRoom", new { id = roomCreate }, roomCreate);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            try {
                if (id == null)
                    return BadRequest();
                var roomEntity = _repository.Room.GetRoomById(id);
                if (roomEntity == null)
                    return NotFound();
                _repository.Room.DeleteRoom(roomEntity);
                _repository.save();
                return NoContent();
            } catch(Exception ex) { 
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPut("{id}")]
        public IActionResult UpdateRoom([FromBody]RoomForChange room,int id)
        {
            try
            {
                if (id == null)
                    return BadRequest();
                var roomEntity = _repository.Room.GetRoomById(id);
                if (roomEntity == null)
                    return NotFound();
                _mapper.Map(room, roomEntity);
                _repository.Room.UpdateRoom(roomEntity);
                _repository.save();
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
