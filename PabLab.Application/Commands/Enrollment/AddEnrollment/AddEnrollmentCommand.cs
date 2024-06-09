using MediatR;

namespace PabLab.Application.Commands.Student.AddStudent;

public class AddEnrollmentCommand : IRequest
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DateTime DateOfBirth { get; set; }
}
