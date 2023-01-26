using Sleepway.Context;
using Sleepway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Update
    {
        public static void UpdateCabin(CampsContext db)
        {
            var cab = db.Cabins.ToList();

            foreach (var c in cab)
            {
                Console.WriteLine($"Stuga {c.CabinId} {c.Name}");

            }

            Console.WriteLine();
            Console.Write("Ange ID: ");
            var cabinId = int.Parse(Console.ReadLine());

            var cabinUpdate = db.Cabins.FirstOrDefault(c => c.CabinId == cabinId);

            if (cabinUpdate != null)
            {
                Console.Write("Namn: ");
                var newName = Console.ReadLine();
                cabinUpdate.Name = newName;

                db.SaveChanges();
                Console.WriteLine("Ändring sparad!");
            }
            else
            {
                Console.WriteLine($"Stuga {cabinId} kunde ej hittas, vänligen försök igen!");
            }


        }
        public static void UpdateCamper(CampsContext db)
        {
            var cam = db.Campers.ToList();

            foreach (var c in cam)
            {
                Console.WriteLine($"Gäst {c.CamperId} {c.FirstName} {c.LastName}");

            }

            Console.WriteLine();
            Console.Write("Ange ID: ");
            var camperId = int.Parse(Console.ReadLine());

            var camperUpdate = db.Campers.FirstOrDefault(c => c.CamperId == camperId);

            //var cabinUpdate = db.Cabins.FirstOrDefault(c => c.CabinId == camperUpdate.CabinId);

            if (camperUpdate != null)
            {
                var option = Utilities.ShowMenu("Vad vill du ändra?", new[]
                {
                    "Förnamn",
                    "Efternamn",
                    "Check in",
                    "Check out",
                    "Koppla till Stuga",
                    "Koppla bort Stuga"
                });
                Console.Clear();
                if (option == 0)
                {
                    Console.Write("Förnamn: ");
                    var firstName = Console.ReadLine();

                    camperUpdate.FirstName = firstName;
                }
                else if (option == 1)
                {
                    Console.Write("Efternamn: ");
                    var lastName = Console.ReadLine();

                    camperUpdate.LastName = lastName;
                }
                else if (option == 2)
                {
                    Console.Write("Check in: ");
                    var checkIn = Console.ReadLine();
                    DateTime startDate = Convert.ToDateTime(checkIn);

                    camperUpdate.StartDate = startDate;
                }
                else if (option == 3)
                {
                    Console.Write("Check out: ");
                    var checkOut = Console.ReadLine();
                    DateTime endDate = Convert.ToDateTime(checkOut);

                    camperUpdate.EndDate = endDate;
                }
                else if (option == 4)
                {
                    if (camperUpdate.CabinId == null)
                    {
                        var cab = db.Cabins.ToList();
                        Console.WriteLine("Stugor: ");

                        foreach (var c in cab)
                        {
                            Console.WriteLine($"{c.CabinId} {c.Name}");

                        }
                        Console.WriteLine();
                        Console.WriteLine("Ange stuga ID du vill koppa till gäst");

                        var cabinId = int.Parse(Console.ReadLine());

                        var cabinUpdate = db.Cabins.FirstOrDefault(c => c.CabinId == cabinId);

                        if (cabinUpdate != null)
                        {
                            camperUpdate.CabinId = cabinId;

                            //Create history for ''connected'' camper
                            var history = new History
                            {
                                FirstName = camperUpdate.FirstName,
                                LastName = camperUpdate.LastName,
                                Arrivals = camperUpdate.StartDate,
                                Departure = camperUpdate.EndDate,
                                Title = "Kopplad gäst"
                            };
                            db.History.Add(history);
                            db.SaveChanges();
                            Console.WriteLine("Ändring sparad!");

                        }
                        else
                        {
                            Console.WriteLine($"Stuga {cabinId} kunde ej hittas, vänligen försök igen!");
                        }
                    }
                }
                else
                {
                    if (camperUpdate.CabinId != null)
                    {

                        //Create history for ''disconnected'' camper
                        var history = new History
                        {
                            FirstName = camperUpdate.FirstName,
                            LastName = camperUpdate.LastName,
                            Arrivals = camperUpdate.StartDate,
                            Departure = camperUpdate.EndDate,
                            Title = "Bortkopplad gäst"
                        };
                        db.History.Add(history);

                        camperUpdate.CabinId = null;
                    }
                    else
                    {
                        Console.WriteLine($"{camperUpdate.FirstName} {camperUpdate.LastName} bor inte i någon stuga!");
                    }
                }
                db.SaveChanges();
                Console.WriteLine("Ändring sparad!");
            }
            else
            {
                Console.WriteLine($"Gäst {camperId} kunde ej hittas, vänligen försök igen");
            }
        }
        public static void UpdateCounselor(CampsContext db)
        {
            var con = db.Counselors.ToList();

            foreach (var c in con)
            {
                Console.WriteLine($"Ledare {c.CounselorId} {c.FirstName} ''{c.NickName} '' {c.LastName}");

            }

            Console.WriteLine();
            Console.Write("Ange ID: ");
            var counselorId = int.Parse(Console.ReadLine());

            var counselorUpdate = db.Counselors.FirstOrDefault(c => c.CounselorId == counselorId);

            if (counselorUpdate != null)
            {
                var option = Utilities.ShowMenu("Vad vill du ändra?", new[]
                {
                    "Förnamn",
                    "Efternamn",
                    "Titel",
                    "Check in",
                    "Check out",
                    "Koppla till Stuga",
                    "Koppla bort Stuga"
                });
                Console.Clear();
                if (option == 0)
                {
                    Console.Write("Förnamn: ");
                    var firstName = Console.ReadLine();

                    counselorUpdate.FirstName = firstName;
                }
                else if (option == 1)
                {
                    Console.Write("Efternamn: ");
                    var lastName = Console.ReadLine();

                    counselorUpdate.LastName = lastName;
                }
                else if (option == 2)
                {
                    Console.Write("Titel: ");
                    var nickName = Console.ReadLine();

                    counselorUpdate.NickName = nickName;
                }
                else if (option == 3)
                {
                    Console.Write("Check in: ");
                    var checkIn = Console.ReadLine();
                    DateTime startDate = Convert.ToDateTime(checkIn);

                    counselorUpdate.StartDate = startDate;
                }
                else if (option == 4)
                {
                    Console.Write("Check out: ");
                    var checkOut = Console.ReadLine();
                    DateTime endDate = Convert.ToDateTime(checkOut);

                    counselorUpdate.EndDate = endDate;
                }
                else if (option == 5)
                {
                    if (counselorUpdate.CabinId == null)
                    {
                        var cab = db.Cabins.ToList();
                        Console.WriteLine("Stugor: ");

                        foreach (var c in cab)
                        {
                            Console.WriteLine($"{c.CabinId} {c.Name}");

                        }
                        Console.WriteLine();
                        Console.WriteLine("Ange stuga ID du vill koppa till lagledare");

                        var cabinId = int.Parse(Console.ReadLine());

                        var cabinUpdate = db.Cabins.FirstOrDefault(c => c.CabinId == cabinId);

                        if (cabinUpdate != null)
                        {
                            counselorUpdate.CabinId = cabinId;

                            //Create history for ''connected'' camper
                            var history = new History
                            {
                                FirstName = counselorUpdate.FirstName,
                                LastName = counselorUpdate.LastName,
                                Arrivals = counselorUpdate.StartDate,
                                Departure = counselorUpdate.EndDate,
                                Title = "Kopplad lagledare"
                            };
                            db.History.Add(history);
                            db.SaveChanges();
                            Console.WriteLine("Ändring sparad!");

                        }
                        else
                        {
                            Console.WriteLine($"Stuga {cabinId} kunde ej hittas, vänligen försök igen!");
                        }
                    }
                }
                else
                {
                    if (counselorUpdate.CabinId != null)
                    {

                        //Create history for ''disconnected'' counselor
                        var history = new History
                        {
                            FirstName = counselorUpdate.FirstName,
                            LastName = counselorUpdate.LastName,
                            Arrivals = counselorUpdate.StartDate,
                            Departure = counselorUpdate.EndDate,
                            Title = "Bortkopplad Lagledare"
                        };
                        db.History.Add(history);

                        counselorUpdate.CabinId = null;
                    }
                    else
                    {
                        Console.WriteLine($"{counselorUpdate.FirstName} {counselorUpdate.LastName} bor inte i någon stuga!");
                    }
                }
                db.SaveChanges();
                Console.WriteLine("Ändring sparad!");
            }
            else
            {
                Console.WriteLine($"Ledare {counselorId} kunde ej hittas, vänligen försök igen");
            }
        }
        public static void UpdateNextOfKin(CampsContext db)
        {
            var next = db.NextOfKins.ToList();

            foreach (var c in next)
            {
                Console.WriteLine($"Släkting {c.NokId} {c.FirstName} {c.LastName} är {c.Relationship} till gäst {c.Camper.CamperId}");

            }

            Console.WriteLine();
            Console.Write("Ange ID: ");
            var nokID = int.Parse(Console.ReadLine());

            var nextOkKinUpdate = db.NextOfKins.FirstOrDefault(c => c.NokId == nokID);

            if (nextOkKinUpdate != null)
            {
                var option = Utilities.ShowMenu("Vad vill du ändra?", new[]
                {
                    "Förnamn",
                    "Efternamn",
                    "Relation"
                });
                Console.Clear();
                if (option == 0)
                {
                    Console.Write("Förnamn");
                    var firstName = Console.ReadLine();

                    nextOkKinUpdate.FirstName = firstName;
                }
                else if (option == 1)
                {
                    Console.Write("Efternamn");
                    var lastName = Console.ReadLine();

                    nextOkKinUpdate.LastName = lastName;
                }
                else
                {
                    Console.Write("Relation");
                    var relation = Console.ReadLine();

                    nextOkKinUpdate.Relationship = relation;
                }
                db.SaveChanges();
                Console.WriteLine("Ändring sparad!");
            }
            else
            {
                Console.WriteLine($"Släktning {nokID} kunde ej hittas, vänligen försök igen");
            }

        }
    }
}
