using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DockedDotnet.Api
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(Func<T, bool> predicate);
        Task<T> Create(T entity);
        Task Remove(Expression<Func<T,bool>> predicate);
    }
        
    public class Repository<T> : IRepository<T>
    {
        private readonly IMongoCollection<T> _collection;
        
        public Repository(IMongoCollection<T> collection)
        {
            _collection = collection;
        }

        public async Task<IEnumerable<T>> Get()
        {
            var result = await _collection.FindAsync(x => true);
            return result.ToEnumerable();
        }

        public async Task<T> Get(Func<T, bool> predicate)
        {
            var result = await Get();
            return result.LastOrDefault(predicate);
        }

        public async Task<T> Create(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task Remove(Expression<Func<T, bool>> predicate)
        {
            await _collection.DeleteOneAsync(predicate);
        }
    }
}