using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MusicFestival.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicFestival.Controllers
{
  public class ArtistsController : Controller
  {
    private readonly MusicFestivalContext _db;
    public ArtistsController(MusicFestivalContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Artist> model = _db.Artists.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.StageId = new SelectList(_db.Stages, "StageId", "Description");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Artist artist, int StageId)
    {
      _db.Artists.Add(artist);
      _db.SaveChanges();
      if (StageId != 0)
      {
        _db.StageArtist.Add(new StageArtist() { StageId = StageId, ArtistId = artist.ArtistId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
  }
}