namespace PBL3.Models;

public sealed class Thread
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int ThreadId { get; set; }
    public DateTime CreationTime => DateTime.Now;
    public User Creator { get; set; }
    public Post[] Posts { get; set; }
}