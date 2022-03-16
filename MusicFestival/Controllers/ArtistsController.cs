using System.Collections.Generic;

namespace MusicFestival.Models
{
  public class Artist
  {
    public Artist()
    {
      this.JoinEntities = new HashSet<StageArtist>();
    }

    public int ArtistId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<StageArtist> JoinEntities { get; }
  }
}