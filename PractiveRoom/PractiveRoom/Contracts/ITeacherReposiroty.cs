using PractiveRoom.Models;

namespace PractiveRoom.Contracts
{
    public interface ITeacherReposiroty:IRepositoryBase<Teacher>
    {
        IEnumerable<Teacher> GetAllTeacher();
        Teacher GetTeacherById(Guid id);
        void CreateTeacher(Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacher(Teacher teacher);
    }
}
