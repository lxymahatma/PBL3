namespace EduPath.Models;

public sealed partial class User : ObservableObject
{
    [JsonPropertyOrder(2)]
    [ObservableProperty]
    private string? _email;

    [JsonPropertyOrder(4)]
    [ObservableProperty]
    private string? _studentId;

    [JsonPropertyOrder(1)]
    [ObservableProperty]
    private string? _userName;

    [JsonPropertyOrder(0)]
    public Guid UserId { get; set; }

    [JsonPropertyOrder(3)]
    public string? Password { get; set; }

    [JsonIgnore]
    public bool IsStudent => StudentId is not null;

    public void CopyFrom(User user)
    {
        UserName = user.UserName;
        Password = user.Password;
        Email = user.Email;
        StudentId = user.StudentId;
    }
}