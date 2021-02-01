using System;
using System.IO;
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
using WebApplication.ModelView;
using Domain.Paginator;
using PagedList;
using WebApplication.Models;
using Microsoft.AspNetCore.Http;
using WebApplication.Models.Pagination;

namespace WebApplication.Controllers
{
    public class BooksController : BaseController
    {
        private readonly ILogger<BooksController> _logger;

        public BooksController(IContext context, ILogger<BooksController> logger) : base(context)
        {
            _logger = logger;
        }


        // GET: Books
        public async Task<IActionResult> Index(string sortOrder,
                                                string currentFilter,
                                                string searchString,
                                                int pageNumber)
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
            ViewData["CurrentFilter"] = searchString;
            var listBook = _context.Books.Include(b => b.Category).AsQueryable(); //.Join(_context.Categories, book => book.CategoryId, cat => cat.Id, (book, cat) => new { Book = book, Category = cat });
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

            var paginationList = new PaginationList<Book>(pageNumber, pageSize);
            return View(paginationList.Read(listBook));
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(Guid? id)
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

        // GET: Books/Create
        public async Task<IActionResult> CreateAsync()
        {
            SelectList selectLists = new SelectList(await _context.Categories.OrderBy (c => c.Name).ToListAsync(), "Id", "Name");
            var BookCategoryVM = new BookCategoryViewModel
            {
                Categorys = selectLists,
                Book = new Book()
            };
            ViewData["CategoryId"] = new SelectList(_context.Categories.OrderBy (c => c.Name), "Id", "Name");
            return View(BookCategoryVM);
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Author,Year,CategoryId,PublishingCompany,Rented,Id,DateCriation,DateUpdate,Excluded")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid();
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            SelectList selectLists = new SelectList(await _context.Categories.OrderBy (c => c.Name).ToListAsync(), "Id", "Name");
            var BookCategoryVM = new BookCategoryViewModel
            {
                Categorys = selectLists,
                Book = new Book()
            };
            ViewData["CategoryId"] = new SelectList(_context.Categories.OrderBy (c => c.Name), "Id", "Name");
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories.OrderBy (c => c.Name), "Id", "Name", book.CategoryId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Description,Author,Year,CategoryId,PublishingCompany,Rented,Id,DateCriation,DateUpdate,Excluded")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Books.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories.OrderBy (c => c.Name), "Id", "Name", book.CategoryId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
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

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            book.Excluded = true;
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(Guid id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> upload(IFormFile file, Guid id)
        {
            byte[] buffer = new byte[file.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                if (file != null)
                {
                    file.CopyTo(ms);
                    var book = _context.Books.FirstOrDefault(x => x.Id == id);
                    book.Image = ms.ToArray();
                    _context.Books.Update(book);
                    await Task.FromResult(_context.SaveChanges());
                }
            }
            return RedirectToAction("Index");
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
