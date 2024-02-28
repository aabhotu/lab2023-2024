using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PractiveRoom.Contracts;
using PractiveRoom.Entities;
using PractiveRoom.Entities.DTO;
using PractiveRoom.Models;
using System.Linq;

namespace PractiveRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController: ControllerBase
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repository;
        private RepositoryContext _context;
        public ScheduleController(IMapper mapper, IRepositoryWrapper repository, RepositoryContext context)
        {
            _mapper = mapper;
            _repository = repository;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllSchedule()
        {
            try
            {
                var result = from schedule in _context.schedules
                             join room in _context.rooms on schedule.roomId equals room.roomId
                             join teacher in _context.teachers on schedule.teacherId equals teacher.teacherId
                             join subject in _context.subjects on schedule.subjectId equals subject.subjectId
                             select new
                             {
                                 scheduleId = schedule.scheduleId,
                                 day = schedule.day,
                                 month = schedule.month,
                                 year = schedule.year,
                                 startTime = schedule.startTime,
                                 endTime = schedule.endTime,
                                 roomId = room.roomId,
                                 roomName = room.roomName,
                                 teacherId = teacher.teacherId,
                                 teacherName = teacher.name,
                                 subjectId = subject.subjectId,
                                 subjectName = subject.subjectName,
                             };
                //var schedule = _repository.Schedule.GetAllSchedule();
                //var scheduleResult = _mapper.Map<IEnumerable<scheduleDto>>(schedule);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/student")]
        public IActionResult GetStudentInSchedule(int id)
        {
            var students = from schedule in _context.schedules
                           join temp in _context.studentSchedules on schedule.scheduleId equals temp.scheduleId
                           join student in _context.users on temp.userId equals student.id
                           where schedule.scheduleId == id
                           select new
                           {
                               scheduleId = schedule.scheduleId,
                               studentName = student.username,
                               
                           };
            return Ok(students);
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
                scheduleEntity.scheduleId = _repository.Schedule
                                                .GetAllSchedule()
                                                .OrderByDescending(i => i.scheduleId)
                                                .FirstOrDefault().scheduleId + 1;
                _repository.Schedule.CreateSchedule(scheduleEntity);
                _repository.save();
                var scheduleCreate = _mapper.Map<scheduleDto>(scheduleEntity);
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
