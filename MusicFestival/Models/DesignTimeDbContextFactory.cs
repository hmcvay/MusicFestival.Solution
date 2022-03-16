using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MusicFestival.Models
{
  public class MusicFestivalContextFactory : IDesignTimeDbContextFactory<MusicFestivalContext>
  {

    MusicFestivalContext IDesignTimeDbContextFactory<MusicFestivalContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<MusicFestivalContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new MusicFestivalContext(builder.Options);
    }
  }
}