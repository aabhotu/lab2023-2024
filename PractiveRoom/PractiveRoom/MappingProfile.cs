using AutoMapper;
using PractiveRoom.Entities.DTO;
using PractiveRoom.Models;

namespace PractiveRoom
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<User, userDto > ();
            CreateMap<UserForChange, User>();

            CreateMap<Room, roomDto > ();
            CreateMap<RoomForChange, Room>();

            CreateMap<Subject, subjectDto > ();
            CreateMap<SubjectForChange, Subject>();

            CreateMap<Teacher,teacherDto> ();
            CreateMap<teacherForChange, Teacher>();

            CreateMap<Schedule, scheduleDto > ();
            CreateMap <ScheduleForChange, Schedule > ();

            CreateMap<StudentSchedule, StudentScheduleDto>();
        }
    }
}
