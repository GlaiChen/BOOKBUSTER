using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;
using BooksStore.ViewModels;
using System.Security.Cryptography.X509Certificates;
using BooksStore.Facebook;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace BooksStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksStoreContext _context;

        //The paths to the images
        private const string _staticImagesRoute = "wwwroot/img/";

        public BooksController(BooksStoreContext context)
        {
            _context = context;
        }


        // GET: Books
        public async Task<IActionResult> Index()
        {
            var booksContext = _context.Books.Include(b => b.Genre);
            return View(await booksContext.ToListAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(IFormFile file, [Bind("BookId,BookName,Author,Publication,Price,Summary,PictureName,GenreId")] Book book)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("", "You must enter book picture");
                }
                else if (GetAllBooks.Where(b => b.BookName == book.BookName).Count() == 0)
                {
                    // get the image name and save the path to the saved pictures
                    var filePath = _staticImagesRoute + file.FileName;

                    // save the image name to the pictureName property so we get it later for the view
                    book.PictureName = "/img/" + file.FileName;

                    // save the picture to the static path
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    // save book
                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    FacebookConnection.PostMessage(book);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "The book already exist");
                }
                
            }
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreId", "GenreName", book.GenreId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
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
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName", book.GenreId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookName,Author,Publication,Price,Summary,PictureName,GenreId")] Book book, IFormFile file)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // case the user put new image to update
                if (file != null)
                {
                    // Set full path to file 
                    string FileToDelete = _staticImagesRoute + book.PictureName,
                           fileToUpdate = _staticImagesRoute + file.FileName;

                    // put the new picture name to product object
                    book.PictureName = "/img/" + file.FileName;

                    // save the picture to the static path
                    using (var stream = new FileStream(fileToUpdate, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
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
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreName", book.GenreId);
            return View(book);
        }

        public IActionResult List(string genreName)
        {
            IEnumerable<Book> books;
            string currentGenre;

            if (string.IsNullOrEmpty(genreName))
            {
                books = GetAllBooks.OrderBy(c => c.BookId);
                currentGenre = "All Genre";
            }

            else
            {
                books = GetAllBooks.Where(c => c.Genre.GenreName == genreName);
                currentGenre = _context.Genres.FirstOrDefault(c => c.GenreName == genreName)?.GenreName;
            }

            return View(new BookListViewModel
            {
                Books = books,
                CurrentGenre = currentGenre
            });
        }

        public async Task<IActionResult> SearchAutoComplete(string term)
        {
            var query = from p in _context.Books
                        where p.BookName.Contains(term)
                        select new { id = p.BookId, label = p.BookName, value = p.BookName };

            return Json(await query.ToListAsync());
        }

        public IActionResult SearchTerm(string term)
        {
            var query = from p in _context.Books
                        where p.BookName.Contains(term)
                        select p;

            if (!query.Any())
            {
                return View("NotFound");
            }

            else
            {
                return View("List", new BookListViewModel
                {
                    Books = query,
                    CurrentGenre = "Search Results"
                });
            }
        }

        public IActionResult SearchAuthor(string author)
        {
            var query = from p in _context.Books
                        where p.Author.Contains(author)
                        select p;

            if (!query.Any())
            {
                return View("NotFound");
            }

            else
            {
                return View("List", new BookListViewModel
                {
                    Books = query,
                    CurrentGenre = "Search Results"
                });
            }
        }

        public IActionResult SearchPublication(string publication)
        {
            var query = from p in _context.Books
                        where p.Publication.Contains(publication)
                        select p;

            if (!query.Any())
            {
                return View("NotFound");
            }

            else
            {
                return View("List", new BookListViewModel
                {
                    Books = query,
                    CurrentGenre = "Search Results"
                });
            }
        }

        public IActionResult SearchUnderPrice(double price)
        {
            var query = from p in _context.Books
                        where p.Price <= price
                        select p;

            if (!query.Any())
            {
                return View("NotFound");
            }

            else
            {
                return View("List", new BookListViewModel
                {
                    Books = query,
                    CurrentGenre = "Search Results"
                });
            }
        }

        public IActionResult ViewBook(int bookId)
        {
            IEnumerable<Book> books = GetAllBooks.Where(b => b.BookId == bookId);

            return View("List", new BookListViewModel
            {
                Books = books,
                CurrentGenre = "Search Results"
            });
        }


        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

   

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }


        // Gets all the books from the DB

        public IEnumerable<Book> GetAllBooks
        {
            get
            {
                return _context.Books.Include(c => c.Genre);
            }
        }

    }
}
