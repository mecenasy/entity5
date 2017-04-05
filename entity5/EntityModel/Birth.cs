using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace entity5.EntityModel
{
    [Table("Birth")]
    public class Birth
    {
        [Column("Birth_ID")]
        public int BirthId { get; set; }

        [Column("Place_Of_Birth")]
        [MaxLength(50)]
        public string Place { get; set; }

        [Column("Date_Of_Birth")]
        public DateTime Date { get; set; }

        public virtual Person Person { get; set; }
    }
}
