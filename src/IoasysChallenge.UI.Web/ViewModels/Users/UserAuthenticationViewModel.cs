using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoasysChallenge.UI.Web.ViewModels.Users
{
    public class UserAuthenticationViewModel
    {
        [Required(ErrorMessage ="{0} is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        public string Password { get; set; }
    }
}
