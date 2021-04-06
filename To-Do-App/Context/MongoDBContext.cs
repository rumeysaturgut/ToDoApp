using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace To_Do_App
{
    public class MongoDBContext
    {
        private MongoClient client;
        private IMongoDatabase db;

        public MongoDBContext()
        {
            client = new MongoClient(ConfigurationManager.AppSettings["MongoDBConn"]);
            db = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBName"]);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string name) 
        {
            return db.GetCollection<TEntity>(name);
        }
    }
}