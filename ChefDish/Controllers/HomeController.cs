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
            if(ModelState.IsValid)
            {
                _context.Add(FromForm);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("CreateChef");
            }
        }
        
        [HttpGet("dishes")]
        public IActionResult AllDishes()
        {
            var AllDishes = _context.Dishes
                .Include(x => x.Chef)
                .ToList();
            return View("Dishes", AllDishes);
        }

        [HttpGet("dishes/new")]
        public IActionResult CreateDish()
        {
            ViewBag.AllChefs = _context.Chefs
                .Include(x => x.Dishes)
                .ToList();
            return View("CreateDish");
        }

        [HttpPost("dishes/new")]
        public IActionResult CreateDish(Dish FromForm)
        {
            if(ModelState.IsValid)
            {
                _context.Add(FromForm);
                _context.SaveChanges();
                return RedirectToAction("AllDishes");
            }
            else
            {
                ViewBag.AllChefs = _context.Chefs
                    .Include(x => x.Dishes)
                    .ToList();
                return View("CreateDish");
            }
            
        }

    }
 }