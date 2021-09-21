using DAL;
using DALEntityEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AddUsersBLL
    {
        //List all Users
        public List<AddUsers> addUsers()
        {
            AddUsersDAL addUsersDAL = new AddUsersDAL();
            var lstAddUsers = addUsersDAL.GetDataList();
            return lstAddUsers;
        }

        // Create User
        public bool CreateUser(AddUsers addUsers)
        {
            return new AddUsersDAL().CreateUser(addUsers);
        }
        
        //Delete User
        public bool DeleteUser(AddUsers addUsers)
        {
            return new AddUsersDAL().DeleteUser(addUsers);
        }

        // Update User
        public bool UpdateUser(AddUsers addUsers)
        {
            return new AddUsersDAL().UpdateUser(addUsers);
        }



        //-----------------------------------------------------------------------------------------------
        //DALEntityEF

        // List all User In DALEF
        public List<AddUser> ListUserEF()
        {
            AddUsersEFDAL addUsersEFDAL = new AddUsersEFDAL();
            var lstAddUsersEF = addUsersEFDAL.GetUserDataListEF();
            return lstAddUsersEF;
        }

        // Create In DALEF
        public bool CreateUserEF(AddUser addUserEF)
        {
            return new AddUsersEFDAL().CreateUserEF(addUserEF);
        }

        // Delete In DALEF
        public bool DeleteUserEF(AddUser addUserEF)
        {
            return new AddUsersEFDAL().DeleteUserEF(addUserEF);
        }

        // Update In DALEF
        public bool UpdateUserEF(AddUser addUserEF)
        {
            return new AddUsersEFDAL().UpdateUserEF(addUserEF);
        }

        public List<AddUser> AllListUserEF()
        {
            AddUsersEFDAL addUsersEFDAL = new AddUsersEFDAL();
            var lstAddUsersEF = addUsersEFDAL.GetUserDataListEF();
            return lstAddUsersEF;
        }
    }
}
