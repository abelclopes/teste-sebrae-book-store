using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Infraestructure;
using Microsoft.Extensions.Logging;
using Domain.Interface;
using WebApplication.Models;
using WebApplication.Models.Pagination;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication.Controllers
{    
    [Authorize]
    public class CategoriesController : BaseController
    {
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(IContext context, ILogger<CategoriesController> logger) : base(context)
        {
            _logger = logger;
        }

        // GET: Categories
        public async Task<IActionResult> Index(PagingParamters model)
        {
            ViewData["CurrentSort"] = model.SortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(model.SortOrder) ? "name_desc" : "";
            if (model.SearchString != null)
            {
                model.PageNumber = 1;
            }
            else
            {
                model.SearchString = model.CurrentFilter;
            }
            ViewData["CurrentFilter"] = model.SearchString;

            var Listcategorias = await _context.Categories.ToListAsync();
            if (!String.IsNullOrEmpty(model.SearchString))
            {
                Listcategorias = Listcategorias.Where(x => x.Name.Contains(model.SearchString)
                               || x.Description.Contains(model.SearchString)).ToList();
            }

            switch (model.SortOrder)
            {
                case "name_desc":
                    Listcategorias = Listcategorias.OrderByDescending(s => s.Name).ToList();
                    break;
                default:
                    Listcategorias = Listcategorias.OrderBy(s => s.Name).ToList();
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

            var paginationList = await Task.FromResult(new PaginationList<Category>( model.PageNumber, model.PageSize));
            return View(paginationList.Read(Listcategorias));
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Id,DateCriation,DateUpdate,Excluded")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.Id = Guid.NewGuid();
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,Id,DateCriation,DateUpdate,Excluded")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Categories.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(Guid id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
