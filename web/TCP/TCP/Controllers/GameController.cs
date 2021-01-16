using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCP.Models;

namespace TCP.Controllers
{
    
    public class GameController : Controller
    {

        private readonly UserContext _context;

        public GameController(UserContext context)
        {
            _context = context;
        }


        // GET: GameController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Game()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CurUser()
        {
            string Data = Request.Form.FirstOrDefault(e => e.Value == _context.Users.FirstOrDefault().Id.ToString()).Value;
            _context.Users.FirstOrDefault().Highscore = int.Parse(Data);
            return Content(
                _context.Users.FirstOrDefault().Highscore.ToString()
                );
        }

        // GET: Game/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Game/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Game/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
