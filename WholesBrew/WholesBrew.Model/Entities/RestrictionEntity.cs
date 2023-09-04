using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholesBrew.Model.Abstractions;

namespace WholesBrew.Model.Entities
{
    [Table("WB_RESTRICTION")]
    public class RestrictionEntity : AbstractWholesBrewBaseEntity
    {
        [Column("WHOLESALER_ID")]
        public int WholesalerId { get; set; }

        [Column("BEER_ID")]
        public int BeerId { get; set; }

        [Column("MAX_QUANTITY")]
        public int MaxQuantity { get; set; }

        [ForeignKey(nameof(WholesalerId))]
        public virtual WholesalerEntity Wholesaler { get; set; } = null!;

        [ForeignKey(nameof(BeerId))]
        public virtual BeerEntity Beer { get; set; } = null!;
    }
}
