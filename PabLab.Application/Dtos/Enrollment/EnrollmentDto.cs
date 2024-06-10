using PabLab.Application.Dtos.Course;
using PabLab.Application.Dtos.Student;

namespace PabLab.Application.Dtos.Enrollment;

public class EnrollmentDto
{
    public int EnrollmentId { get; set; }
    
    public int CourseId { get; set; }
    
    public int StudentId { get; set; }
    
    public string Grade { get; set; }

    
    public CourseDto Course { get; set; }
    
    public StudentDto Student { get; set; }
}