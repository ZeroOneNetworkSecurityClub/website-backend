namespace website_backend.Models;

public class Member
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public MemberType Type { get; set; }
    public string Avatar { get; set; } = string.Empty;
    public System.DateTime JoinedAt { get; set; } = System.DateTime.Now;
}

public enum MemberType
{
    Core,
    General
}