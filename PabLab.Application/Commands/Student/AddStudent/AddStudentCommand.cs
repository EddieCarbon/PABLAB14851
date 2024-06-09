using MediatR;

namespace PabLab.Application.Commands.Course.AddCourse;

public class AddStudentCommand : IRequest
{
    public string Title { get; set; }
    public int Credits { get; set; }
}
