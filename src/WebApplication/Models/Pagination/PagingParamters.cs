using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Pagination
{
    public class PagingParamters
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int PageNumber { get; set; }
        [Required]
        [Range(10, 100)]
        public int PageSize { get; set; }
        public string searchTerm { get; set; }
    }
}