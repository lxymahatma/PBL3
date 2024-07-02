namespace EduPath.Models;

public sealed class CourseInformation
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Credit { get; set; }
    public CourseCategory Category { get; set; }
    public CourseRating Rating { get; set; }
    public Thread? Thread { get; set; }
    public CourseInformation[]? Prerequisites { get; set; }
}