using CqrsSami.Contracts.Data.Repositories;

namespace CqrsSami.Contracts.Data
{
    public interface IUnitOfWork
    {
        IVesselRepository Vessels { get; }
    }
}