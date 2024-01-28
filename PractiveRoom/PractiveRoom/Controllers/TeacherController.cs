using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PractiveRoom.Contracts;
using PractiveRoom.Entities.DTO;
using PractiveRoom.Models;

namespace PractiveRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController: ControllerBase
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repository;
        public TeacherController(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllTeacher()
        {
            try
            {
                var teacher = _repository.Teacher.GetAllTeacher();
                var teacherResult = _mapper.Map<IEnumerable<teacherDto>>(teacher);
                return Ok(teacherResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name = "GetTeacher")]
        public IActionResult GetTeacher(Guid id)
        {
            try
            {
                var teacher = _repository.Teacher.GetTeacherById(id);
                if (teacher == null)
                    return NotFound();
                var teacherResult = _mapper.Map<teacherDto>(teacher);
                return Ok(teacherResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateTeacher([FromBody] teacherForChange teacher)
        {
            try
            {
                if (teacher == null)
                    return BadRequest();
                if (!ModelState.IsValid)
                    return BadRequest("Valid");
                var teacherEntity = _mapper.Map<Teacher>(teacher);
                _repository.Teacher.CreateTeacher(teacherEntity);
                _repository.save();
                var teacherCreate = _mapper.Map<teacherDto>(teacherEntity);
                return CreatedAtRoute("GetRoom", new { id = teacherCreate }, teacherCreate);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(Guid id)
        {
            try
            {
                if (id == null)
                    return BadRequest();
                var teacherEntity = _repository.Teacher.GetTeacherById(id);
                if (teacherEntity == null)
                    return NotFound();
                _repository.Teacher.Delete(teacherEntity);
                _repository.save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateTeacher([FromBody] teacherForChange teacher, Guid id)
        {
            try
            {
                if (id == null)
                    return BadRequest();
                var teacherEntity = _repository.Teacher.GetTeacherById(id);
                if (teacherEntity == null)
                    return NotFound();
                _mapper.Map(teacher, teacherEntity);
                _repository.Teacher.Update(teacherEntity);
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
