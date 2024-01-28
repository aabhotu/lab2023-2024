using PractiveRoom.Contracts;
using PractiveRoom.Entities;
using PractiveRoom.Models;

namespace PractiveRoom.Repository
{
    public class TeacherRepository: RepositoryBase<Teacher>, ITeacherReposiroty
    {
        public  TeacherRepository(RepositoryContext context): base (context) { }
        public IEnumerable<Teacher> GetAllTeacher()
        {
            return All().OrderBy(i => i.name).ToList();
        }
        public Teacher GetTeacherById(Guid id)
        {
            return Find(i=>i.teacherId.Equals(id)).FirstOrDefault();
        }
        public void CreateTeacher(Teacher teacher) => Create(teacher);
        public void DeleteTeacher(Teacher teacher) => Delete(teacher);
        public void UpdateTeacher(Teacher teacher) => Update(teacher);
    }
}
