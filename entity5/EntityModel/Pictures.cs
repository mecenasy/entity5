using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace entity5.EntityModel
{
    [Table("Pictures")]
    public class Pictures
    {
        [Column("Pictures_ID")]
        public int PicturesId { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Pictures")]
        public byte[] Pict { get; set; }

        public virtual Person Person { get; set; }
    }
}