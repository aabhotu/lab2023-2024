using PractiveRoom.Contracts;
using PractiveRoom.Entities;
using PractiveRoom.Models;

namespace PractiveRoom.Repository
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(RepositoryContext context) : base(context) { }


        public IEnumerable<Subject> GetAllSubject()
        {
            return All().OrderBy(i => i.subjectName).ToList();
        }

        public Subject GetSubjectById(int id)
        {
            return Find(i => i.subjectId == id).FirstOrDefault();
        }

        public void CreateSubject(Subject subject)=> Create(subject);
        
        public void UpdateSubject(Subject subject)=> Update(subject);

        public void DeleteSubject(Subject subject)=> Delete(subject);
    }
}
