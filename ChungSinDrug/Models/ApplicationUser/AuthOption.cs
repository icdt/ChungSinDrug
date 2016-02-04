using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace icdtFramework.Models
{
    public class AuthOption
    {
        [Key]
        public String AuthOption_Id { get; set; }

        public bool AuthOption_Admin { get; set; }


        public AuthOption()
        {
            this.AuthOption_Id = Guid.NewGuid().ToString();
            this.AuthOption_Admin = false;
        }
    }
}
