using MediatR;
using PabLab.Domain.Abstractions;
using PabLab.Domain.Exceptions;

namespace PabLab.Application.Commands.Course.UpdateCourse
{
    internal class UpdateStudentCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStudentCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var product = await _courseRepository.GetByIdAsync(request.CourseId, cancellationToken);
            if (product == null)
                throw new NotFoundException(request.CourseId);

            if (product.Title != request.Title)
            {
                bool isAlreadyExist = await _courseRepository.IsAlreadyExistAsync(request.Title, cancellationToken);
                if (isAlreadyExist)
                    throw new AlreadyExistsException(request.Title);
            }

            product.Title = request.Title;
            product.Credits = request.Credits;

            _courseRepository.Update(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
