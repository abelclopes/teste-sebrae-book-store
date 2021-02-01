using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Pagination
{
    public class PagingParamters
    {
        [Range(1, Int32.MaxValue)]
        public int PageNumber { get; set; }
        [Range(10, 100)]
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }
        public string SortOrder { get; set; }
        public string CategoryFilter { get; set; }
        public string RentedFilter { get; set; }
        public string SearchString { get; set; }
        
    }
}