using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace icdtFramework.Models
{
    public class CustomerProfile:MemberProfile
    {
      
        public string CustomerProfile_Name { get; set; }
    }
}
