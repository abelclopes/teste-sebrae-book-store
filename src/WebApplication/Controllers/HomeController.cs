﻿using Domain;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.Pagination;
using WebApplication.ModelView;

namespace WebApplication.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(IContext context, ILogger<HomeController> logger): base(context)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string sortOrder,
                                                string currentFilter,
                                                string categoryFilter,
                                                string searchString,
                                                int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.categoryFilter = categoryFilter;
            ViewBag.CurrentFilter = searchString;
            var listBook = _context.Books.Include(b => b.Category).Where(x=> !x.Excluded).AsQueryable(); //.Join(_context.Categories, book => book.CategoryId, cat => cat.Id, (book, cat) => new { Book = book, Category = cat });
            if (!String.IsNullOrEmpty(categoryFilter))
            {
                listBook = listBook.Where(x => x.CategoryId.ToString() == categoryFilter);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                listBook = listBook.Where(x => x.Title.Contains(searchString)
                               || x.Description.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    listBook = listBook.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    listBook = listBook.OrderBy(s => s.DateCriation);
                    break;
                case "date_desc":
                    listBook = listBook.OrderByDescending(s => s.DateCriation);
                    break;
                default:
                    listBook = listBook.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 10;
           ViewBag.rentedOption = new SelectList(SelectListOptionsViewModel.GetList(), "key", "value");
           ViewBag.Categorys = new SelectList(await _context.Categories.OrderBy (c => c.Name).ToListAsync(), "Id", "Name");
            

            var paginationList = await Task.FromResult(new PaginationList<Book>( pageNumber ?? 1, pageSize));
            return View(paginationList.Read(listBook));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<ActionResult> RenderImage(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            byte[] photoBack = book.Image;

            return File(photoBack, "image/png");
        }
    }
}
