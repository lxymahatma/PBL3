namespace EduPath.Models;

public sealed class Post
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public int PostId { get; set; }
    public static DateTime CreationTime => DateTime.Now;
    public User? Creator { get; set; }
    public int UpvoteCount { get; set; }
    public int DownvoteCount { get; set; }
}