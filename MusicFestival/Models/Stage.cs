using System.Collections.Generic;

namespace MusicFestival.Models
{
  public class Stage
  {
    public Stage()
    {
      this.JoinEntities = new HashSet<StageArtist>();
    }
    public int StageId {get; set; }
    public string Description { get; set; }
    public virtual ICollection<StageArtist> JoinEntities { get; set; }
  }
}