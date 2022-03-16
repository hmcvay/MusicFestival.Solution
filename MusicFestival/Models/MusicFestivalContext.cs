using Microsoft.EntityFrameworkCore;

namespace MusicFestival.Models
{
  public class MusicFestivalContext : DbContext
  {
    public DbSet<Stage> Stages { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<StageArtist> StageArtist { get; set; }
    public MusicFestivalContext(DbContextOptions options) : base(options) { }
    protected override void OnConfiguration(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}