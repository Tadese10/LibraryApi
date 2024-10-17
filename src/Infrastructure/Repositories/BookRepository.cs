using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions.Data;
using Domain.Book;
using Domain.Users;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class BookRepository : Database.MongoDb.MongoRepository<Book, Guid>, IBookRepository
{
    public BookRepository(IMongoDbContext context, IMongoCollection<Book> dbSet) : base(context, dbSet)
    {
    }
}
