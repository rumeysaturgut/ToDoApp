using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using To_Do_App.Interfaces;
using To_Do_App.Models;

namespace To_Do_App.Repositories
{
    public class MongoDbRepository<TEntity> : IToDoRepository<TEntity> where TEntity : BaseModel
    {
        MongoDBContext _dBContext;
        private IMongoCollection<TEntity> col;

        public MongoDbRepository() 
        {
            _dBContext = new MongoDBContext();
            col = _dBContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public MongoDbRepository(MongoDBContext dbContext)
        {
            _dBContext = dbContext;
            col = _dBContext.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public List<TEntity> GetAll()
        {
            return col.Find(new BsonDocument()).ToList();
        }

        public TEntity GetById(string id)
        {
            if(!ObjectId.TryParse(id, out var objectId))
            {
                throw new Exception($"{nameof(objectId)} is not valid");
            }
            var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
            return col.Find(filter).FirstOrDefault();
        }

        public void Add(TEntity model)
        {
            col.InsertOne(model);
        }

        public void Remove(string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                throw new Exception($"{nameof(objectId)} is not valid");
            }
            var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
            col.DeleteOne(filter);
        }

        public void Update(TEntity model, string id)
        {
            if (!ObjectId.TryParse(id, out var objectId))
            {
                throw new Exception($"{nameof(objectId)} is not valid");
            }
            var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
            col.ReplaceOne(filter, model);
        }

    }
}