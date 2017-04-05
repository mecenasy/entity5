using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace entity5.EntityModel
{
    [Table("Person_Adress")]
    public class Adress
    {
        [Key]
        [Column("Adress_ID")]
        public int AdressId { get; set; }

        [Column("Adress_1")]
        [MaxLength(50)]
        public string Adress1 { get; set; }

        [Column("Adress_2")]
        [MaxLength(50)]
        public string Adress2 { get; set; }

        [Column("Number")]
        [MaxLength(10)]
        public string Number { get; set; }

        [Column("Post")]
        [MaxLength(50)]
        public string Post { get; set; }

        [Column("Code_Post")]
        [MaxLength(6)]
        public string CodePost { get; set; }

        [Column("Region")]
        public EnumRegion Region { get; set; }

        [Column("Country")]
        [MaxLength(50)]
        public string Country { get; set; }

        public virtual Person Person { get; set; }
    }
}
