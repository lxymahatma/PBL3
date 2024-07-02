namespace EduPath.Models;

public class User
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public int? StudentId { get; set; }
    public bool IsStudent => StudentId is not null;

    public void CopyFrom(User user)
    {
        UserName = user.UserName;
        Password = user.Password;
        Email = user.Email;
        StudentId = user.StudentId;
    }
}