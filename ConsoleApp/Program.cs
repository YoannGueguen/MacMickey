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

                foreach (var menu in ctx.Menus.ToList())
                {
                    Console.WriteLine(menu.Name);
                    Console.WriteLine("Burger = " + menu.Burger.Name);
                    Console.WriteLine("Beverage = " + menu.Beverage.Name);
                    Console.WriteLine("Side = " + menu.Side.Name);
                    Console.WriteLine("Dessert = " + menu.Dessert.Name);
                    Console.WriteLine("-----------");
                }


            }
            Console.ReadLine();
        }
    }
}
