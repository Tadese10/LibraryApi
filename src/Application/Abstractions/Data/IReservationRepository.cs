using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Notification;
using Domain.Reservation;
using Domain.Users;

namespace Application.Abstractions.Data;
public interface IReservationRepository : IRepository<Domain.Reservation.Reservation, Guid>
{
}
