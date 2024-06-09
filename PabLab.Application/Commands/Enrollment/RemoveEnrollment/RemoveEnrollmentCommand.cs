using MediatR;

namespace PabLab.Application.Commands.Student.RemoveStudent;

public record RemoveEnrollmentCommand(int Id) : IRequest;
