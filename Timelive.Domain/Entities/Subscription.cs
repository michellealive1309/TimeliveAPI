using Timelive.Domain.Enums;

namespace Timelive.Domain.Entities;

public class Subscription : Entity
{
    public SubscriptionType Type { get; set; }
    public int TargetId { get; set; }
    public int ProfileId { get; set; }
}
