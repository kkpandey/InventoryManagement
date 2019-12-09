using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.Models
{
    [Table("tblUsers")]
    public class UserModel
    {
        [Key]
        public int UserId{get;set;}
      public string UserName{get;set;}
      public string Password{get;set;}
      public string FirstName{get;set;}
      public string LastName{get;set;}
      public int RoleId{get;set;}
      public Nullable<int> CompanyId{get;set;}
      public string EmailId{get;set;}
      public string MobileNo{get;set;}
      public Nullable<DateTime> CreateDate{get;set;}
      public string CreateBy{get;set;}
        public Nullable<DateTime> LastLoginDateTime { get; set; }
        public string UserPhoto { get; set; }
    }
}
