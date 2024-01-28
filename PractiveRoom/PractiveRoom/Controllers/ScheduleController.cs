using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PractiveRoom.Contracts;
using PractiveRoom.Entities.DTO;
using PractiveRoom.Models;

namespace PractiveRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController: ControllerBase
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repository;
        public ScheduleController(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllSchedule()
        {
            try
            {
                var schedule = _repository.Schedule.GetAllSchedule();
                var scheduleResult = _mapper.Map<IEnumerable<scheduleDto>>(schedule);
                return Ok(scheduleResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name = "Getschedule")]
        public IActionResult Getschedule(int id)
        {
            try
            {
                var schedule = _repository.Schedule.GetScheduleById(id);
                if (schedule == null)
                    return NotFound();
                var roomResult = _mapper.Map<scheduleDto>(schedule);
                return Ok(roomResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateSchedule([FromBody] ScheduleForChange schedule)
        {
            try
            {
                if (schedule == null)
                    return BadRequest();
                if (!ModelState.IsValid)
                    return BadRequest("Valid");
                var scheduleEntity = _mapper.Map<Schedule>(schedule);
                scheduleEntity.scheduleId = _repository.Schedule.GetAllSchedule().OrderByDescending(i => i.scheduleId).FirstOrDefault().roomId + 1;
                _repository.Schedule.CreateSchedule(scheduleEntity);
                _repository.save();
                var scheduleCreate = _mapper.Map<Schedule>(scheduleEntity);
                return CreatedAtRoute("GetSchedule", new { id = scheduleCreate }, scheduleCreate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRoom(int id)
        {
            try
            {
                if (id == null)
                    return BadRequest();
                var scheduleEntity = _repository.Schedule.GetScheduleById(id);
                if (scheduleEntity == null)
                    return NotFound();
                _repository.Schedule.DeleteSchedule(scheduleEntity);
                _repository.save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateSchedule([FromBody] ScheduleForChange schedule, int id)
        {
            try
            {
                if (id == null)
                    return BadRequest();
                var scheduleEntity = _repository.Schedule.GetScheduleById(id);
                if (scheduleEntity == null)
                    return NotFound();
                _mapper.Map(schedule, scheduleEntity);
                _repository.Schedule.UpdateSchedule(scheduleEntity);
                _repository.save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
