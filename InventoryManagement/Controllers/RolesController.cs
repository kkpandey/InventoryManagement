using InventoryManagement.Model.ViewModel.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class RolesController : BaseController
    {
        // GET: Roles
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Create()
        {
            RoleFormView roleFormView = new RoleFormView();
            return View(roleFormView);
        }
    }
}