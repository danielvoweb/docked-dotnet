using DockedDotnet.Api.Models;
using MongoDB.Driver;

namespace DockedDotnet.Api
{
    public interface IUnitOfWork
    {
        IRepository<Post> PostsRepository { get; }
    }
    
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IMongoDatabase database)
        {
            PostsRepository = new Repository<Post>(database.GetCollection<Post>("PostsCollection"));
        }
        
        public IRepository<Post> PostsRepository { get; }
    }
}