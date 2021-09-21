using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEntityEF
{
    public class AddProjectsEFDAL
    {
        private ProjectScreenAppEntities projectScreenAppEntities;

        public AddProjectsEFDAL()
        {
            projectScreenAppEntities = new ProjectScreenAppEntities();
        }

        public bool CreateProjectEF(AddProject objAddProject)
        {
            List<AddProject> lst = new List<AddProject>();
            AddProject addProject = new AddProject()
            {
                ProjectName = objAddProject.ProjectName,
                ProjectStartDate = objAddProject.ProjectStartDate,
                ProjectEndDate = objAddProject.ProjectEndDate,
                ProjectPriority = objAddProject.ProjectPriority,
                EmpId = objAddProject.EmpId
            };
            projectScreenAppEntities.AddProjects.Add(addProject);

            int returnValue = projectScreenAppEntities.SaveChanges();
            if (returnValue > 0)
            {
                return true;
            }
            return false;
        }
        public List<AddProject> GetDataListEF()
        {
            ProjectScreenAppEntities db = new ProjectScreenAppEntities();
            var AddProjectCol = db.DisplayAllProjects();
            var AddProjectItems = from e in AddProjectCol
                               select new AddProject
                               {
                                   ProjectName = e.ProjectName,
                                   ProjectStartDate = e.ProjectStartDate,
                                   ProjectEndDate = e.ProjectEndDate,
                                   ProjectPriority = e.ProjectPriority,
                                   EmpId = e.EmpId
                               };
            List<AddProject> lst = new List<AddProject>(AddProjectItems.ToList());
            return lst;
        }

        public bool DeleteProjectEF(AddProject objAddProject)
        {
            List<AddProject> lst = new List<AddProject>();
            AddProject addProject = new AddProject()
            {
                Id = objAddProject.Id
            };
            projectScreenAppEntities.AddProjects.Attach(addProject);
            projectScreenAppEntities.AddProjects.Remove(addProject);

            int returnValue = projectScreenAppEntities.SaveChanges();
            if (returnValue > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateProjectEF(AddProject objAddProject)
        {
            List<AddProject> lst = new List<AddProject>();
            AddProject addProject = new AddProject()
            {
                Id = objAddProject.Id,
                ProjectName = objAddProject.ProjectName,
                ProjectStartDate = objAddProject.ProjectStartDate,
                ProjectEndDate = objAddProject.ProjectEndDate,
                ProjectPriority = objAddProject.ProjectPriority,
                EmpId = objAddProject.EmpId
            };
            projectScreenAppEntities.AddProjects.Add(addProject);

            int returnValue = projectScreenAppEntities.SaveChanges();
            if (returnValue > 0)
            {
                return true;
            }
            return false;
        }

        public List<AddProject> GetProjectDataListEF()
        {
            ProjectScreenAppEntities db = new ProjectScreenAppEntities();
            var AddProjectCol = db.DisplayAllProjects();
            var AddProjectItems = from e in AddProjectCol
                               select new AddProject
                               {
                                   Id = e.Id,
                                   ProjectName = e.ProjectName,
                                   ProjectStartDate = e.ProjectStartDate,
                                   ProjectEndDate = e.ProjectEndDate,
                                   ProjectPriority = e.ProjectPriority,
                                   EmpId = e.EmpId
                               };
            List<AddProject> lst = new List<AddProject>(AddProjectItems.ToList());
            return lst;
        }
    }
}
