using Microsoft.EntityFrameworkCore;
using ChefDish.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Monsters.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }
     
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllChefs = _context.Chefs
                .Include(x => x.Dishes)
                .ToList();
            return View("Index");
        }

        [HttpGet("new")]
        public IActionResult CreateChef()
        {
            return View("CreateChef");
        }

        [HttpPost("new")]
        public IActionResult CreateChef(Chef FromForm)
        {
            _context.Add(FromForm);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet("/dishes")]
        public IActionResult AllDishes()
        {
            ViewBag.AllDishes = _context.Dishes
                .Include(x => x.Chefs)
                .ToList();
            return View("Dishes");
        }

        [HttpGet("dishes/new")]
        public IActionResult CreateDish()
        {
            return View("CreateDish");
        }

        [HttpPost("dishes/new")]
        public IActionResult CreateDish(Dish FromForm)
        {
            _context.Add(FromForm);
            _context.SaveChanges();
            return RedirectToAction("CreateDish");
        }

    }
 }