using System;
using System.Collections.Generic;
using System.Text;

namespace IoasysChallenge.ApplicationCore.Entity
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
        public bool? IsDeleted { get; set; }
        public ICollection<MovieScore> MoviesScores { get; set; }
    }
}
