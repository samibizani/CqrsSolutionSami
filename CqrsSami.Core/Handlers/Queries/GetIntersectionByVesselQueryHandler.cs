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
    public class GetIntersectionByVesselQuery : IRequest<string>
    {
        public string Vessel_name { get; }
        public DateTime Date { get; }

        public GetIntersectionByVesselQuery(string vessel_name, DateTime date)
        {
            Vessel_name = vessel_name;
            Date = date;
        }
    }

    public class GetIntersectionByVesselQueryHandler : IRequestHandler<GetIntersectionByVesselQuery, string>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public GetIntersectionByVesselQueryHandler(IUnitOfWork repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> Handle(GetIntersectionByVesselQuery request, CancellationToken cancellationToken)
        {
            string filePath = _configuration.GetConnectionString("FileDataPath");
            var entities = await Task.FromResult(_repository.Vessels.GetAllVessels(filePath));

            var vessels = _mapper.Map<List<VesselDTO>>(entities);

            string intersection_result = VesselManage.ManageIntersectionByVessel(vessels, request.Vessel_name, request.Date);
            
            return intersection_result;
        }
    }
}