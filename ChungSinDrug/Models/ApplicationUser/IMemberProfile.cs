using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace icdtFramework.Models
{
    public abstract class MemberProfile
    {
        [Key]
        public string MemberProfile_Id { get; set; }
    }
}
