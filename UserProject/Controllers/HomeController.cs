using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace UserProject.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    AddUsersBLL addUsersBLL = new AddUsersBLL();
        //    List<AddUsers> addUsers = addUsersBLL.addUsers().ToList();
        //    return View(addUsers);
        //}

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(AddUsers addUsers)
        //{
        //    AddUsersBLL addUsersBLL = new AddUsersBLL();
        //    var insert = addUsersBLL.CreateUser(addUsers);
        //    return View();
        //}

    }
}