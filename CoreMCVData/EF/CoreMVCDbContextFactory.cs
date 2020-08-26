using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoreMCVData.EF
{
    public class CoreMVCDbContextFactory : IDesignTimeDbContextFactory<CoreMVCDbContext>
    {
        public CoreMVCDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuration.GetConnectionString("CoreMVCSolutionDb");

            var optionsBuilder = new DbContextOptionsBuilder<CoreMVCDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new CoreMVCDbContext(optionsBuilder.Options);
        }
    }
}
