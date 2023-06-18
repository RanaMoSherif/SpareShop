namespace BestAuto.Domain.Entities
{
    public class Review : IDbModel<Guid>
    {
        public Guid Id { get; set; }

        [Range(1, 5)]
        [Required]
        public double Rate { get; set; }

        public string Comment { get; set; }=string.Empty;
        public DateTime AddedDateTime { get; set; } = DateTime.Now;
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = new Product();

        public Guid UserId { get; set; }
        public virtual User User { get; set; } = new User();
    }
}