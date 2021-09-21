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
    public class AddProjectEFController : Controller
    {
        public ActionResult Index()
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            List<AddProject> addProjects = addProjectBLL.ListProjectEF().ToList();
            return View(addProjects);
        }

        public ActionResult Details(int Id)
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            return View(addProjectBLL.ListProjectEF().Find(ur => ur.Id == Id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AddProject addProject)
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            var insert = addProjectBLL.CreateProjectEF(addProject);
            if(insert)
            {
                ViewBag.Message = "Project Added";
            }
            return RedirectToAction("Create");
        }

        public ActionResult Delete(int Id)
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            return View(addProjectBLL.ListProjectEF().Find(ur => ur.Id == Id));
        }

        [HttpPost]
        public ActionResult Delete(int Id, AddProject addProject)
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            try
            {
                if (addProjectBLL.DeleteProjectEF(addProject)) ;
                {
                    ViewBag.Messege = "Project Deleted";
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
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            return View(addProjectBLL.ListProjectEF().Find(ur => ur.Id == Id));
        }

        // POST: AddUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, AddProject addProject)
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            try
            {
                // TODO: Add update logic here
                if (addProjectBLL.UpdateProjectEF(addProject))
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
