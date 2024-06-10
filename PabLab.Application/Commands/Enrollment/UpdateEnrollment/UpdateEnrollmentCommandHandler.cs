using MediatR;
using PabLab.Application.Commands.Student.UpdateStudent;
using PabLab.Domain.Abstractions;
using PabLab.Domain.Exceptions;

namespace PabLab.Application.Commands.Enrollment.UpdateEnrollment
{
    internal class UpdateEnrollmentCommandHandler : IRequestHandler<UpdateEnrollmentCommand>
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEnrollmentCommandHandler
        (
            IEnrollmentRepository enrollmentRepository, 
            IStudentRepository studentRepository, 
            ICourseRepository courseRepository,
            IUnitOfWork unitOfWork)
        {
            _enrollmentRepository = enrollmentRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            var enrollment = await _enrollmentRepository.GetByIdAsync(request.EnrollmentId, cancellationToken);
            if (enrollment == null)
                throw new NotFoundException(request.EnrollmentId);

            if (enrollment.StudentId != request.StudentId)
            {
                bool isStudentExist = await _courseRepository.ExistsAsync(request.StudentId, cancellationToken);
                if (!isStudentExist)
                    throw new NotFoundException(request.StudentId);
            }
            
            if (enrollment.CourseId != request.CourseId)
            {
                bool isCourseExist = await _courseRepository.ExistsAsync(request.CourseId, cancellationToken);
                if (!isCourseExist)
                    throw new NotFoundException(request.CourseId);
            }

            enrollment.StudentId = request.StudentId;
            enrollment.CourseId = request.CourseId;

            _enrollmentRepository.Update(enrollment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
