using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace entity5.EntityModel
{
    [Table ("Person")]
    public class Person
    {
        #region Constractor
        public Person()
        {
            this.Mail = new List<Email>();
            this.Phone = new List<Phone>();
            this.Adress = new List<Adress>();
            this.Education = new List<Education>();

        }
        #endregion

        #region Proportis
        [Key]
        [Column ("Person_ID")]
        public int PersonId { get; set; }
        [Column ("Name")]
        [Required]
        [MaxLength (50)]
        public string Name { get; set; }
        [Column ("Surname")]
        [Required]
        [MaxLength (50)]
        public string Surname { get; set; }
        [Timestamp]
        public byte[] RovVersion { get; set; }


        public virtual IList<Email> Mail { get; set; }
        public virtual IList<Phone> Phone { get; set; }
        public virtual IList<Adress> Adress { get; set; }
        public virtual IList<Education> Education { get; set; }

        public virtual Birth Birth { get; set; }
        public virtual Pictures Pictures { get; set; }

        #endregion

        #region Actions

        public void Add_Adress()
        {
            var tmp = new Adress
            {
                Adress1 = "Modrzewiowa",
                Number = "55b/3",
                CodePost = "32-020",
                Post = "Wieliczka",
                Country = "Polska",
                Region = EnumRegion.malopolskie
            };
            this.Adress.Add(tmp);
        }
        
        public void Remove_Adress(Adress adress)
        {
            this.Adress.Remove(adress);
        }

        public void Add_Mail()
        {
            var tmp = new Email
            {
                Choise = EnumChoise.Private,
                Mail = "mecenasy@gmail.com"
            };
            this.Mail.Add(tmp);
        }

        public void Remove_Mail(Email mail)
        {
            this.Mail.Remove(mail);
        }

        public void Add_Phone()
        {
            var tmp = new Phone
            {
                Choise = EnumChoise.Private,
                PhoneNumber = 608447495
            };
            this.Phone.Add(tmp);
        }
        public void Remove_Phone(Phone phone)
        {
            this.Phone.Remove(phone);
        }

        public void Add_Education()
        {
            var tmp = new Education
            {
                NameOfScool = "Wszib",
                StartEducaton = DateTime.Parse("1978-05-05"),
                EndEducation = DateTime.Parse("1978-05-05")
            };
            Education.Add(tmp);
        }

        public void Remove_Education(Education education)
        {
            this.Education.Remove(education);
        }

        public void Add_Birth()
        {
            var tmp = new Birth
            {
                Place = "Brzesko",
                Date = DateTime.Parse("1978-08-05")
            };
            this.Birth = tmp;
        }

        public void Remove_Birth()
        {
            this.Birth = null;
        }

        public void Add_Pictures()
        {
            var tmp = new Pictures
            {
                Name = "mecenasy@gmail.com"
            };
            this.Pictures = tmp;
        }

        public void Remove_Pictures()
        {
            this.Pictures = null;
        }
        #endregion
    }
}
