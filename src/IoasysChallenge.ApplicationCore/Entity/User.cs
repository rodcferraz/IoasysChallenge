using System;
using System.Collections.Generic;
using System.Text;

namespace IoasysChallenge.ApplicationCore.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }    
        public bool? IsDeleted { get; set; }
        public virtual ICollection<MovieScore> MoviesScores { get; set; }
    }
}
