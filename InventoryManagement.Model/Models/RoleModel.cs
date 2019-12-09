using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.Models
{
    [Table("tblRoles")]
    public class RoleModel
    {
        [Key]
        public int RoleId{get;set;}
      public string RoleName{get;set;}
      public string Status{get;set;}
      public Nullable<int> CreateBy{get;set;}
      public Nullable<DateTime> CreateDate{get;set;}
    }
}
