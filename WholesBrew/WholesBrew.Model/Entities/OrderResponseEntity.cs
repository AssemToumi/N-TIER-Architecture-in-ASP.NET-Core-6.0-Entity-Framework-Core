using System.ComponentModel.DataAnnotations.Schema;

namespace WholesBrew.Model.Entities
{
    [Table("WB_ORDER_RESPONSE")]
    public class OrderResponseEntity
    {
        [Column("BEER_ID")]
        public int BeerId { get; set; }

        [Column("LABEL")]
        public string? Label { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }

        [Column("UNIT_PRICE")]
        public decimal UnitPrice { get; set; }

        [Column("TOTAL_BEFORE_DISCOUNT")]
        public decimal TotalBeforeDiscount { get; set; }

        [Column("DISCOUNT")]
        public string? Discount { get; set; }

        [Column("TOTAL_AFTER_DISCOUNT")]
        public decimal TotalAfterDiscount { get; set; }

        [ForeignKey(nameof(BeerId))]
        public virtual BeerEntity Beer { get; set; } = null!;
    }
}

