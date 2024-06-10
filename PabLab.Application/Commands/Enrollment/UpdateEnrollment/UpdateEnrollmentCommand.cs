using MediatR;

namespace PabLab.Application.Commands.Enrollment.UpdateEnrollment
{
    public class UpdateEnrollmentCommand : IRequest
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
    
        public int CourseId { get; set; }
    }
}
