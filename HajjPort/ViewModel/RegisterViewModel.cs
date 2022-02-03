using HajjPort.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HajjPort.ViewModel
{
    public class RegisterViewModel
    {

        [ForeignKey("Port")]
        public int PortID { get; set; }
        public Port Port { get; set; }

        [Required(ErrorMessage = "مطلوب")]
        [EmailAddress]
        [Display(Name ="البريد الالكتروني")]
        public string Email { get; set; }

        [Required(ErrorMessage = "مطلوب")]
        [StringLength(100,ErrorMessage ="لايزيد عن {0} و يقل عن {2}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name ="الرقم السري")]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "الرقم السري")]
        [Compare("Password",ErrorMessage ="الرقم السري غير مطابق")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "مطلوب")]
        [Display(Name = "الاسم")]
        public string Name { get; set; }

        [Required(ErrorMessage = "مطلوب")]
        [Display(Name = "رقم الجوال")]
        public string PhoneNumber { get; set; }


        [Required (ErrorMessage ="مطلوب")]
        [Display(Name = "نوع الحساب")]
        public string UserRoles { get; set; }



    }
}
