using InventoryManagement.Model.ViewModel.Role;
using InventoryManagement.Model.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.Interface
{
    public interface IUser
    {
        List<RoleView> GetRoleViews();
        string SaveUserData(UsersFormView model);
        List<UsersFormView> GetUserdata();
        string UpdateUserData(UsersFormView model);
    }
}
