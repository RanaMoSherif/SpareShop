

namespace SpareShop.Domain.Entities;
    public class CreditCard : IDbModel<Guid>
{
        public Guid Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string Ccv { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        [ForeignKey("UserId")] public virtual User User { get; set; } = new User();
    }
