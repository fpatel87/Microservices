namespace ShippingMicroservice.ApplicationCore.DTOs
{
    public class ShippingDetailsResponseModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ShipperId { get; set; }

        public string ShippingStatus { get; set; } = string.Empty;

        public string? TrackingNumber { get; set; }

        public string? ShipperName { get; set; }
    }
}