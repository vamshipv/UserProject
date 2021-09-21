using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserProject.Controllers
{
    public class AddUsersController : Controller
    {
        // GET: AddUsers
        public ActionResult Index()
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            List<AddUsers> addUsers = addUsersBLL.addUsers().ToList();
            return View(addUsers);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int Id)
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            return View(addUsersBLL.addUsers().Find(ur => ur.Id == Id));
        }

        [HttpPost]
        public ActionResult Create(AddUsers addUsers)
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            var insert = addUsersBLL.CreateUser(addUsers);
            if (insert)
            {
                ViewBag.Messege = "Project Added";
            }
            return RedirectToAction("Create");
        }
        public ActionResult Edit(int Id)
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            return View(addUsersBLL.addUsers().Find(ur => ur.Id == Id));
        }

        // POST: AddUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, AddUsers au)
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            try
            {
                // TODO: Add update logic here
                if (addUsersBLL.UpdateUser(au))
                {
                    ViewBag.Messege = "Updated Data";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AddUser/Delete/5
        public ActionResult Delete(int Id)
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            return View(addUsersBLL.addUsers().Find(ur => ur.Id == Id));
        }

        // POST: AddUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id, AddUsers au)
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            try
            {
                // TODO: Add delete logic here
                if (addUsersBLL.DeleteUser(au))
                {
                    ViewBag.Messege = "Deleted Data";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}