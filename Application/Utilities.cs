using Microsoft.EntityFrameworkCore;
using Sleepway.Context;
using Sleepway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application
{
    public class Utilities
    {

        //public static class ModelBuilderExtentions
        //{
        //    public static void Seed(this ModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<Cabin>().HasData(
        //            new Cabin
        //            {
        //                CabinId = 1,
        //                Name = "High Hopes"
        //            },
        //            new Cabin
        //            {
        //                CabinId = 2,
        //                Name = "Golden Valley"
        //            },
        //            new Cabin
        //            {
        //                CabinId = 3,
        //                Name = "Moonlight Ridge"
        //            }
        //        );
        //        modelBuilder.Entity<Camper>().HasData(
        //            new Camper { Id = 1, FirstName = "Brad", LastName = "Pitt" },
        //            new Camper { Id = 2, FirstName = "David", LastName = "Beckham" },
        //            new Camper { Id = 3, FirstName = "Sara", LastName = "Larsson" },
        //            new Camper { Id = 4, FirstName = "Eva", LastName = "Andersson" },
        //            new Camper { Id = 5, FirstName = "Johan", LastName = "Pär" },
        //            new Camper { Id = 6, FirstName = "Zlatan", LastName = "Ibrahimovid" },
        //            new Camper { Id = 7, FirstName = "Lisa", LastName = "Olsson" },
        //            new Camper { Id = 8, FirstName = "Martin", LastName = "Dalberg" },
        //            new Camper { Id = 9, FirstName = "Sandra", LastName = "Österberg" },
        //            new Camper { Id = 10, FirstName = "Annika", LastName = "Svensson" },
        //            new Camper { Id = 11, FirstName = "Peter", LastName = "Parker" },
        //            new Camper { Id = 12, FirstName = "Thierry", LastName = "Henry" },
        //            new Camper { Id = 13, FirstName = "Lionel", LastName = "Messi" },
        //            new Camper { Id = 14, FirstName = "Koby", LastName = "Bryant" },
        //            new Camper { Id = 15, FirstName = "Muhammed", LastName = "Ali" },
        //            new Camper { Id = 16, FirstName = "Pele", LastName = "Nasicmo" },
        //            new Camper { Id = 17, FirstName = "Ronaldo", LastName = "Nazario" },
        //            new Camper { Id = 18, FirstName = "Ronaldinho", LastName = "Gaucho" }
        //            );
        //        modelBuilder.Entity<Counselor>().HasData(
        //            new Counselor { CounselorId = 1, FirstName = "Abdi", LastName = "Mohamed", CabinId = 1 },
        //            new Counselor { CounselorId = 1, FirstName = "Mohammed", LastName = "Jafari", CabinId = 2 },
        //            new Counselor { CounselorId = 1, FirstName = "Peter", LastName = "Nilsson", CabinId = 3 },
        //            new Counselor { CounselorId = 1, FirstName = "Mirella", LastName = "Mårtensson" }
        //            );
        //        modelBuilder.Entity<NextOfKin>().HasData(
        //            new NextOfKin { NokId = 1, FirstName = "Gunnila", LastName = "Strömmer", Relationship = "Faster" },
        //            new NextOfKin { NokId = 2, FirstName = "Herman", LastName = "Hermansson", Relationship = "Far" },
        //            new NextOfKin { NokId = 3, FirstName = "Antonella", LastName = "Roccuzzo", Relationship = "Fru" }
        //            );
        //    }
        //}
        public static int ShowMenu(string prompt, IEnumerable<string> options)
        {
            if (options == null || options.Count() == 0)
            {
                throw new ArgumentException("Cannot show a menu for an empty list of options.");
            }

            Console.WriteLine(prompt);

            // Hide the cursor that will blink after calling ReadKey.
            Console.CursorVisible = false;

            // Calculate the width of the widest option so we can make them all the same width later.
            int width = options.Max(option => option.Length);

            int selected = 0;
            int top = Console.CursorTop;
            for (int i = 0; i < options.Count(); i++)
            {
                // Start by highlighting the first option.
                if (i == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                var option = options.ElementAt(i);
                // Pad every option to make them the same width, so the highlight is equally wide everywhere.
                Console.WriteLine("- " + option.PadRight(width));

                Console.ResetColor();
            }
            Console.CursorLeft = 0;
            Console.CursorTop = top - 1;

            ConsoleKey? key = null;
            while (key != ConsoleKey.Enter)
            {
                key = Console.ReadKey(intercept: true).Key;

                // First restore the previously selected option so it's not highlighted anymore.
                Console.CursorTop = top + selected;
                string oldOption = options.ElementAt(selected);
                Console.Write("- " + oldOption.PadRight(width));
                Console.CursorLeft = 0;
                Console.ResetColor();

                // Then find the new selected option.
                if (key == ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, options.Count() - 1);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                }

                // Finally highlight the new selected option.
                Console.CursorTop = top + selected;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                string newOption = options.ElementAt(selected);
                Console.Write("- " + newOption.PadRight(width));
                Console.CursorLeft = 0;
                // Place the cursor one step above the new selected option so that we can scroll and also see the option above.
                Console.CursorTop = top + selected - 1;
                Console.ResetColor();
            }

            // Afterwards, place the cursor below the menu so we can see whatever comes next.
            Console.CursorTop = top + options.Count();

            // Show the cursor again and return the selected option.
            Console.CursorVisible = true;
            return selected;
        }
    }
}
