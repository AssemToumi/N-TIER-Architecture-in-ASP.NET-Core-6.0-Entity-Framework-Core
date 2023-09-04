using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using WholesBrew.Model.Abstractions;

namespace WholesBrew.Model.Entities;

[Table("WB_BEER")]
public class BeerEntity : AbstractWholesBrewBaseEntity
{
    [Column("BREWER_ID")]
    public int BrewerId { get; set; }

    [Column("NAME")]
    public string Name { get; set; } = null!;

    [Column("ALCOHOL_CONTENT")]
    public string AlcoholContent { get; set; } = null!;

    [Column("PRICE")]
    public decimal Price { get; set; }

    [Column("QUANTITY")]
    public int Quantity { get; set; }

    [ForeignKey(nameof(BrewerId))]
    public virtual BrewerEntity Brewer { get; set; } = null!;
}

