using System.ComponentModel.DataAnnotations.Schema;
using WholesBrew.Model.Abstractions;

namespace WholesBrew.Model.Entities
{
    [Table("QUOTE_RESPONSE")]
    public class QuoteResponseEntity : AbstractWholesBrewBaseEntity
    {
        [Column("SUMMARY")]
        public string Summary { get; set; } = null!;

        [Column("ORDER_RESPONSE_ID")]
        public int OrderResponseId { get; set; }

        [Column("WHOLESALER_ID")]
        public int WholesalerId { get; set; }

        [ForeignKey(nameof(OrderResponseId))]
        public virtual List<OrderResponseEntity> OrderResponses { get; set; } = null!;

        [ForeignKey(nameof(WholesalerId))]
        public virtual WholesalerEntity Wholesaler { get; set; } = null!;
    }
}
