using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALEntityEF
{
    public class AddUsersEFDAL
    {
        private ProjectScreenAppEntities projectScreenAppEntities;

        public AddUsersEFDAL()
        {
            projectScreenAppEntities = new ProjectScreenAppEntities();
        }

        public bool CreateUserEF(AddUser objAddUser)
        {
            List<AddUser> lst = new List<AddUser>();
            AddUser addUser = new AddUser()
            {
                EmpId = objAddUser.EmpId,
                FirstName = objAddUser.FirstName,
                LastName = objAddUser.LastName
            };
            projectScreenAppEntities.AddUsers.Add(addUser);

            int returnValue = projectScreenAppEntities.SaveChanges();
            if (returnValue > 0)
            {
                return true;
            }
            return false;
        }

        public List<AddUser> GetDataListEF()
        {
            ProjectScreenAppEntities db = new ProjectScreenAppEntities();
            var AddUserCol = db.DisplayAllUsers();
            var AddUserItems = from e in AddUserCol
                               select new AddUser
                               {
                                   Id = e.Id,
                                   EmpId = e.EmpId,
                                   FirstName = e.FirstName,
                                   LastName = e.LastName
                               };
            List<AddUser> lst = new List<AddUser>(AddUserItems.ToList());
            return lst;
        }

        public bool DeleteUserEF(AddUser objAddUser)
        {
            List<AddUser> lst = new List<AddUser>();
            AddUser addUser = new AddUser()
            {
                Id = objAddUser.Id
            };
            projectScreenAppEntities.AddUsers.Attach(addUser);
            projectScreenAppEntities.AddUsers.Remove(addUser);

            int returnValue = projectScreenAppEntities.SaveChanges();
            if (returnValue > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateUserEF(AddUser objAddUser)
        {
            List<AddUser> lst = new List<AddUser>();
            AddUser addUser = new AddUser()
            {
                Id = objAddUser.Id,
                EmpId = objAddUser.EmpId,
                FirstName = objAddUser.FirstName,
                LastName = objAddUser.LastName
            };
            projectScreenAppEntities.AddUsers.Add(addUser);

            int returnValue = projectScreenAppEntities.SaveChanges();
            if (returnValue > 0)
            {
                return true;
            }
            return false;
        }


        public List<AddUser> GetUserDataListEF()
        {
            ProjectScreenAppEntities db = new ProjectScreenAppEntities();
            var AddUserCol = db.DisplayAllUsers();
            var AddUserItems = from e in AddUserCol
                               select new AddUser
                               {
                                   Id = e.Id,
                                   EmpId = e.EmpId,
                                   FirstName = e.FirstName,
                                   LastName = e.LastName
                               };
            List<AddUser> lst = new List<AddUser>(AddUserItems.ToList());
            return lst;
        }
    }
}
