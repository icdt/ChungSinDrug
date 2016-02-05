using ChungSinDrug.Models;
using icdtFramework.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace icdtFramework.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region database table
        public DbSet<MemberProfile> MemberProfiles { get; set; }
        public DbSet<AuthOption> AuthOptions { get; set; }
        public DbSet<SystemPara> SystemParas { get; set; }


        public DbSet<News> News { get; set; }

        
       
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