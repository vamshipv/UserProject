using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    
    public class AddProjectsDAL
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);

        public List<AddProjects> GetProjectList()
        {
            List<AddProjects> lstProject = new List<AddProjects>();
            SqlCommand cmd = new SqlCommand("DisplayAllProjects", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lstProject.Add(new AddProjects
                {
                    Id = Convert.ToInt32(dr[0]),
                    ProjectName = Convert.ToString(dr[1]),
                    ProjectStartDate = Convert.ToDateTime(dr[2]),
                    ProjectEndDate = Convert.ToDateTime(dr[3]),
                    projectPriority = (ProjectPriority)Convert.ToInt32(dr[4]),
                    EmpId = Convert.ToString(dr[5])
                });
            }
            return lstProject;
        }

        public bool CreateProject(AddProjects cu)
        {
            int op;
            SqlCommand cmd = new SqlCommand("CreateProject", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProjectName", cu.ProjectName);
            cmd.Parameters.AddWithValue("@ProjectStartDate", cu.ProjectStartDate);
            cmd.Parameters.AddWithValue("@ProjectEndDate", cu.ProjectEndDate);
            cmd.Parameters.AddWithValue("@ProjectPriority", cu.projectPriority);
            cmd.Parameters.AddWithValue("@EmpId", cu.EmpId);
            con.Open();
            op = cmd.ExecuteNonQuery();
            con.Close();

            if (op >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateProject(AddProjects cu)
        {
            int op;
            SqlCommand cmd = new SqlCommand("UpdateProject1", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProjectName", cu.ProjectName);
            cmd.Parameters.AddWithValue("@ProjectStartDate", cu.ProjectStartDate);
            cmd.Parameters.AddWithValue("@ProjectEndDate", cu.ProjectEndDate);
            cmd.Parameters.AddWithValue("@ProjectPriority", cu.projectPriority);
            cmd.Parameters.AddWithValue("@EmpId", cu.EmpId);
            con.Open();
            op = cmd.ExecuteNonQuery();
            con.Close();

            if (op >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // this Methos return a bool value after getting data from the Delete.csHtml, if data is now provided it will return false
        public bool DeleteProject(AddProjects cu)
        {
            int op;
            SqlCommand cmd = new SqlCommand("DeleteProject", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", cu.Id);
            con.Open();
            op = cmd.ExecuteNonQuery();
            con.Close();

            if (op >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
