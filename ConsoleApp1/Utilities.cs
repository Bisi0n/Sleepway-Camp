using Sleepway.Context;
using Sleepway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Utilities
    {
        public static void AddCabin(CampsContext db)
        {
            db.Cabins.AddRange(new[]
                {
                new Cabin() { Name = "High Hopes"},
                new Cabin() { Name = "Golden Valley"},
                new Cabin() { Name = "Moonligh Ridge"},
            });
            db.SaveChanges();
        }

        public static void AddCampers(CampsContext db)
        {
            // 18/3 = 6
            db.Campers.AddRange(new[]
            {
                new Camper() {FirstName = "Brad", LastName = "Pitt", Room = 1},
                new Camper() {FirstName = "David", LastName = "Beckham", Room = 1},
                new Camper() {FirstName = "Sara", LastName = "Larsson", Room = 1},
                new Camper() {FirstName = "Eva", LastName = "Andersson", Room = 1},
                new Camper() {FirstName = "Johan", LastName = "Pär", Room = 1},
                new Camper() {FirstName = "Zlatan", LastName = "Ibrahimovid", Room = 1},
                new Camper() {FirstName = "Lisa", LastName = "Olsson", Room = 2},
                new Camper() {FirstName = "Martin", LastName = "Dalberg", Room = 2},
                new Camper() {FirstName = "Sandra", LastName = "Österberg", Room = 2},
                new Camper() {FirstName = "Annika", LastName = "Svensson", Room = 2},
                new Camper() {FirstName = "Peter", LastName = "Parker", Room = 2},
                new Camper() {FirstName = "Thierry", LastName = "Henry", Room = 2},
                new Camper() {FirstName = "Lionel", LastName = "Messi", Room = 3},
                new Camper() {FirstName = "Koby", LastName = "Bryant", Room = 3},
                new Camper() {FirstName = "Muhammed", LastName = "Ali", Room = 3},
                new Camper() {FirstName = "Pele", LastName = "Nasicmo", Room = 3},
                new Camper() {FirstName = "Ronaldo", LastName = "Nazario", Room = 3},
                new Camper() {FirstName = "Ronaldinho", LastName = "Gaucho", Room = 3}
            });
            db.SaveChanges();
        }

        public static void AddCounselor(CampsContext db)
        {
            db.Counselors.AddRange(new[]
            {
                new Counselor() {FirstName = "Abdi", LastName = "Mohamed"},
                new Counselor() {FirstName = "Mohammed", LastName = "Jafari"},
                new Counselor() {FirstName = "Peter", LastName = "Nilsson"},

            });
            db.SaveChanges();
        }

        public static void AddNextOfKin(CampsContext db)
        {
            db.NextOfKins.AddRange(new[]
            {
                new NextOfKin() {FirstName = "Gunnila", LastName = "Strömmer", Relationship = "Faster"},
                new NextOfKin() {FirstName = "Herman", LastName = "Hermansson", Relationship = "Pappa"},
                new NextOfKin() {FirstName = "Antonella", LastName = "Roccuzzo", Relationship = "Fru"}
            });
            db.SaveChanges();
        }




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
