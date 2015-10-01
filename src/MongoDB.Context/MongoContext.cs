using System;
using System.Collections.Concurrent;
using MongoDB.Driver;

namespace MongoDB.Context
{
    public abstract class MongoCqrsContext
    {
        private readonly ConcurrentDictionary<Type, object> _mongoCollections;
        private readonly IMongoDatabase _database;

        public MongoCqrsContext(IMongoDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException("database");
            }

            _database = database;
            _mongoCollections = new ConcurrentDictionary<Type, object>();
        }

        protected IMongoCollection<TEntity> InitializeCollection<TEntity>(string collectionName)
        {
            if (collectionName == null)
            {
                throw new ArgumentNullException("collectionName");
            }

            return (IMongoCollection<TEntity>)_mongoCollections.GetOrAdd(typeof(TEntity), k => _database.GetCollection<TEntity>(collectionName));
        }
    }
}