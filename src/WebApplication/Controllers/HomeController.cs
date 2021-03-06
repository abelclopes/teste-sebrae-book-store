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

        [HttpGet]
        public async Task<IActionResult> Index(PagingParamters model)
        {
            ViewData["CurrentSort"] = model.SortOrder == null? "": model.SortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(model.SortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = model.SortOrder == "Date" ? "date_desc" : "Date";
            if (model.SearchString != null)
            {
                model.PageNumber = 1;
            }
            else
            {
                model.SearchString = model.CurrentFilter;
            }
            ViewBag.categoryFilter = model.CategoryFilter;
            ViewBag.CurrentFilter = model.SearchString;
            var listBook = await _context.Books.Include(b => b.Category).Where(x => !x.Excluded).ToListAsync();
            //listBook = listBook.AsQueryable();
            if (!String.IsNullOrEmpty(model.CategoryFilter))
            {
                listBook = listBook.Where(x => x.CategoryId.ToString() == model.CategoryFilter).ToList();
            }
            if (!String.IsNullOrEmpty(model.SearchString))
            {
                listBook = listBook.Where(x => x.Title.Contains(model.SearchString)
                               || x.Description.Contains(model.SearchString)).ToList();
            }
            if(model.RentedFilter == "True")
            {
                listBook = listBook.Where(x => x.Rented).ToList();
            } else if (model.RentedFilter == "False")
            {
                listBook = listBook.Where(x => !x.Rented).ToList();
            }

            switch (model.SortOrder)
            {
                case "name_desc":
                    listBook = listBook.OrderByDescending(s => s.Title).ToList();
                    break;
                case "Date":
                    listBook = listBook.OrderBy(s => s.DateCriation).ToList();
                    break;
                case "date_desc":
                    listBook = listBook.OrderByDescending(s => s.DateCriation).ToList();
                    break;
                default:
                    listBook = listBook.OrderBy(s => s.Title).ToList();
                    break;
            }

            if (model.PageNumber == 0)
            {
                model.PageNumber = 1;
            }
            if (model.PageSize == 0)
            {
                model.PageSize = 10;
            }
            ViewBag.Categorys = new SelectList(await _context.Categories.OrderBy (c => c.Name).ToListAsync(), "Id", "Name", model.CategoryFilter);
            ViewBag.rentedOption = new SelectList(SelectListOptionsViewModel.GetList(), "Key", "Value", model.RentedFilter);
            var paginationList = await Task.FromResult(new PaginationList<Book>(model.PageNumber, model.PageSize));
            return View(paginationList.Read(listBook));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
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

            byte[] imageBack = book.Image;

            return File(imageBack, "image/png");
        }
    }
}
