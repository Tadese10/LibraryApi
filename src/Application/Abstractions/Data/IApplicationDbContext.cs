using Domain.Book;
using Domain.Notification;
using Domain.Reservation;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace Application.Abstractions.Data;

public interface IApplicationDbContext
{
    IMongoCollection<User> Users { get; }
    IMongoCollection<Book> Books { get; }
    IMongoCollection<Notification> Notifications { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

public interface IApplicationDbContextMongoDb
{
    IMongoCollection<User> Users { get; }
    IMongoCollection<Domain.Reservation.Reservation> Reservations { get; }

    IMongoCollection<Notification> Notifications { get; }

    IMongoCollection<Book> Books { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}

