using MediatR;
using PabLab.Application.Dtos.Course;

namespace PabLab.Application.Queries.Course.GetCourseByName;

public record GetStudentByNameQuery(string Name) : IRequest<CourseDto>;

