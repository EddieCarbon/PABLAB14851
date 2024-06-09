using MediatR;
using PabLab.Application.Dtos.Course;

namespace PabLab.Application.Queries.Course.GetCourseById;

public record GetEnrollmentByIdQuery(int Id) : IRequest<CourseDto>;
