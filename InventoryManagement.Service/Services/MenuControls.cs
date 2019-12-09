using InventoryManagement.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Service.Services
{
    public class MenuControls : DefaultDisposable
    {
        public MenuContols UserWiseMenu(int UserId, int RoleId)
        {

            MenuContols lstmanmenu = new MenuContols();
            try
            {
                string resultRole = string.Empty;

                IList<MenuModel> lstmenu = db.Database.SqlQuery<MenuModel>("Exec Proc_UserwiseMenu {0},{1},{2}", UserId, RoleId, 1).ToList();

                if (lstmenu.Count > 0)
                    lstmanmenu.MenuModels = lstmenu.ToList();

                IList<SubMenuModel> lstsubmenu = db.Database.SqlQuery<SubMenuModel>("Exec Proc_UserwiseMenu {0},{1},{2}", UserId, RoleId, 2).ToList();


                if (lstsubmenu.Count > 0)
                    lstmanmenu.SubMenuModels = lstsubmenu.ToList();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstmanmenu;
        }


    }
}
