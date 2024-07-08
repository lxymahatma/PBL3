namespace EduPath.Models;

public sealed partial class User : ObservableObject
{
    [ObservableProperty]
    private string? _email;

    [ObservableProperty]
    private int? _studentId;

    [ObservableProperty]
    private string? _userName;

    public string? Password { get; set; }
    public bool IsStudent => StudentId is not null;

    public void CopyFrom(User user)
    {
        UserName = user.UserName;
        Password = user.Password;
        Email = user.Email;
        StudentId = user.StudentId;
    }
}