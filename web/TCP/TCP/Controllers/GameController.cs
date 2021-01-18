﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TCP.Models;

namespace TCP.Controllers
{
    
    public class GameController : Controller
    {

        private readonly UserManager<User> _userManager;

   

        public GameController(UserManager<User> userManager)
        {
            _userManager = userManager;
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

        [HttpGet]
        public ActionResult<IEnumerable<string>> CurUser()
        {
            string UserName = User.FindFirstValue(ClaimTypes.NameIdentifier);


            return Ok(UserName);
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
    }
}

