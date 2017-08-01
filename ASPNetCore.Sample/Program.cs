using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;

namespace ASPNetCore.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseUrls(new string[] { "http://localhost:5000" })
                    .UseStartup<StartUp>()
                    .Build();

            host.Run();

            //while(true)
            //{
            //    Console.WriteLine("Press Enter to to process...");
            //    Console.ReadKey();
            //    Console.WriteLine("Continue...");
            //    Item.items.Clear();
            //    for(var i =0; i < 1000; i++)
            //    {
            //        Item.items.Add(i, new Item
            //        {
            //            ID = i,
            //            Name = "Name____"
            //        });
            //    }
            //}
        }
    }

    public class Item
    {
        public static Dictionary<int, Item> items = new Dictionary<int, Item>();

        public string Name { get; set; }

        public int ID { get; set; }
    }
}