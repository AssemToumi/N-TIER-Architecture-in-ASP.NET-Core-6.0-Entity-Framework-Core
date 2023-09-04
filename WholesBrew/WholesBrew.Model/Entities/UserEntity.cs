using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Helper;

namespace WholesBrew.Model.Entities
{
    [Table("ENCODER")]
    public class UserEntity : IEntity
    {
        [Key]
        [Required]
        [Column("ENCODERID")]
        public long UserId { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("ENCODER")]
        public string Mnemonic { get; set; } = null!;

        [Column("ENABLED")]
        public bool? IsDeleted { get; set; }

        [MaxLength(30)]
        [Column("LASTNAME")]
        public string? LastName { get; set; }

        [MaxLength(20)]
        [Column("FIRSTNAME")]
        public string? FirstName { get; set; }

        [MaxLength(20)]
        [Column("PHONE")]
        public string? PhoneNumber { get; set; }

        [MaxLength(100)]
        [Column("EMAILADDRESS")]
        public string? EmailAdress { get; set; }

        [MaxLength(15)]
        [Column("UCODE")]
        public string? SafeAccount { get; set; }

        [MaxLength(1)]
        [Column("CREATEUSERSALLOW")]
        public bool? CanCreateUser { get; set; }

        [MaxLength(150)]
        [Column("ACTIVEDIRECTORYLOGIN")]
        public string? ActiveDirectoryLogin { get; set; }
    }
}
