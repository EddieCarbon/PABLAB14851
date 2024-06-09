using MediatR;
using PabLab.Application.Commands.Course.RemoveCourse;
using PabLab.Domain.Abstractions;
using PabLab.Domain.Exceptions;

namespace PabLab.Application.Commands.Student.RemoveStudent;

internal class RemoveEnrollmentCommandHandler : IRequestHandler<RemoveStudentCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RemoveEnrollmentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id, cancellationToken);
        if (student == null)
            throw new NotFoundException(request.Id);

        _studentRepository.Delete(student);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
