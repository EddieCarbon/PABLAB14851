using MediatR;

namespace PabLab.Application.Commands.Course.RemoveCourse;

public record RemoveStudentCommand(int Id) : IRequest;
