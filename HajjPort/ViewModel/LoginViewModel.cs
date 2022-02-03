using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HajjPort.ViewModel
{
    public class LoginViewModel
    {
        [Required (ErrorMessage ="مطلوب")]
        [EmailAddress (ErrorMessage = "أدخل بريد إلكتروني  صحيح")]
        [Display(Name = "البريد الالكتروني")]
        public string Email { get; set; }


        [Required(ErrorMessage = "مطلوب")]
        [DataType(DataType.Password)]
        [Display(Name = "الرقم السري")]
        public string Password { get; set; }


        [Display(Name ="تذكرني؟")]
        public bool RememberMe { get; set; }
    }
}
