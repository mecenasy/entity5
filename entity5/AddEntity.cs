using entity5.EntityModel;

namespace entity5
{
    public class AddEntity
    {

        public static Person Add()
        {
            var p = new Person
            {
                Name = "Marcin",
                Surname = "Gajda"
            };
            p.Add_Mail();
            p.Add_Phone();
            p.Add_Adress();
            p.Add_Birth();
            p.Add_Education();
            p.Add_Pictures();
            p.Education[0].Add_Phone();
            p.Education[0].Add_Mail();
            p.Education[0].Add_Adress();
            return p;
        }
    }
}
