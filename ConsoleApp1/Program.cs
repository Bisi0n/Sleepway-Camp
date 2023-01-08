using Sleepway.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            var context = new CampsContext();
            context.Database.EnsureDeleted();
            
            //int option = Utilities.ShowMenu("Please choose one of the following: ", new[]
            //{
            //    ""
            //});


        }
    }
}