namespace ShippingMicroservice.ApplicationCore.Entities
{
    public class ShipperRegion
    {
        public int RegionId { get; set; }

        public int ShipperId { get; set; }

        public bool Active { get; set; } = true;

        public Region Region { get; set; } = null!;

        public Shipper Shipper { get; set; } = null!;
    }
}