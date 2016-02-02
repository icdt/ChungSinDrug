using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChungSinDrug.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region database table
        public DbSet<News> News { get; set; }

        public DbSet<SystemPara> SystemParas { get; set; }
        
       
        #endregion

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}