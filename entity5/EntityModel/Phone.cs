using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace entity5.EntityModel
{
    [Table("Person_Phone")]
    public class Phone
    {
        [Key]
        [Column("Phone_ID")]
        public int PhoneId { get; set; }

        [Column("Phone_Number")]
        public int PhoneNumber { get; set; }

        [Column("Choise_Phone")]
        public EnumChoise Choise { get; set; }

        public virtual Person Person { get; set; }
    }
}
