using Timelive.Domain.Enums;

namespace Timelive.Domain.Entities;

public class Story : Entity
{
    public int? ParentId { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }
    public ContentType ContentType { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public bool IsSubscribeNeed { get; set; } = false;
    public bool IsPublished { get; set; } = false;
    public bool IsPurchaseNeed { get; set; } = false;
    public int TopicId { get; set; }
    public int? WriterGroupId { get; set; }
    public int WriterId { get; set; }
    public IEnumerable<Like>? Likes { get; set; }
    public IEnumerable<PurchasedStory>? PurchasedStories { get; set; }
    public Group? WriterGroup { get; set; }
    public Story? ParentStory { get; set; }
    public Profile? Writer { get; set; }
    public Topic? Topic { get; set; }
    public ICollection<Image>? Images { get; set; }
}