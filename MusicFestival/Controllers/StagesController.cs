using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MusicFestival.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicFestival.Controllers
{
  public class StagesController : Controller
  {
    private readonly MusicFestivalContext _db;

    public StagesController(MusicFestivalContext db)
    {
        _db = db;
    }

    public ActionResult Index()
    {
        List<Stage> model = _db.Stages.ToList();
        return View(model);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Stage stage)
    {
        _db.Stages.Add(stage);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
        var thisStage = _db.Stages
            .Include(stage => stage.JoinEntities)
            .ThenInclude(join => join.Artist)
            .FirstOrDefault(stage => stage.StageId == id);
        return View(thisStage);
    }

    public ActionResult Edit(int id)
    {
        var thisStage = _db.Stages.FirstOrDefault(stage => stage.StageId == id);
        return View(thisStage);
    }

    [HttpPost]
    public ActionResult Edit(Stage stage)
    {
        _db.Entry(stage).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        var thisStage = _db.Stages.FirstOrDefault(stage => stage.StageId == id);
        return View(thisStage);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        var thisStage = _db.Stages.FirstOrDefault(stages => stages.StageId == id);
        _db.Stages.Remove(thisStage);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteArtist(int joinId)
    {
        var joinEntry = _db.StageArtist.FirstOrDefault(entry => entry.StageArtistId == joinId);
        _db.StageArtist.Remove(joinEntry);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}
