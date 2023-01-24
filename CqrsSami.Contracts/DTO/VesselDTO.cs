namespace WebApplicationGIS.Domain.Models
{
    public class VesselDTO
    {
        public string name { get; set; }

        public List<VesselPositions> positions { get; set; }
    }

    public class VesselPositions
    {
        public int x { get; set; }
        public int y { get; set; }
        public DateTime timestamp { get; set; }

        public float average_speed { get; set; }
        public float distance_traveled { get; set; }
    }
}
