using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InventoryManagement.Model.ViewModel.Users
{
   public class UsersFormView
    {
        public int UserId { get; set; }
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Role")]
        public int RoleId { get; set; }
        public List<SelectListItem> RoleIdlst { get; set; }
        //[Required]
        [Display(Name = "Comapny")]
        public Nullable<int> CompanyId { get; set; }
        public List<SelectListItem> CompanyIdlst { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",ErrorMessage ="This Is Not AValid Email")]

        public string EmailId { get; set; }
        [Required]
        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(16)]
        [MinLength(1)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Invalid Mobile No")]
        public string MobileNo { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }
        public string CreateBy { get; set; }
        public Nullable<DateTime> LastLoginDateTime { get; set; }
        public string UserPhoto { get; set; }
        public string RoleName { get; set; }
    }
}
