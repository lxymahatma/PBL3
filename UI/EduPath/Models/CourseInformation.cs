namespace EduPath.Models;

public sealed class CourseInformation
{
    [JsonIgnore]
    public const int Credit = 2;

    [JsonPropertyName("CourseId")]
    public int Id { get; set; }

    [JsonPropertyName("CourseName")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("Lecturer")]
    public string Lecturer { get; set; } = string.Empty;

    [JsonPropertyName("Classroom")]
    public string ClassRoom { get; set; } = string.Empty;

    [JsonPropertyName("CourseCategory")]
    public CourseCategory Category { get; set; }

    [JsonPropertyName("WeekDay")]
    public WeekDay Day { get; set; }

    [JsonPropertyName("Period")]
    public int Period { get; set; }

    [JsonPropertyName("MinimumGrade")]
    public string? MinimumGrade { get; set; }

    [JsonPropertyName("Semester")]
    public string Semester { get; set; } = string.Empty;
}