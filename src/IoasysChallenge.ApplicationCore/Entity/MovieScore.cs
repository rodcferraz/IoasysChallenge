using System;
using System.Collections.Generic;
using System.Text;

namespace IoasysChallenge.ApplicationCore.Entity
{
    public class MovieScore
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public double Score { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
