namespace EduPath.Models;

public sealed class CourseInformation
{
    [JsonIgnore]
    public const int Credit = 2;

    [JsonPropertyOrder(0)]
    [JsonPropertyName("CourseId")]
    public int Id { get; set; }

    [JsonPropertyOrder(1)]
    [JsonPropertyName("CourseName")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyOrder(2)]
    [JsonPropertyName("Lecturer")]
    public string Lecturer { get; set; } = string.Empty;

    [JsonPropertyOrder(3)]
    [JsonPropertyName("Classroom")]
    public string Classroom { get; set; } = string.Empty;

    [JsonPropertyOrder(4)]
    [JsonPropertyName("WeekDay")]
    public WeekDay Day { get; set; }

    [JsonPropertyOrder(5)]
    [JsonPropertyName("Period")]
    public int Period { get; set; }

    [JsonPropertyOrder(6)]
    [JsonPropertyName("Semester")]
    public string Semester { get; set; } = string.Empty;

    [JsonPropertyOrder(7)]
    [JsonPropertyName("CourseCategory")]
    public CourseCategory Category { get; set; }

    [JsonPropertyOrder(8)]
    [JsonPropertyName("MinimumGrade")]
    public string? MinimumGrade { get; set; }
}