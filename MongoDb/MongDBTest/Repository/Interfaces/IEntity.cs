using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Repository.Interfaces
{
    public interface IEntity
    {
        DateTime CreatedOn { get; }

        [BsonId]
        string Id { get; set; }

        DateTime ModifiedOn { get; }

        [BsonIgnore]
        ObjectId ObjectId { get; }
    }
}
