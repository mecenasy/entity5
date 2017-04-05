using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace entity5.EntityModel
{
    [Table ("Education")]
    public class Education
    {
        public Education()
        {
            this.Mail = new List<EducationEmail>();
            this.Phone = new List<EducationPhone>();
        }

        [Key]
        [Column("Education_ID")]
        public int EducationId { get; set; }

        [Column("Name")]
        [MaxLength(50)]
        public string NameOfScool { get; set; }

        [Column("Start")]
        public DateTime StartEducaton { get; set; }

        [Column("End")]
        public DateTime EndEducation { get; set; }

        public virtual Person Person { get; set; }
        public virtual EducationAdress Adress { get; set; }

        public virtual IList<EducationEmail> Mail { get; set; }
        public virtual IList<EducationPhone> Phone { get; set; }

        public void Add_Adress()
        {
            var tmp = new EducationAdress
            {
                Adress1 = "Modrzewiowa",
                Number = "55b/3",
                CodePost = "32-020",
                Post = "Wieliczka",
                Country = "Polska",
                Region = EnumRegion.malopolskie
            };
            Adress = tmp;
        }

        public void Remove_Adress(Adress adress)
        {
            Adress = null;
        }

        public void Add_Mail()
        {
            var tmp = new EducationEmail
            {
                Choise = EnumChoise.Private,
                Mail = "mecenasy@gmail.com"
            };
            Mail.Add(tmp);
        }

        public void Remove_Mail(EducationEmail mail)
        {
            Mail.Remove(mail);
        }

        public void Add_Phone()
        {
            var tmp = new EducationPhone
            {
                Choise = EnumChoise.Private,
                PhoneNumber = 123456789
            };
            Phone.Add(tmp);
        }

        public void Remove_Phone(EducationPhone mail)
        {
            Phone.Remove(mail);
        }
    }
}
