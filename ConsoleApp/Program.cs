using MacMickey.Dal;
using System;
using System.Linq;

namespace MacMickey.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MacContext ctx = new MacContext())
            {
                ctx.Initialize(dropAlways: true);

                foreach (var burger in ctx.Burgers.ToList())
                {
                    Console.WriteLine(burger.Name);
                }

                Console.WriteLine("-----------");

                // NOT WORKING with RESTRICT ! 
                //(it's deny to delete a burger before the menu associate to the burger)

                //var brg = ctx.Burgers.Single(b => b.Name == "720");
                //ctx.Burgers.Remove(brg);

                //ctx.SaveChanges();

                //var m = ctx.Menus.First();
                //ctx.Menus.Remove(m);

                //ctx.SaveChanges();

                //foreach (var burger in ctx.Burgers.ToList())
                //{
                //    Console.WriteLine(burger.Name);
                //}

                //WORKING !
                var m = ctx.Menus.First();
                ctx.Menus.Remove(m);

                ctx.SaveChanges();

                var brg = ctx.Burgers.Single(b => b.Name == "720");
                ctx.Burgers.Remove(brg);

                ctx.SaveChanges();

                foreach (var burger in ctx.Burgers.ToList())
                {
                    Console.WriteLine(burger.Name);
                }
            }

            Console.ReadLine();
        }
    }
}
