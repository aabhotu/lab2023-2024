using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PractiveRoom.Contracts;
using PractiveRoom.Entities.DTO;
using PractiveRoom.Models;

namespace PractiveRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
        private IMapper _mapper;
        private IRepositoryWrapper _repository;
        public SubjectController(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllSubject()
        {
            try
            {
                var subject = _repository.Subject.GetAllSubject();
                var subResult = _mapper.Map<IEnumerable<subjectDto>>(subject);
                return Ok(subResult);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}", Name="GetSubject")]
        public IActionResult GetSubjectById(int id)
        {
            try
            {
                var subject = _repository.Subject.GetSubjectById(id);
                if(subject == null)
                    return NotFound();
                var subResult = _mapper.Map<subjectDto>(subject);
                return Ok(subResult);
            }catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateSubject([FromBody]subjectDto subject)
        {
            try
            {
                if (subject == null)
                    return BadRequest();
                if (!ModelState.IsValid)
                    return BadRequest("Valid");
                var subEntity = _mapper.Map<Subject>(subject);
                subEntity.subjectId = _repository.Subject.GetAllSubject().OrderByDescending(i=>i.subjectId).FirstOrDefault().subjectId+1;
                _repository.Subject.CreateSubject(subEntity);
                var subResult = _mapper.Map<subjectDto>(subEntity);
                return CreatedAtRoute("GetSubject", new { subjectId = subResult.subjectId }, subResult);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(int id)
        {
            try
            {
                if (id == null)
                    return BadRequest();
                var sub = _repository.Subject.GetSubjectById(id);
                if (sub == null)
                    return NotFound();
                _repository.Subject.DeleteSubject(sub);
                _repository.save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSubject([FromBody] SubjectForChange subject,int id)
        {
            try
            {
                if(id==null) return BadRequest();
                var subEntity = _repository.Subject.GetSubjectById(id); 
                if(subEntity == null)
                    return NotFound();
                _mapper.Map(subject, subEntity);
                _repository.Subject.UpdateSubject(subEntity);
                _repository.save();
                return NoContent();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
