namespace PBL3.Models;

public class User
{
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public int? StudentId { get; set; }
    public bool IsAdmin => Email is not null && Email.EndsWith("fc.ritsumei.ac.jp");

    public void CopyFrom(User user)
    {
        UserName = user.UserName;
        Password = user.Password;
        Email = user.Email;
    }
}