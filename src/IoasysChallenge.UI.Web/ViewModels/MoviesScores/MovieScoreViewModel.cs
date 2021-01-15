using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoasysChallenge.UI.Web.ViewModels.MoviesScores
{
    public class MovieScoreViewModel
    {
        [Required(ErrorMessage = "{0} is required.")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Range(0, 4, ErrorMessage = "Value from {0} must be from {1} to {2}.")]
        public double Score { get; set; }
    }
}
