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

        public async Task<IActionResult> IndexAsync()
        {
            SelectList selectLists = new SelectList(await _context.Categories.ToListAsync(), "Id", "Name");
            var BookCategoryVM = new BookCategoryViewModel
            {
                Categorys = selectLists
            };
            return View(BookCategoryVM);
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
    }
}
