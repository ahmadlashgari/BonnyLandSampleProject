using Nest;
using System;

namespace BL.Sample.Domain.Entities
{
    [ElasticsearchType(RelationName = "books", IdProperty = nameof(Id))]
    public class ElasticEntity
    {
        public ElasticEntity()
        {
            if (Id == Guid.Empty)
            {
                Id = Guid.NewGuid();
            }
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
