using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Do_App.Enumerations;

namespace To_Do_App.Models
{
    public class ToDo : BaseModel
    {
        [BsonElement("taskName")]
        [Required]
        public string TaskName { get; set; }
        [BsonElement("priority")]
        public string Priority { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("isDone")]
        public bool IsDone { get; set; }
    }
}