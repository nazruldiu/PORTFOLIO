using PORTFOLIO.BDEntity;
using PORTFOLIO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PORTFOLIO.Controllers
{
    public class HomeController : Controller
    {
        DBEntities db = new DBEntities();
        public ActionResult Index()
        {
            UserViewModel model = new UserViewModel();
            var list = db.Users.ToList();
            List<UserViewModel> TempList = new List<UserViewModel>();

            foreach (var item in list)
            {
                var obj = new UserViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description
                };
                TempList.Add(obj);
            }
            model.UserList = TempList;
            return View(model);
        }

        public ActionResult Create()
        {
            UserViewModel model = new UserViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = GetReadyModel(model);
                user.DateCreated = DateTime.Now;

                db.Users.Add(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            UserViewModel model = new UserViewModel();
            var user = db.Users.Find(Id);

            model.Id = user.Id;
            model.Name = user.Name;
            model.Description = user.Description;
            model.DateCreated = user.DateCreated;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = GetReadyModel(model);
                user.Id = model.Id;
                user.DateCreated = model.DateCreated;
                user.DateUpdated = DateTime.Now;

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            User user = db.Users.Find(Id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public User GetReadyModel(UserViewModel model)
        {
            User user = new User();
            user.Name = model.Name;
            user.Description = model.Description;
            return user;
        }
    }
}