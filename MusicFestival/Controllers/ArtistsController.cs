using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using MusicFestival.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

    public ActionResult Details(int id)
    {
      var thisArtist = _db.Artists
        .Include(thisArtist => thisArtist.JoinEntities)
        .ThenInclude(join => join.Stage)
        .FirstOrDefault(thisArtist => thisArtist.ArtistId == id);
      return View(thisArtist);
    }

    public ActionResult Edit(int id)
    {
      var thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      ViewBag.StageId = new SelectList(_db.Stages, "StageId", "Description");
      return View(thisArtist);
    }
    [HttpPost]
    public ActionResult Edit(Artist artist, int StageId)
    {
      if(StageId != 0)
      {
        _db.StageArtist.Add(new StageArtist() { StageId = StageId, ArtistId = artist.ArtistId });
      }
      _db.Entry(artist).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete (int id)
    {
      var thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      _db.Artists.Remove(thisArtist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult AddStage(int id)
    {
      var thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      ViewBag.StageId = new SelectList(_db.Stages, "StageId", "Description");
      return View(thisArtist);
    }

    [HttpPost]
    public ActionResult AddStage(Artist artist, int StageId)
    {
      if (StageId != 0)
      {
        _db.StageArtist.Add(new StageArtist() { StageId = StageId, ArtistId = artist.ArtistId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteStage(int joinId)
    {
      var joinEntry = _db.StageArtist.FirstOrDefault(entry => entry.StageArtistId == joinId);
      _db.StageArtist.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}