using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.ViewModel
{
    public class MenuModel
    {
        public int MenuIndex { get; set; }
        public string MenuName { get; set; }
        public string MainCss { get; set; }
    }
    public class SubMenuModel
    {
        public int MenuIndex { get; set; }
        public int SubMenuIndex { get; set; }
        public int SubMenuId { get; set; }
        public string SubMenuName { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }

    public class MenuContols
    {
        public List<MenuModel> MenuModels { get; set; }
        public List<SubMenuModel> SubMenuModels { get; set; }
    }

    public class UserWiseMultipalRols
    {
        public Nullable<int> RoleId { get; set; }
    }
}
