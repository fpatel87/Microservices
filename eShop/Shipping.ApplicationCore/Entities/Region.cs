using ShippingMicroservice.ApplicationCore.Entities;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<ShipperRegion> ShipperRegions { get; set; }
            = new List<ShipperRegion>();
    }
}