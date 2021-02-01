using Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.ModelView
{
    public class BookCategoryViewModel
    {
        public List<Book> Books { get; set; }
        public Book Book { get; set; }
        public SelectList Categorys { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        
        
    }
}
