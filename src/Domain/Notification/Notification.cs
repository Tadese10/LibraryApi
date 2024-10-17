using SharedKernel;

namespace Domain.Notification;

public sealed class Notification : Entity
{
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime? NotifiedAt { get; set; }

}
