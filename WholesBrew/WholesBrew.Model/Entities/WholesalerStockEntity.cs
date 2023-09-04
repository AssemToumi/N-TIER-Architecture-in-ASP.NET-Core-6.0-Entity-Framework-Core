using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WholesBrew.Model.Abstractions;

namespace WholesBrew.Model.Entities
{
    [Table("WB_WHOLESALER_STOCK")]
    public class WholesalerStockEntity : AbstractWholesBrewBaseEntity
    {
        [Column("WHOLESALER_ID")]
        public int WholesalerId { get; set; }

        [Column("BEER_ID")]
        public int BeerId { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }

        [Column("PRICE")]
        public decimal Price { get; set; }

        [ForeignKey(nameof(WholesalerId))]
        public virtual WholesalerEntity Wholesaler { get; set; } = null!;

        [ForeignKey(nameof(BeerId))]
        public virtual BeerEntity Beer { get; set; } = null!;
    }
}

