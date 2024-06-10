using MediatR;
using PabLab.Domain.Abstractions;
using PabLab.Domain.Exceptions;

namespace PabLab.Application.Commands.Student.AddStudent;

internal class AddStudentCommandHandler : IRequestHandler<AddStudentCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddStudentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
    {
        _studentRepository = studentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddStudentCommand request, CancellationToken cancellationToken)
    {
        bool isAlreadyExist = await _studentRepository.IsAlreadyExistAsync(request.FirstName, request.LastName, cancellationToken);
        if (isAlreadyExist) 
            throw new AlreadyExistsException(request.FirstName + request.LastName);

        var newStudent = new Domain.Entities.Student()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            DateOfBirth = request.DateOfBirth
        };

        _studentRepository.Add(newStudent);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
