using AutoMapper;
using MediatR;
using PabLab.Application.Dtos.Course;
using PabLab.Application.Queries.Course.GetCourses;
using PabLab.Domain.Abstractions;

namespace PabLab.Application.Queries.Enrollment.GetEnrollments;

internal class GetEnrollmentsQueryHandler : IRequestHandler<GetCoursesQuery, CourseListDto>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public GetEnrollmentsQueryHandler(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<CourseListDto> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var products = await _courseRepository.GetAllAsync(cancellationToken);

        var productsDto = _mapper.Map<CourseListDto>(products);

        return productsDto;
    }
}
