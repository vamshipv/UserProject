using BLL;
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
    public class AddUsersDAL
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString);
        public List<AddUsers> GetDataList()
        {
            //new List of name AddUsers
            List<AddUsers> lst = new List<AddUsers>();
            SqlCommand cmd = new SqlCommand("DisplayAllUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lst.Add(new AddUsers
                {
                    Id = Convert.ToInt32(dr[0]), //dr[0] represent first data of the column
                    EmpId = Convert.ToString(dr[1]),
                    FirstName = Convert.ToString(dr[2]),
                    LastName = Convert.ToString(dr[3]),
                });
            }
            return lst;
        }

        public bool CreateUser(AddUsers cu)
        {
            int op;
            SqlCommand cmd = new SqlCommand("CreateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", cu.EmpId);
            cmd.Parameters.AddWithValue("@FirstName", cu.FirstName);
            cmd.Parameters.AddWithValue("@LastName", cu.LastName);
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

        public bool UpdateUser(AddUsers cu)
        {
            int op;
            SqlCommand cmd = new SqlCommand("UpdateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmpId", cu.EmpId);
            cmd.Parameters.AddWithValue("@FirstName", cu.FirstName);
            cmd.Parameters.AddWithValue("@LastName", cu.LastName);
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

        public bool DeleteUser(AddUsers cu)
        {
            int op;
            SqlCommand cmd = new SqlCommand("DeleteUser", con);
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
