using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserProject.Controllers
{
    public class AddProjectsController : Controller
    {
        // GET: AddProjects
        public ActionResult Index()
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            List<AddProjects> addProjects = addProjectBLL.addProjects().ToList();
            return View(addProjects);
        }

        public ActionResult Details(int Id)
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            return View(addProjectBLL.addProjects().Find(ur => ur.Id == Id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AddProjects addProject)
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            var insert = addProjectBLL.CreateProject(addProject);
            if (insert)
            {
                ViewBag.Message = "Project Added";
            }
            return RedirectToAction("Create");
        }

        public ActionResult Edit(int Id)
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            return View(addProjectBLL.addProjects().Find(ur => ur.Id == Id));
        }

        // POST: AddProject/Edit/5
        [HttpPost]
        public ActionResult Edit(int Id, AddProjects ap)
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            try
            {
                // TODO: Add update logic here
                if (addProjectBLL.UpdateProject(ap))
                {
                    ViewBag.Message = "Project Updated";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Id)
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            return View(addProjectBLL.addProjects().Find(ur => ur.Id == Id));
        }

        // POST: AddProject/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id, AddProjects ap)
        {
            AddProjectBLL addProjectBLL = new AddProjectBLL();
            try
            {
                // TODO: Add delete logic here
                if (addProjectBLL.DeleteProject(ap))
                {
                    ViewBag.Message = "Project Added";
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