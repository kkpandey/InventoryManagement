using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Interface.Interface;
using InventoryManagement.Model.Commons;
using InventoryManagement.Model.Models;
using InventoryManagement.Model.ViewModel.Role;
using InventoryManagement.Model.ViewModel.Users;

namespace InventoryManagement.Service.Services.Users
{
   public class UserService:DefaultDisposable, IUser
    {
        public List<RoleView> GetRoleViews()
        {
            List<RoleView> lst = new List<RoleView>();
            var data = db.RoleModels.Where(x => x.Status.Equals("Y")).ToList();
            if (data != null && data.Count() > 0)
            {
                foreach (var item in data)
                {
                    RoleView mod = new RoleView();
                    mod.RoleId = item.RoleId;
                    mod.RoleName = item.RoleName;
                    lst.Add(mod);
                }
            }
            return lst;
        }

        public string SaveUserData(UsersFormView model)
        {
            string _result = string.Empty;
            try
            {
                var _CheckUserName = db.UserModels.Any(x => x.UserName.Equals(model.UserName));
                if (!_CheckUserName)
                {
                    UserModel mod = new UserModel();
                    mod.UserName = model.UserName;
                    mod.Password = model.Password;
                    mod.FirstName = model.FirstName;
                    mod.LastName = model.LastName;
                    mod.RoleId = model.RoleId;
                    mod.CompanyId = model.CompanyId;
                    mod.EmailId = model.EmailId;
                    mod.MobileNo = model.MobileNo;
                    mod.CreateDate = System.DateTime.Now;
                    mod.CreateBy = model.CreateBy;
                    mod.UserPhoto = model.UserPhoto;
                    db.UserModels.Add(mod);
                    db.SaveChanges();
                    _result = CommonMessages.Saved_successfully;
                }
                else
                    _result = CommonMessages.AlredyExit;
            }
            catch(Exception ex)
            {
                _result = ex.Message;
            }
            return _result;
        }

        public List<UsersFormView> GetUserdata()
        {
            var data = db.Database.SqlQuery<UsersFormView>("Exec proc_GetUserData {0}", 1).ToList();
            return data;
        }
        public string UpdateUserData(UsersFormView model)
        {
            string _result = string.Empty;
            try
            {
                var _CheckUserName = db.UserModels.Any(x => x.UserName.Equals(model.UserName) && x.UserId != model.UserId);
                if (!_CheckUserName)
                {
                    var mod = db.UserModels.Find(model.UserId);
                    mod.UserName = model.UserName;
                    mod.FirstName = model.FirstName;
                    mod.LastName = model.LastName;
                    mod.RoleId = model.RoleId;
                    mod.CompanyId = model.CompanyId;
                    mod.EmailId = model.EmailId;
                    mod.MobileNo = model.MobileNo;
                    mod.CreateDate = System.DateTime.Now;
                    mod.CreateBy = model.CreateBy;
                    mod.UserPhoto = model.UserPhoto;
                    db.Entry(mod).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    _result = CommonMessages.Update_Successfully;
                }
                else
                    _result = CommonMessages.AlredyExit;
            }
            catch (Exception ex)
            {
                _result = ex.Message;
            }
            return _result;
        }
    }
}
