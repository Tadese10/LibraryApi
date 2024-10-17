using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Data;
using Domain.Book;
using Domain.Notification;
using Domain.Users;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class NotificationRepository : Database.MongoDb.MongoRepository<Notification, Guid>, INotificationRepository
{
    public NotificationRepository(IMongoDbContext context, IMongoCollection<Notification> dbSet) : base(context, dbSet)
    {
    }
}
