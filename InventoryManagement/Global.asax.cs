using InventoryManagement.Model;
using InventoryManagement.Model.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace InventoryManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            BundleTable.EnableOptimizations = true;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            try
            {
                HttpCookie authCookie = Request.Cookies["AuthenticationToken"];
                if (authCookie != null)
                {
                    if (authCookie.Value != "")
                    {
                        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                        var serializeModel = JsonConvert.DeserializeObject<LoginView>(authTicket.UserData);

                        CustomPrincipal principal = new CustomPrincipal(authTicket.Name);

                        principal.UserId = serializeModel.UserId;
                        principal.UserName = serializeModel.UserName;
                        principal.RoleName = serializeModel.RoleName;
                        principal.RoleId = serializeModel.RoleId;
                        principal.UserPhoto = serializeModel.UserPhoto;
                        principal.Email = serializeModel.EmailId;
                        principal.Roles = serializeModel.RoleId.ToString();
                        principal.Name = serializeModel.Name;
                        HttpContext.Current.User = principal;
                    }
                }
            }
            catch (System.Security.Cryptography.CryptographicException cex)
            {

                FormsAuthentication.SignOut();
            }

        }

    }
}
