using DAL;
using DALEntityEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AddProjectBLL
    {
        // List all Projects
        public List<AddProjects> addProjects()
        {
            AddProjectsDAL addUsersDAL = new AddProjectsDAL();
            var lstProjects = addUsersDAL.GetProjectList();
            return lstProjects;
        }

        // Create Project
        public bool CreateProject(AddProjects addProject)
        {
            return new AddProjectsDAL().CreateProject(addProject);
        }

        //Delete Project
        public bool DeleteProject(AddProjects addProjects)
        {
            return new AddProjectsDAL().DeleteProject(addProjects);
        }

        //Update Project
        public bool UpdateProject(AddProjects addProjects)
        {
            return new AddProjectsDAL().UpdateProject(addProjects);
        }



        //-----------------------------------------------------------------------------------------------
        //DALEntityEF

        // List All Project In DALEF
        public List<AddProject> ListProjectEF()
        {
            AddProjectsEFDAL addProjectsEFDAL = new AddProjectsEFDAL();
            var lstAddUsersEF = addProjectsEFDAL.GetProjectDataListEF();
            return lstAddUsersEF;
        }

        // Create In DALEF
        public bool CreateProjectEF(AddProject addProjectEF)
        {
            return new AddProjectsEFDAL().CreateProjectEF(addProjectEF);
        }

        // Delete In DALEF
        public bool DeleteProjectEF(AddProject addProjectEF)
        {
            return new AddProjectsEFDAL().DeleteProjectEF(addProjectEF);
        }

        // Update In DALEF
        public bool UpdateProjectEF(AddProject addProjectEF)
        {
            return new AddProjectsEFDAL().UpdateProjectEF(addProjectEF);
        }

        public List<AddProject> AllListUserEF()
        {
            AddProjectsEFDAL addProjectsEFDAL = new AddProjectsEFDAL();
            var lstAddUsersEF = addProjectsEFDAL.GetProjectDataListEF();
            return lstAddUsersEF;
        }
    }
}
