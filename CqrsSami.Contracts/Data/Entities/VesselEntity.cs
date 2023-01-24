namespace CqrsSami.Contracts.Data.Entities
{
    public class VesselEntity
    {
        public string name { get; set; }

        public List<VesselPositionsEntity> positions { get; set; }
    }

    public class VesselPositionsEntity
    {
        public int x { get; set; }
        public int y { get; set; }
        public DateTime timestamp { get; set; }
    }
}