using AutoMapper;
using CqrsSami.Contracts.Data.Entities;
using WebApplicationGIS.Domain.Models;

namespace CqrsSami.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VesselEntity, VesselDTO>();
            CreateMap<VesselPositionsEntity, VesselPositions>();
        }
    }
}
