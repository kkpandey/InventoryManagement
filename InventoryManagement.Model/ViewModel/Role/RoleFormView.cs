using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.ViewModel.Role
{
   public class RoleFormView
    {
        public int RoleId { get; set; }
        [Required]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        public Nullable<int> CreateBy { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }
    }
}
