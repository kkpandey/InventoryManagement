using InventoryManagement.Interface.Interface;
using InventoryManagement.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Service.Services
{
   public class LoginService:DefaultDisposable, ILogin
    {
        
        public string LoginAut(LoginFormView model)
        {
            string _result = string.Empty;
            if (model != null)
            {

                try
                {
                    var _CheckUserExit = db.UserModels.Any(x => x.UserName.ToLower().Equals(model.UserName.ToLower().Trim()));
                    if (!_CheckUserExit)
                    {
                        var _checkdata = db.Database.SqlQuery<LoginView>("Exec Proc_UserLogin {0},{1},{2}", model.UserName, model.Password,1).FirstOrDefault();
                        if (_checkdata != null)
                        {
                            _result = "success";
                        }
                        else
                        {
                            _result = "NotExit";
                        }
                    }
                    else
                    {
                        _result = "UserNameNotExit";
                    }
                }
                catch (Exception ex)
                {
                    _result = ex.Message;
                }
            }
            else
            {
                _result = "UserNameNotExit";
            }
            return _result;

        }

        public LoginView GetUserData(string UserName)
        {            
           LoginView userdata = db.Database.SqlQuery<LoginView>("Exec Proc_UserLogin {0},{1},{2}", UserName, null, 2).FirstOrDefault();
                 
            return userdata;

        }
    }
}
