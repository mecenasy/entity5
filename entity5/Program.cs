using entity5.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace entity5
{
    class Program
    {
        private static void Main(string[] args)
        {
            var t = new Queue<Task>();
            t.Enqueue(Add());
            Console.WriteLine("dodaje");
            t.Enqueue(change());
            Console.WriteLine("zmieniam");
            t.Enqueue(Delete());
            Console.WriteLine("usuwam");

            Task.WaitAll();
            Console.WriteLine("ok");
            Console.Read();
        }

        private static async Task Delete()
        {
            try
            {
                using (var efc = new EfContext())
                {
                    var tmp = efc.Person.Where(e => e.Name == "marcin").FirstOrDefault();

                    efc.Person.Remove(tmp);
                    await efc.SaveChangesAsync();

                    Console.WriteLine("usunołem");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------usuwam---------------");
                Console.WriteLine(ex.ToString());
            }
        }


        private static async Task change()
        {
            try
            {
                using (var efc = new EfContext())
                {
                    efc.Configuration.ProxyCreationEnabled = false;
                    var per = efc.Person.Where(we => we.Name == "Marcin").First();
                    per.Name = "marcin";
                    await efc.SaveChangesAsync();

                    Console.WriteLine("zmieniłem");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------zmieniam---------------");
                Console.WriteLine(ex.ToString());
            }
        }

        private static async Task Add()
        {
            var p = AddEntity.Add();
            try
            {
                using (var efc = new EfContext())
                {
                    efc.Person.Add(p);
                    await efc.SaveChangesAsync();
                    Console.WriteLine("dodałem");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("---------------tworze---------------");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
