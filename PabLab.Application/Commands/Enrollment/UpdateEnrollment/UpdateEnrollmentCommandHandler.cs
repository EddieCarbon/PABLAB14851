using MediatR;
using PabLab.Domain.Abstractions;
using PabLab.Domain.Exceptions;

namespace PabLab.Application.Commands.Student.UpdateStudent
{
    internal class UpdateEnrollmentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEnrollmentCommandHandler(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(request.StudentId, cancellationToken);
            if (student == null)
                throw new NotFoundException(request.StudentId);

            if (student.FirstName != request.FirstName || student.LastName != request.LastName)
            {
                bool isAlreadyExist = await _studentRepository.IsAlreadyExistAsync(request.FirstName, request.LastName, cancellationToken);
                if (isAlreadyExist)
                    throw new AlreadyExistsException(request.FirstName + request.LastName);
            }

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.DateOfBirth = request.DateOfBirth;

            _studentRepository.Update(student);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
