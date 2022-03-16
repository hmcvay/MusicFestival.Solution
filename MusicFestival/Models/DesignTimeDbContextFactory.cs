using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CdOrganizer.Models
{
  public class CdOrganizerContextFactory : IDesignTimeDbContextFactory<CdOrganizerContext>
  {

    CdOrganizerContext IDesignTimeDbContextFactory<CdOrganizerContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<CdOrganizerContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new CdOrganizerContext(builder.Options);
    }
  }
}