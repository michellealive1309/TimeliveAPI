namespace Timelive.Domain.Entities;

public class Group : Entity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public bool IsApproveNeed { get; set; } = false;
    public int? AvatarId { get; set; }
    public Image? Avatar { get; set; }
    public ICollection<Profile>? Members { get; set; }
    public ICollection<Story>? Stories { get; set; }
}
