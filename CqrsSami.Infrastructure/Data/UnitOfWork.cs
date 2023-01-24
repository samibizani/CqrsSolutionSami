using CqrsSami.Contracts.Data;
using CqrsSami.Contracts.Data.Repositories;
using CqrsSami.Core.Data.Repositories;

namespace CqrsSami.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            
        }

        public IVesselRepository Vessels => new VesselRepository();

    }
}