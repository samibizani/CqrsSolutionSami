using CqrsSami.Contracts.Data.Entities;
using CqrsSami.Contracts.Data.Repositories;
using JsonFlatFileDataStore;
using System;
using System.Text.Json;

namespace CqrsSami.Core.Data.Repositories
{
    public class VesselRepository : IVesselRepository
    {
        public List<VesselEntity> GetAllVessels(string pathToJson)
        {
            var store = new DataStore(pathToJson);

            var collection = store.GetCollection<VesselEntity>("vessels");

            var vessels = collection
                                .AsQueryable()
                                .ToList();

            return vessels;
        }
    }
}