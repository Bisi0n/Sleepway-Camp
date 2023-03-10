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
                    "Sök",
                    "Besök",
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
                    if (choice == 0)
                    {
                        Create.CreateCamper(db);
                        Console.WriteLine();
                    }
                    else if (choice == 1)
                    {
                        Create.CreateNextOfKin(db);
                        Console.WriteLine();
                    }
                    else if (choice == 2)
                    {
                        Create.CreateCounselor(db);
                        Console.WriteLine();
                    }
                    else
                    {
                        Create.CreateCabin(db);
                        Console.WriteLine();
                    }
                }
                else if (option == 1)
                {
                    var choice = Utilities.ShowMenu("Visa: ", new[]
                    {
                        "Gäster",
                        "Släktningar",
                        "Personal",
                        "Stugor",
                        "Historik"
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
                    else if (choice == 3)
                    {
                        Read.ReadDCabin(db);
                        Console.WriteLine();
                    }
                    else
                    {
                        Read.ReadHistory(db);
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
                    if (choice == 0)
                    {
                        Update.UpdateCamper(db);
                        Console.WriteLine();
                    }
                    else if (choice == 1)
                    {
                        Update.UpdateNextOfKin(db);
                        Console.WriteLine();
                    }
                    else if (choice == 2)
                    {
                        Update.UpdateCounselor(db);
                        Console.WriteLine();
                    }
                    else
                    {
                        Update.UpdateCabin(db);
                        Console.WriteLine();
                    }
                }
                else if (option == 3)
                {
                    var choice = Utilities.ShowMenu("Radera: ", new[]
                    {
                        "Gäst",
                        "Släktning",
                        "Personal",
                        "Stuga"
                    });
                    Console.Clear();
                    if (choice == 0)
                    {
                        Delete.DeleteCamper(db);
                        Console.WriteLine();
                    }
                    else if (choice == 1)
                    {
                        Delete.DeleteNextOfKin(db);
                        Console.WriteLine();
                    }
                    else if (choice == 2)
                    {
                        Delete.DeleteCounselor(db);
                        Console.WriteLine();
                    }
                    else
                    {
                        Delete.DeleteCabin(db);
                        Console.WriteLine();
                    }
                }
                else if (option == 4)
                {
                    var choice = Utilities.ShowMenu("Sök efter gäster: ", new[]
                    {
                        "Via stuga",
                        "Med släktningar"

                    });
                    Console.Clear();
                    if (choice == 0)
                    {
                        Report.SearchCamper(db);
                        Console.WriteLine();
                    }
                    else
                    {
                        Report.SearchNOK(db);
                        Console.WriteLine();
                    }
                }
                else if (option == 5)
                {
                    var choice = Utilities.ShowMenu("Vill du: ", new[]
                    {
                        "Boka Besök",
                        "Visa Besöka"
                    });
                    Console.Clear();
                    if (choice == 0)
                    {
                        VisitsCheck.AddVisit(db);
                        Console.WriteLine();
                    }
                    else
                    {
                        VisitsCheck.DisplayVisit(db);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Välkommen åter!");
                    done = true;
                }
            }

        }
    }
}