using EpidemicTracker.data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EpidemicTracker.Testcases
{
   public static class DbContextExtensions
    {
        public static void  Seed(this EpidemicTrackerContext context)
        {
            context.Patient.Add(new Patient()
            {
                PatientId = 4009,
                Name="Amrutha",
                Age=14,
                AadharId=9288928882,
                Phone=98788777
                


            });
            context.SaveChanges();
        }
    }
}
