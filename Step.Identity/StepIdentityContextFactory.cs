using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Step.Identity.Stores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Step.Identity
{
    public class StepIdentityContextFactory : IDesignTimeDbContextFactory<StepIdentityContext>
    {
        public StepIdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StepIdentityContext>();
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseSqlServer(configBuilder.GetConnectionString("DefaultConnection"));
            return new StepIdentityContext(optionsBuilder.Options);
        }
    }
}
