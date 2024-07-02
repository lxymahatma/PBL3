namespace EduPath.Models;

public sealed class CourseInformation
{
    public const int Credit = 2;

    [JsonPropertyName("CourseId")]
    public int Id { get; set; }

    [JsonPropertyName("CourseName")]
    public string? Name { get; set; }

    [JsonPropertyName("RegistrationType")]
    public string? RegistrationType { get; set; }

    public string? Description { get; set; }

    [JsonPropertyName("CourseCategory")]
    public CourseCategory Category { get; set; }

    [JsonPropertyName("WeekDay")]
    public WeekDay Day { get; set; }

    [JsonPropertyName("Period")]
    public int Period { get; set; }

    [JsonPropertyName("MinimumGrade")]
    public string MinimumGrade { get; set; }

    public CourseRating Rating { get; set; }
    public Thread? Thread { get; set; }
    public CourseInformation[]? Prerequisites { get; set; }
}