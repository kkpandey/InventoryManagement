using InventoryManagement.Interface.Interface;
using InventoryManagement.Model.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InventoryManagement.Controllers
{
    public class AccountController : Controller
    {
        readonly ILogin _ILogin;
        public AccountController(ILogin login)
        {
            this._ILogin= login;
        }
            // GET: Account
            [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl)
        {
            LogOut();
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Login(LoginFormView model, string ReturnUrl)
        {
            
            if (ModelState.IsValid)
            {
                var ReturnData = _ILogin.LoginAut(model);
                if (ReturnData== "success")
                {
                    #region Add Cookies
                    var getUserDatas = _ILogin.GetUserData(model.UserName.Trim());
                    string userData = JsonConvert.SerializeObject(getUserDatas);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                (
                1, model.UserName, DateTime.Now, DateTime.Now.AddDays(1), false, userData
                );

                    string enTicket = FormsAuthentication.Encrypt(authTicket);
                    Session["AuthenticationTokenSes"] = enTicket;
                    bool httponlycook = false;
                    bool SecureCookies = false;                    
                    HttpContext.Response.Cookies.Add(new HttpCookie("AuthenticationToken", enTicket)
                    {
                        Path = FormsAuthentication.FormsCookiePath,
                        Expires = authTicket.Expiration,
                        HttpOnly = httponlycook,
                        Secure = SecureCookies
                    });
                    #endregion
                    if (string.IsNullOrEmpty(ReturnUrl))
                        return RedirectToAction("Index", "Dashboard");
                    else
                        return RedirectToAction("Index", "Dashboard", new { ReturnUrlData = ReturnUrl });

                }
                else
                {
                    ModelState.Clear();
                    ModelState.AddModelError("", "The Username Or Password Is Incorrect");
                }
            }
            return View();
        }

        public ActionResult LogOff()
        {
            LogOut();
            return RedirectToAction("Login", "Account");
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();

            System.Web.HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            foreach (var cookie in Response.Cookies.AllKeys)
            {
                Response.Cookies.Remove(cookie);
            }
            HttpContext.Request.Cookies.Clear();
            HttpContext.Response.Cookies.Clear();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Cookies.Clear();
            Session["UserID"] = null;
            Session["RoleId"] = null;
            Session["Username"] = null;
            Session["Role"] = null;
            Session["Email"] = null;
            Session["UserMenu"] = null;
            Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            HttpContext.Response.Cookies.Set(new HttpCookie("Language") { Value = null });
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            ////Removing ASP.NET_SessionId Cookie
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddMonths(-10);
            }
            if (Request.Cookies["AuthenticationToken"] != null)
            {
                Response.Cookies["AuthenticationToken"].Value = string.Empty;
                Response.Cookies["AuthenticationToken"].Expires = DateTime.Now.AddMonths(-10);
            }
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            HttpCookie Ticket = new HttpCookie("AuthenticationToken", "");
            Ticket.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(Ticket);
        }

    }
}