using usos.API.Extensions;

namespace usos.API.Application.Models
{
    public class PaginationRequest
    {
        public PaginationRequest()
        {
            Page = 1;
            PageLimit = 200;
            SortDir = OrderByRequestExtension.Asc;
        }

        public int Page { get; set; }

        public int PageLimit { get; set; }

        public string SortBy { get; set; }

        public string SortDir { get; set; }

        public int Skip
        {
            get
            {
                var pageLimit = PageLimit == -1 ? 0 : PageLimit;
                return (Page - 1) * pageLimit;  
            }
        }

        public int Take => PageLimit == -1 ? int.MaxValue : PageLimit;
    }
}