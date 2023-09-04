using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholesBrew.Model.Abstractions;

namespace WholesBrew.Model.Entities
{
    [Table("WB_BREWER")]
    public class BrewerEntity : AbstractWholesBrewBaseEntity
    {
        [Column("NAME")]
        public string Name { get; set; }
    }
}
