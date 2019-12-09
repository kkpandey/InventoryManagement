using InventoryManagement.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.Interface
{
   public interface ILogin
    {
        string LoginAut(LoginFormView model);
        LoginView GetUserData(string UserName);
    }
}
