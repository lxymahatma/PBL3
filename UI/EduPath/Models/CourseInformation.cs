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

    [JsonPropertyName("ClassRoom")]
    public string ClassRoom { get; set; } = string.Empty;

    [JsonPropertyName("RegistrationType")]
    public string? RegistrationType { get; set; }

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

    [JsonPropertyName("Prerequisites")]
    public CourseInformation[]? Prerequisites { get; set; }

    [JsonIgnore]
    public string? Description { get; set; }

    [JsonIgnore]
    public CourseRating Rating { get; set; }

    [JsonIgnore]
    public Thread? Thread { get; set; }
}