using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoasysChallenge.UI.Web.ViewModels.Users
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(50, ErrorMessage = "Maximum {0} characters")]
        [MinLength(5, ErrorMessage = "Minimum {0} characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(50, ErrorMessage = "Maximum {0} characters")]
        [MinLength(5, ErrorMessage = "Minimum {0} characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(20, ErrorMessage = "Maximum {0} characters")]
        [MinLength(8, ErrorMessage = "Minimum {0} characters")]
        public string Role { get; set; }
    }
}
