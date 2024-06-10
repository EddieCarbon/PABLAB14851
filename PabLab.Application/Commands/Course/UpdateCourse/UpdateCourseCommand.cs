using MediatR;

namespace PabLab.Application.Commands.Course.UpdateCourse
{
    public class UpdateCourseCommand : IRequest
    {
        public int CourseId { get; set; }
        
        public string Title { get; set; }
        
        public int Credits { get; set; }
    }
}
