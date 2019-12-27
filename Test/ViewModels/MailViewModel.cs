using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.ViewModels
{
    public class MailViewModel
    {
        [Display(Name ="Full Name")]
        [Required(ErrorMessage ="Please write your name !")]
        [MinLength(4)]
        public string FullName { get; set; }
        
        [Required(ErrorMessage ="Please Enter your Email Address !")]
        [EmailAddress]        
        public string Email { get; set; }


        public string Subject { get; set; }
        
        [Required(ErrorMessage="Please write something to us !")]
        public string Body { get; set; }
    }
}
