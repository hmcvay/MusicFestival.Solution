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
    
  }
}