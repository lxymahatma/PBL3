using System.Text;

namespace EduPath.Test.Services;

[TestSubject(typeof(SerializationService))]
public class SerializationServiceTest
{
    private const string Json = """
                                {
                                  "CourseId": 31630,
                                  "CourseName": "Physics",
                                  "Lecturer": "SVININ MIKHAIL",
                                  "Classroom": "G1",
                                  "WeekDay": 3,
                                  "Period": 1,
                                  "Semester": "Spring",
                                  "CourseCategory": 0,
                                  "MinimumGrade": "1st Year"
                                }
                                """;

    private readonly CourseInformation _expectedInfo = new()
    {
        Id = 31630,
        Name = "Physics",
        Lecturer = "SVININ MIKHAIL",
        Classroom = "G1",
        Day = WeekDay.Thursday,
        Period = 1,
        Semester = "Spring",
        Category = CourseCategory.Math,
        MinimumGrade = "1st Year"
    };

    private readonly SerializationService _serializationService = new();

    [Fact]
    public void Serialize_ReturnsCorrectJson()
    {
        var result = _serializationService.Serialize(_expectedInfo);
        Assert.Equal(Json, result);
    }

    [Fact]
    public async Task SerializeAsync_ReturnsCorrectJson()
    {
        var result = await _serializationService.SerializeAsync(_expectedInfo);
        Assert.Equal(Json, result);
    }

    [Fact]
    public void Deserialize_ReturnsCorrectCourseInformation()
    {
        var result = _serializationService.Deserialize<CourseInformation>(Json);
        AssertResult(result);
    }

    [Fact]
    public async Task DeserializeAsync_ReturnsCorrectCourseInformation()
    {
        var result = await _serializationService.DeserializeAsync<CourseInformation>(Json);
        AssertResult(result);
    }

    [Fact]
    public async Task DeserializeAsync_Stream_ReturnsCorrectCourseInformation()
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(Json));
        var result = await _serializationService.DeserializeAsync<CourseInformation>(stream);
        AssertResult(result);
    }

    private void AssertResult(CourseInformation? result)
    {
        Assert.NotNull(result);
        Assert.Equal(_expectedInfo.Id, result.Id);
        Assert.Equal(_expectedInfo.Name, result.Name);
        Assert.Equal(_expectedInfo.Lecturer, result.Lecturer);
        Assert.Equal(_expectedInfo.Classroom, result.Classroom);
        Assert.Equal(_expectedInfo.Day, result.Day);
        Assert.Equal(_expectedInfo.Period, result.Period);
        Assert.Equal(_expectedInfo.Semester, result.Semester);
        Assert.Equal(_expectedInfo.Category, result.Category);
        Assert.Equal(_expectedInfo.MinimumGrade, result.MinimumGrade);
    }
}