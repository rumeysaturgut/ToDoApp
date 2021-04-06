using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace To_Do_App.Models
{
    public abstract class BaseModel
    {
        public ObjectId Id { get; set; }
    }
}