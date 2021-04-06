using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using To_Do_App.Models;

namespace To_Do_App.Interfaces
{
    public interface IToDoRepository<TEntity> where TEntity : BaseModel
    {
        List<TEntity> GetAll();
        TEntity GetById(string id);
        void Add(TEntity model);
        void Remove(string id);
        void Update(TEntity model, string id);
    }
}