using InventoryManagement.Model;
using InventoryManagement.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static InventoryManagement.Model.Commons.NotifType;

namespace InventoryManagement.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        MenuControls _menu = new MenuControls();
        protected virtual new CustomPrincipal User
        {
            get { return System.Web.HttpContext.Current.User as CustomPrincipal; }
        }
        public BaseController()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var identity = ((CustomPrincipal)System.Web.HttpContext.Current.User);
                if (System.Web.HttpContext.Current.Session["UserMenu"] == null)
                {
                    System.Web.HttpContext.Current.Session["UserMenu"] = _menu.UserWiseMenu(Convert.ToInt32(identity.UserId), Convert.ToInt32(identity.RoleId));
                }
 
               ViewBag.UserMenus = System.Web.HttpContext.Current.Session["UserMenu"];
                
            }
        }


        #region Alert Notification
        public void SuccessAlert(string message)
        {
            var msg = "<script language='javascript'>toastr.success('" + message + "','" + "" + "','" + NotificationType.success + "')" + "</script>";
            TempData["notification"] = msg;
        }
        public void ErrorAlert(string message)
        {
            var msg = "<script language='javascript'>toastr.error('" + message + "','" + "" + "','" + NotificationType.error + "')" + "</script>";
            TempData["notification"] = msg;
        }
        
        /// <summary>
        /// Sets the information for the system notification.
        /// </summary>
        /// <param name="message">The message to display to the user.</param>
        /// <param name="notifyType">The type of notification to display to the user: Success, Error or Warning.</param>
        public void Message(string message, NotificationType notifyType)
        {
            TempData["Notification2"] = message;

            switch (notifyType)
            {
                case NotificationType.success:
                    TempData["NotificationCSS"] = "alert-box success";
                    break;
                case NotificationType.error:
                    TempData["NotificationCSS"] = "alert-box errors";
                    break;
                case NotificationType.warning:
                    TempData["NotificationCSS"] = "alert-box warning";
                    break;

                case NotificationType.info:
                    TempData["NotificationCSS"] = "alert-box notice";
                    break;
            }
        }
        #endregion
    }
}