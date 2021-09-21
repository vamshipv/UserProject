using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BLL;
using DALEntityEF;

namespace UserProject.Controllers
{
    public class AddUserEFController : Controller
    {
        public ActionResult Index()
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            List<AddUser> addUsers = addUsersBLL.ListUserEF().ToList();
            return View(addUsers);
        }

        public ActionResult Details(int Id)
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            return View(addUsersBLL.ListUserEF().Find(ur => ur.Id == Id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AddUser addUser)
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            var insert = addUsersBLL.CreateUserEF(addUser);
            if (insert)
            {
                ViewBag.Message = "User Added";
            }
            return RedirectToAction("Create");
        }

        public ActionResult Delete(int Id)
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            return View(addUsersBLL.ListUserEF().Find(ur => ur.Id == Id));
        }

        [HttpPost]
        public ActionResult Delete(int Id, AddUser addUser)
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            try
            {
                if (addUsersBLL.DeleteUserEF(addUser));
                {
                    ViewBag.Messege = "user Deleted";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int Id)
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            return View(addUsersBLL.ListUserEF().Find(ur => ur.Id == Id));
        }

        // POST: AddUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, AddUser addUser)
        {
            AddUsersBLL addUsersBLL = new AddUsersBLL();
            try
            {
                // TODO: Add update logic here
                if (addUsersBLL.UpdateUserEF(addUser))
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
    }
}
