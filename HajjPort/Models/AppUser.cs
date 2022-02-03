using HajjPort.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HajjPort.Models
{
    public class AppUser : IdentityUser
    {

        [Display(Name = " الاســم")]
        public string Name { get; set; }

        public ICollection<Port> Port { get; set; }


    }
}
