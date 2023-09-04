
namespace Helper
{
    public class Page<TEntity> where TEntity : IEntity
    {
        public int? Offset { get; set; }

        public int? Limit { get; set; }

        public List<TEntity> Items { get; set; } = null;


        public int Total { get; set; }
    }
}
