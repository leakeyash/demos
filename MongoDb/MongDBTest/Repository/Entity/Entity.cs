using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Repository.Interfaces;

namespace Repository.Entity
{
    public class Entity<T> : Entity
    {
        public T Content { get; set; }
    }
    [BsonIgnoreExtraElements(Inherited = true)]
    public class Entity:IEntity
    {
        private DateTime _createdOn;

        public Entity()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonElement("_c", Order = 1)]
        public DateTime CreatedOn
        {
            get
            {
                if (_createdOn == null || _createdOn == DateTime.MinValue)
                    _createdOn = ObjectId.CreationTime;
                return _createdOn;
            }
            set => _createdOn = value;
        }

        [BsonElement(Order = 0)]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("_m",Order = 2)]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime ModifiedOn { get; set; }

        public ObjectId ObjectId => ObjectId.Parse(Id);
    }
}
