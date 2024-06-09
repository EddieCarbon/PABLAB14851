using MediatR;
using PabLab.Domain.Abstractions;
using PabLab.Domain.Exceptions;

namespace PabLab.Application.Commands.Course.AddCourse;

internal class AddStudentCommandHandler : IRequestHandler<AddCourseCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddStudentCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(AddCourseCommand request, CancellationToken cancellationToken)
    {
        bool isAlreadyExist = await _courseRepository.IsAlreadyExistAsync(request.Title, cancellationToken);
        if (isAlreadyExist) 
            throw new AlreadyExistsException(request.Title);

        var newCourse = new Domain.Entities.Course()
        {
            Title = request.Title,
            Credits = request.Credits
        };

        _courseRepository.Add(newCourse);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
