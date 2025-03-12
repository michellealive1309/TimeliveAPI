using Timelive.Domain.Enums;

namespace Timelive.Domain.Entities;

public class PurchasedStory : Entity
{
    public int StoryId { get; set; }
    public int UserId { get; set; }
    public PurchasedType Type { get; set; }
    public DateTime PurchasedDate { get; set; } = DateTime.UtcNow;
    public Story? Story { get; set; }
    public User? User { get; set; }
}
