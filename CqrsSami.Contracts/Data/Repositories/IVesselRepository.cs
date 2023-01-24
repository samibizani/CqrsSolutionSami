using CqrsSami.Contracts.Data.Entities;

namespace CqrsSami.Contracts.Data.Repositories
{
    public interface IVesselRepository
    {
        List<VesselEntity> GetAllVessels(string pathToJson);
    }
}