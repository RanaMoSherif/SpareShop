namespace SpareShop.Domain.Entities
{
    public interface IDbModel
    {

    }

    public interface IDbModel<TPrimaryKey> : IDbModel
    {
        public TPrimaryKey Id { get; }
    }
}

