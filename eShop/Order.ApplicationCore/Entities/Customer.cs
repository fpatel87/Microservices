using OrderMicroservice.ApplicationCore.Entities;

namespace OrderMicroservice.ApplicationCore.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Gender { get; set; }

        public string? Phone { get; set; }

        public string? Profile_PIC { get; set; }

        public string? Type { get; set; }

        public int? UserId { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; }
            = new List<UserAddress>();

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
            = new List<ShoppingCart>();

        public ICollection<Order> Orders { get; set; }
            = new List<Order>();
    }
}