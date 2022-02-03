using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HajjPort.Models
{
    public class PortOperations
    {
        [Display(Name = "رقم العملية")]
        public int id { get; set; }


        [ForeignKey("Port")]
        public int PortID { get; set; }
        public Port Port { get; set; }


        [Display(Name = "العدد")]
        [Required(ErrorMessage = "مطلوب")]
        public string Quantity { get; set; }

        
        [Display(Name = "نوع المركبة")]
        [Required(ErrorMessage = "مطلوب")]
        public string TransportType { get; set; }
        

        [Display(Name = "نوع الجنس")]
        [Required(ErrorMessage = "مطلوب")]
        public string Gender { get; set; }


        [Display(Name = "نوع الحركة")]
        [Required(ErrorMessage = "مطلوب")]
        public string MovementType { get; set; }


        [Display(Name = "تاريخ الإدخال")]
        public DateTime EntryDate { get; set; }
        
    }
}
