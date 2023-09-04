namespace Helper
{
    public interface IIdentifiable<TKey> : IEntity
    {
        TKey Id { get; set; }
    }
}

