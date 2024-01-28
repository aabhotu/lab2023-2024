using PractiveRoom.Models;

namespace PractiveRoom.Contracts
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAllSubject();
        Subject GetSubjectById(int id);
        void CreateSubject(Subject subject);
        void UpdateSubject(Subject subject);
        void DeleteSubject(Subject subject);
    }
}
