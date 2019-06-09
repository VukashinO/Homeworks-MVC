using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaHut.Models.ViewModels;
using PizzaHut.Models.IRepositories;
using PizzaHut.Models;

namespace PizzaHut.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _users;
        public UserController(IUserRepository repository)
        {
            _users = repository;
        }
        public IActionResult Index()
        {
            var model = _users.GetAll();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var user = _users.Get(id);
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();

                user.Name = model.Name;
                user.Email = model.Email;
                user.Address = model.Address;
                user.City = model.City;
                _users.Add(user);
                return RedirectToAction("index");
            }
            return View();
        }
    }
}