﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HajjPort.ViewModel
{
    public class RoleVM
    {
        [Required]
        public string RoleName { get; set; }
    }
}
