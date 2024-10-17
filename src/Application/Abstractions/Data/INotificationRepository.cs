using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Notification;

namespace Application.Abstractions.Data;
public interface INotificationRepository : IRepository<Notification, Guid>
{
}

