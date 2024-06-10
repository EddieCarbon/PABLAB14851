namespace PabLab.Domain.Entities;

public class Enrollment : AuditableEntity
{
    public int EnrollmentId { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public DateTime EnrollmentDate { get; set; }

    // Navigation properties
    public Student Student { get; set; }
    public Course Course { get; set; }
}