using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoasysChallenge.UI.Web.ViewModels.Movies
{
    public class CreateMovieViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(50, ErrorMessage = "Maximum {0} characters")]
        [MinLength(1, ErrorMessage = "Minimum {0} characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(50, ErrorMessage = "Maximum {0} characters")]
        public string Director { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(40, ErrorMessage = "Maximum {0} characters")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(200, ErrorMessage = "Maximum {0} characters")]
        public string Actors { get; set; }
    }
}
