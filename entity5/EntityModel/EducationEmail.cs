using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace entity5.EntityModel
{
    [Table("Education_Email")]
    public class EducationEmail
    {
        [Key]
        [Column("Email_ID")]
        public int EmailId { get; set; }

        [Column("Mail")]
        [MaxLength(50)]
        public string Mail { get; set; }

        [Column("Choise_Mail")]
        public EnumChoise Choise { get; set; }

        public virtual Education Education { get; set; }
    }
}

