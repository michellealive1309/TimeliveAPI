using Timelive.Domain.Enums;

namespace Timelive.Domain.Entities;

public class GroupMember
{
    public int GroupId { get; set; }
    public int ProfileId { get; set; }
    public GroupRole Role { get; set; }
    public DateTime JoinDate { get; set; } = DateTime.UtcNow;
    public Group? Group { get; set; }
    public Profile? Profile { get; set; }
}
