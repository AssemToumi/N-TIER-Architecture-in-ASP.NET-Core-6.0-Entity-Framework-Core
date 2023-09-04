using System.ComponentModel.DataAnnotations.Schema;
using WholesBrew.Model.Abstractions;

namespace WholesBrew.Model.Entities
{
    [Table("QUOTE_RESPONSE")]
    public class QuoteRequestEntity : AbstractWholesBrewBaseEntity
    {
        [Column("ORDER_BEERS")]
        public List<BeerEntity>? OrderBeers { get; set; }

        [Column("WHOLESALER_ID")]
        public int WholesalerId { get; set; }

        [ForeignKey(nameof(WholesalerId))]
        public virtual WholesalerEntity Wholesaler { get; set; } = null!;
    }
}

