using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Model.Models
{
    [Table("tblCompany")]
    public class CompanyModel
    {
        [Key]
        public string CompanyId{get;set;}
      public string CompanyCode{get;set;}
      public string CompanyName{get;set;}
      public string EmailId{get;set;}
      public string Address1{get;set;}
      public string Address2{get;set;}
      public string Status{get;set;}
      public string CreateDate{get;set;}
      public string CreteBy{get;set;}
    }
}
