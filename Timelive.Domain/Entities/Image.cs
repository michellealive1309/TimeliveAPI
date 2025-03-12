namespace Timelive.Domain.Entities;

public class Image : Entity
{
    public required string Name { get; set; }
    public required string Extension { get; set; }
    public required string FileName { get; set; }
    public required string Path { get; set; }
    public required string ContentType { get; set; }
    public int? ProfileId { get; set; }
    public int? StoryId { get; set; }
    public int? GroupId { get; set; }
}
