using InventoryManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Service
{
   public class WebAppDBContext : DbContext
    {
        public WebAppDBContext()
            : base("name=InventoryDBConnection")
        {
        }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<RoleModel> RoleModels { get; set; }
        public DbSet<CompanyModel> CompanyModels { get; set; }
    }
}
