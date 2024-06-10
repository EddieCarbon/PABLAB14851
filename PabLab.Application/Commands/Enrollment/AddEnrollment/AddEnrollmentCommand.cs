using MediatR;

namespace PabLab.Application.Commands.Enrollment.AddEnrollment;

public class AddEnrollmentCommand : IRequest
{
    public int StudentId { get; set; }
    
    public int CourseId { get; set; }
}
