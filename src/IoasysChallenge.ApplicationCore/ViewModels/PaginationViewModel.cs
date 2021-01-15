using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoasysChallenge.UI.Web.ViewModels
{
    public class PaginationViewModel
    {
        public PaginationViewModel()
        {
            Page = 1;
            Limit = 2;
        }
        public int Limit { get; set; }
        public int Start
        {
            get { return (Page - 1) * Limit; }
        }
        public int Page { get; set; }
        public int TotalPages
        {
            get
            {
                return Convert.ToInt32(Math.Ceiling((Double)TotalRegistered / (Double)Limit));
            }
        }
        public int TotalRegistered { get; set; }

        public object Json()
        {
            return new
            {
                limit = Limit,
                page = Page,
                totalPages = TotalPages,
                totalRegistered = TotalRegistered
            };
        }
    }
}
