using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booklist.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Booklist.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book book { get; set; }

        public async Task OnGet(int id)
        {
            book = await _db.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var BookFromDb = await _db.Books.FindAsync(book.ID);
                BookFromDb.Name = book.Name;
                BookFromDb.Author = book.Author;
                BookFromDb.ISBN = book.ISBN;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}