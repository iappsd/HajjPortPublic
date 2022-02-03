using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HajjPort.Models
{
    public class Port
    {

        [Display(Name = "رقم المنفذ")]
        public int id { get; set; }

        [Display(Name = " اسم المنفذ")]
        [Required(ErrorMessage ="مطلوب")]
        public string Name { get; set; }

        
        [Display(Name = "تفاصيل المنفذ")]
        public string PortDescription { get; set; }


        [ForeignKey("AppUser")]
        public string AppUserID { get; set; }
        public AppUser AppUser { get; set; }


        [Display(Name = "تفعيل")]
        public bool IsActive { get; set; }

        public ICollection<PortOperations> PortOperations { get; set; }

    }
}
