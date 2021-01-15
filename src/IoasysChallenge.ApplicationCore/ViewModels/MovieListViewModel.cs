using IoasysChallenge.UI.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoasysChallenge.ApplicationCore.ViewModels
{
    public class MovieListViewModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }

        public MovieListViewModel()
        {
            Pagination = new PaginationViewModel();
        }

        public PaginationViewModel Pagination;
    }
}
