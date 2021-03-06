﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoasysChallenge.UI.Web.ViewModels.Users
{
    public class UserViewModel
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage ="{0} is required.")]
        [MaxLength(50, ErrorMessage ="Maximum {0} characters")]
        [MinLength(1, ErrorMessage ="Minimum {0} characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(50, ErrorMessage = "Maximum {0} characters")]
        [MinLength(5, ErrorMessage = "Minimum {0} characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public string Role { get; set; }

        public bool IsDeleted { get; set; }
    }
}
