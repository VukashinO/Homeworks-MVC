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

        public IActionResult Edit(int id)
        {
            var user = _users.Get(id);

            EditUserViewModel editUserViewModel = new EditUserViewModel
            {
                ID = user.ID,
                Name = user.Name,
                Address = user.Address,
                Email = user.Email,
                City = user.City,
                Phone = user.Phone


            };
            return View(editUserViewModel);
        }

        [HttpPost]

        public IActionResult Edit(EditUserViewModel model)
        {
            var user = _users.Get(model.ID);
           if(ModelState.IsValid)
            {
                user.Name = model.Name;
                user.Address = model.Address;
                user.Email = model.Email;
                user.City = model.City;
                _users.Update(user);
                return RedirectToAction("details", user);
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var user = _users.Get(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Delete(EditUserViewModel model)
        {
            var user = _users.Get(model.ID);
            if(user != null)
            {
                _users.Delete(model.ID);
                return RedirectToAction("index");
            }

            return View();
            
        }
    }
}