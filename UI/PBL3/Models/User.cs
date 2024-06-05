namespace PBL3.Models;

public class User
{
    public required string? UserName { get; set; }
    public required string? Password { get; set; }
    public required string? Email { get; set; }
    public bool IsAdmin => Email is not null && Email.EndsWith("fc.ritsumei.ac.jp");
}