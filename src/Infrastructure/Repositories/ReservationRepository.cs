using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Notification;
using Domain.Reservation;
using Domain.Users;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class ReservationRepository : Database.MongoDb.MongoRepository<Reservation, Guid>, Application.Abstractions.Data.IReservationRepository
{
    public ReservationRepository(Application.Abstractions.Data.IMongoDbContext context, IMongoCollection<Reservation> dbSet) : base(context, dbSet)
    {
    }
}
