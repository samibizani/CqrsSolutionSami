using AutoMapper;
using CqrsSami.Contracts.Data;
using CqrsSami.Contracts.Data.Entities;
using CqrsSami.Core.Manage;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Linq;
using WebApplicationGIS.Domain.Models;

namespace CqrsSami.Providers.Handlers.Queries
{
    public class GetAllVesselsQuery : IRequest<IEnumerable<VesselDTO>>
    {
    }

    public class GetAllVesselsQueryHandlerHandler : IRequestHandler<GetAllVesselsQuery, IEnumerable<VesselDTO>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public GetAllVesselsQueryHandlerHandler(IUnitOfWork repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<IEnumerable<VesselDTO>> Handle(GetAllVesselsQuery request, CancellationToken cancellationToken)
        {
            string filePath = _configuration.GetConnectionString("FileDataPath");
            var entities = await Task.FromResult(_repository.Vessels.GetAllVessels(filePath));
            
            var vessels = _mapper.Map<List<VesselDTO>>(entities);
            VesselManage.ManageSpeedDistanceVessels(ref vessels);
            
            return vessels;
        }
    }
}