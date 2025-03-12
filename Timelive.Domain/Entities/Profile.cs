namespace Timelive.Domain.Entities;

public class Profile : Entity
{
    public required string DisplayName { get; set; }
    public string? Email { get; set; }
    public string? Bio { get; set; }
    public string? AvatarId { get; set; }
    public string? UserId { get; set; }
    public Image? Avatar { get; set; }
    public User? User { get; set; }
    public ICollection<Group>? Groups { get; set; }
    public ICollection<Like>? Likes { get; set; }
    public ICollection<Subscription>? Subscriptions { get; set; }
}
