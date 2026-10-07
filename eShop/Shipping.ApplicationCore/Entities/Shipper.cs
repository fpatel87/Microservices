using ShippingMicroservice.ApplicationCore.Entities;

namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class Shipper
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? EmailId { get; set; }

        public string? Phone { get; set; }

        public string? ContactPerson { get; set; }

        public ICollection<ShipperRegion> ShipperRegions { get; set; }
            = new List<ShipperRegion>();

        public ICollection<ShippingDetails> ShippingDetails { get; set; }
            = new List<ShippingDetails>();
    }
}