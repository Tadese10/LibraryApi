using SharedKernel;

namespace Domain.Reservation;

public sealed class Reservation : Entity
{
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public DateTime? NotifiedAt { get; set; }

}
