namespace ShippingMicroservice.ApplicationCore.DTOs
{
    public class ShippingDetailsRequestModel
    {
        public int OrderId { get; set; }

        public int ShipperId { get; set; }

        public string ShippingStatus { get; set; } = string.Empty;

        public string? TrackingNumber { get; set; }
    }
}