using Microsoft.AspNetCore.Mvc;
using PractiveRoom.Contracts;
using PractiveRoom.Entities;
using PractiveRoom.Entities.DTO;
using PractiveRoom.Models;

namespace PractiveRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentScheduleController: ControllerBase
    {
        private readonly RepositoryContext _context;
        public StudentScheduleController(RepositoryContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetStudentSchedule()
        {
            try
            {
                var result = from stSchedule in _context.studentSchedules
                             join student in _context.users on stSchedule.userId equals student.id
                             join schedule in _context.schedules on stSchedule.scheduleId equals schedule.scheduleId
                             select new
                             {
                                 id = stSchedule.id,
                                 scheduleId = schedule.scheduleId,
                                 studentId = student.id,
                                 studentName = student.username
                             };
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPost]
        public IActionResult Create(StudentScheduleDto stSchedule)
        {
            var stScheduleEntity = new StudentSchedule()
            {
                id = _context.studentSchedules.OrderByDescending(i => i.id).FirstOrDefault().id + 1,
                userId = stSchedule.userId,
                scheduleId = stSchedule.scheduleId,
            };
            
            _context.studentSchedules.Add(stScheduleEntity);
            _context.SaveChangesAsync();
            return Ok();
        }
    }
}
