using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Helper;
using WholesBrew.Model.Entities;

namespace WholesBrew.Model.Abstractions;

public abstract class AbstractWholesBrewBaseEntity : IIdentifiable<int>, ITrackable, IByOptimisticLockProtected
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CREATOR_ID")]
    public long CreatorId { get; set; }

    [Column("CREATION_DATE")]
    public DateTime CreationDate { get; set; }

    [Column("MODIFICATOR_ID")]
    public long ModificatorId { get; set; }

    [Column("MODIFICATION_DATE")]
    public DateTime ModificationDate { get; set; }

    [ConcurrencyCheck]
    [Column("ROW_VERSION")]
    public int RowVersion { get; set; }

    //[ForeignKey(nameof(CreatorId))]
    //public virtual UserEntity CreatorUser { get; set; }

    //[ForeignKey(nameof(ModificatorId))]
    //public virtual UserEntity ModificatorUser { get; set; }
}
