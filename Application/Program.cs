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
                    Create.CreateData();
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
                    }
                    else if (choice == 1)
                    {
                        Read.ReadDNextOfKin(db);
                    }
                    else if (choice == 2)
                    {
                        Read.ReadDCounselor(db);
                    }
                    else
                    {
                        Read.ReadDCabin(db);
                    }
                }
                else if (option == 2)
                {
                    Update.UpdateData();
                }
                else if (option == 3)
                {
                    Delete.DeleteData();
                }
                else
                {
                    done = true;
                }
            }

        }
    }
}