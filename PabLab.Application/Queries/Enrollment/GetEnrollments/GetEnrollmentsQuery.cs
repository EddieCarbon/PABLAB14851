using MediatR;
using PabLab.Application.Dtos.Course;
using PabLab.Application.Dtos.Enrollment;

namespace PabLab.Application.Queries.Enrollment.GetEnrollments;

public record GetEnrollmentQuery() : IRequest<EnrollmentListDto>; 
