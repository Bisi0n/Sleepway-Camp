using Microsoft.Identity.Client;
using Sleepway.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application
{
    public class Program
    {
        public static void Main()
        {
            var db = new CampsContext();
            bool done = false;
            while (!done)
            {
                var option = Utilities.ShowMenu("Vad vill du göra?", new[]
                {
                    "Skapa",
                    "Visa",
                    "Ändra",
                    "Radera",
                    "Avsluta"

                });
                Console.Clear();
                if (option == 0)
                {
                    var choice = Utilities.ShowMenu("Skapa: ", new[]
                    {
                        "Gäst",
                        "Släktning",
                        "Personal",
                        "Stuga"
                    });
                    Console.Clear();
                    if(choice == 0)
                    {
                        Create.CreateCamper(db);
                    }
                    else if(choice == 1)
                    {
                        Create.CreateNextOfKin(db);

                    }
                    else if (choice == 2)
                    {
                        Create.CreateCounselor(db);

                    }
                    else
                    {
                        Create.CreateCabin(db);

                    }
                }
                else if (option == 1)
                {
                    var choice = Utilities.ShowMenu("Visa: ", new[]
                    {
                        "Gäster",
                        "Släktningar",
                        "Personal",
                        "Stugor"
                    });
                    Console.Clear();
                    if (choice == 0)
                    {
                        Read.ReadDCamper(db);
                        Console.WriteLine();
                    }
                    else if (choice == 1)
                    {
                        Read.ReadDNextOfKin(db);
                        Console.WriteLine();
                    }
                    else if (choice == 2)
                    {
                        Read.ReadDCounselor(db);
                        Console.WriteLine();
                    }
                    else
                    {
                        Read.ReadDCabin(db);
                        Console.WriteLine();
                    }
                }
                else if (option == 2)
                {
                    var choice = Utilities.ShowMenu("Ändra: ", new[]
                    {
                        "Gäst",
                        "Släktning",
                        "Personal",
                        "Stuga"
                    });
                    Console.Clear();
                    if(choice == 0)
                    {
                        Update.UpdateCamper(db);
                    }
                    else if(choice == 1)
                    {
                        Update.UpdateNextOfKin(db);
                    }
                    else if (choice == 2)
                    {
                        Update.UpdateCounselor(db);
                    }
                    else 
                    {
                        Update.UpdateCabin(db);
                    }
                }
                else if (option == 3)
                {
                    Delete.DeleteData();
                }
                else
                {
                    Console.WriteLine("Kom inte tillbaka!");
                    Console.Beep();
                    Console.Beep();
                    Console.Beep();          
                    Console.Beep();          
                    Console.Beep();
                    done = true;
                }
            }

        }
    }
}