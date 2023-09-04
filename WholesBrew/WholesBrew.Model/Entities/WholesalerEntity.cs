using System.ComponentModel.DataAnnotations.Schema;
using WholesBrew.Model.Abstractions;

namespace WholesBrew.Model.Entities
{ 
    [Table("WB_WHOLESALER")]
    public class WholesalerEntity : AbstractWholesBrewBaseEntity
    {
        [Column("NAME")]
        public string Name { get; set; }
    }
}

