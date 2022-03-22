using BL.Framework.Mapper;
using BL.Sample.ApplicationServices.Common.Models;
using BL.Sample.ApplicationServices.ElasticEntity.Commands.AddElasticEntity;
using BL.Sample.ApplicationServices.ElasticEntity.Commands.UpdateElasticEntity;
using BL.Sample.ApplicationServices.Entity.Commands.AddEntity;
using BL.Sample.ApplicationServices.MongoEntity.Commands.AddMongoEntity;
using Nest;
using ElasticEntityModel = BL.Sample.Domain.Entities.ElasticEntity;
using EntityModel = BL.Sample.Domain.Entities.Entity;
using MongoEntityModel = BL.Sample.Domain.Entities.MongoEntity;

namespace BL.Sample.ApplicationServices.Common.Mapper
{
    public class BonnyLandMapper : MappingProfile
    {
        public BonnyLandMapper()
        {
            CreateMap<EntityModel, EntityDto>().ReverseMap();
            CreateMap<EntityModel, AddEntityCommand>().ReverseMap();

            CreateMap<MongoEntityModel, MongoEntityDto>().ReverseMap();
            CreateMap<MongoEntityModel, AddMongoEntityCommand>().ReverseMap();

            CreateMap<ElasticEntityModel, ElasticEntityDto>().ReverseMap();
            CreateMap<ElasticEntityModel, AddElasticEntityCommand>().ReverseMap();
            CreateMap<ElasticEntityModel, UpdateElasticEntityCommand>().ReverseMap();

            CreateMap<UpdateResponse<ElasticEntityModel>, UpdateResponse<ElasticEntityDto>>().ReverseMap();
        }
    }
}
