namespace MusicFestival.Models
{
  public class StageArtist
  {
    public int StageArtistId { get; set; }
    public int ArtistId { get; set; }
    public int StageId { get; set; }
    public virtual Artist Artist { get; set; }
    public virtual Stage Stage { get; set; }
    
  }
}