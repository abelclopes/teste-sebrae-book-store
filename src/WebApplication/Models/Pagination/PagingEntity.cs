using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models.Pagination
{
    public class PagingEntity
    {
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}
