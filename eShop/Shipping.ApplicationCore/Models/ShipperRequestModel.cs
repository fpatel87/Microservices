namespace ShippingMicroservice.ApplicationCore.DTOs
{
    public class ShipperRequestModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? EmailId { get; set; }

        public string? Phone { get; set; }

        public string? ContactPerson { get; set; }
    }
}