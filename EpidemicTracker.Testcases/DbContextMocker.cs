using EpidemicTracker.Api.Controllers;
using EpidemicTracker.data.Models;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Text;

namespace EpidemicTracker.Testcases
{
    public static class DbContextMocker
    {
        public static EpidemicTrackerContext InitializeDbContext()
        {
            var options = new DbContextOptionsBuilder<EpidemicTrackerContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new EpidemicTrackerContext(options);
            DbContextExtensions.Seed(context);
            context.SaveChanges();
            return context;

        }
        public static ILogger<PatientController> InitializeLogger()
        {
            return Substitute.For<ILogger<PatientController>>();
        }
    }
}
