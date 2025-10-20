namespace CleanCity.Models
{
    public class LocationEntry
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public long? OsmId { get; set; }
        public OsmType? OsmType { get; set; }       // N = Node, W = Way, R = Relation
        public string? Class { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? DisplayName { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? ZoneName { get; set; }
        public LocationCategory? Category { get; set; }       // e.g. GarbageBin, DumpingSite
        public ConditionStatus? ConditionStatus { get; set; } // e.g. Clean, Dirty, Damaged
        public string? Remarks { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
    }

    public enum OsmType
    {
        N, // Node
        W, // Way
        R  // Relation
    }

    public enum LocationCategory
    {
        GarbageBin,
        DumpingSite,
        WasteCollectionPoint,
        RecyclingCenter,
        CompostBin,
        PublicToilet,
        WaterDrain,
        ParkArea
    }

    public enum ConditionStatus
    {
        Clean,
        Dirty,
        Damaged,
        UnderMaintenance,
        Inactive
    }
}
