namespace PabLab.Domain.Entities;

public class Course : AuditableEntity
{
    public int CourseId { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }

    // Navigation property
    public ICollection<Enrollment> Enrollments { get; set; }
}