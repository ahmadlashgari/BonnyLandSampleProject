using BL.Framework.Persistence.MongoDB;
using MongoDB.Bson.Serialization.Attributes;

namespace BL.Sample.Domain.Entities
{
    public class MongoEntity : EntityCoreBase, IAggregateRoot
    {
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
