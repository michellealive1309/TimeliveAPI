namespace Timelive.Domain.Entities;

public class Like : Entity
{
    public int StoryId { get; set; }
    public int ProfileId { get; set; }
    public DateTime LikeDate { get; set; } = DateTime.UtcNow;
    public Story? Story { get; set; }
    public Profile? Profile { get; set; }
}
