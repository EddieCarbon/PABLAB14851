namespace PabLab.Application.Dtos.Student;

public class StudentDto
{
    public int StudentId { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DateTime DateOfBirth { get; set; }
    
    public DateTime EnrollmentDate { get; set; }
}