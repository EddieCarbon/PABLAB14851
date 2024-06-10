using MediatR;

namespace PabLab.Application.Commands.Course.AddCourse;

public class AddCourseCommand : IRequest
{
    public string Title { get; set; }
    public int Credits { get; set; }
}
