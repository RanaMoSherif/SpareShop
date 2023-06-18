namespace BestAuto.Domain.Entities
{
    public sealed class OrderHeader : IDbModel<Guid>
    {
        public OrderHeader()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        [ForeignKey("UserId")] public User User { get; set; } = new User();
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public double OrderTotal { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public string TrackingNumber { get; set; } = string.Empty;
        public string Carrier { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public DateTime PaymentDueDate { get; set; }

        public string SessionId { get; set; } = string.Empty;
        public string PaymentIntentId { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string StreetAddress { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string State { get; set; } = string.Empty;

        [Required]
        public string PostalCode { get; set; }=string.Empty;

    }
}