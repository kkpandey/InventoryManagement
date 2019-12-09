using InventoryManagement.Interface.Interface;
using InventoryManagement.Model.Commons;
using InventoryManagement.Model.ViewModel.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class UsersController : BaseController
    {
        // GET: Users
        readonly IUser _IUser;
        public UsersController(IUser user)
        {
            this._IUser = user;
        }
        public ActionResult Index()
        {
            var data = _IUser.GetUserdata();
            return View(data);
        }
        public ActionResult Create()
        {
            UsersFormView usersFormView = new UsersFormView();
            usersFormView.RoleIdlst = _IUser.GetRoleViews().Select(x => new SelectListItem { Text = x.RoleName, Value = x.RoleId.ToString() }).ToList();
            return View(usersFormView);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult CreateUsers(UsersFormView model)
        {
            if (ModelState.IsValid)
            {
                model.CreateBy = User.UserName;
                string _result = _IUser.SaveUserData(model);
                if (_result == CommonMessages.Saved_successfully)
                {
                    ModelState.Clear();
                    SuccessAlert(_result);
                    return RedirectToAction("Index");
                }
                else
                {
                    ErrorAlert(_result);
                }
            }
            return View("Create", model);
        }

        public ActionResult Edit(int id)
        {
            UsersFormView mod = new UsersFormView();
            mod.RoleIdlst = _IUser.GetRoleViews().Select(x => new SelectListItem { Text = x.RoleName, Value = x.RoleId.ToString() }).ToList();

            var model = _IUser.GetUserdata().Where(x => x.UserId.Equals(id)).FirstOrDefault();
            if (model != null)
            {
                mod.UserId = model.UserId;
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
            }
            return View(mod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult UpdateUsers(UsersFormView model)
        {
            if (ModelState.IsValid)
            {
                model.CreateBy = User.UserName;
                string _result = _IUser.UpdateUserData(model);
                if (_result == CommonMessages.Update_Successfully)
                {
                    ModelState.Clear();
                    SuccessAlert(_result);
                    return RedirectToAction("Index");
                }
                else
                {
                    ErrorAlert(_result);
                }
            }
            else
                ErrorAlert("some Invalid model error");
            return RedirectToAction("Edit", new { id = model.UserId });
        }
    }
}