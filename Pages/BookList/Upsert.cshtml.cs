using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booklist.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Booklist.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            book = new Book();
            if(id==null)
            {
                //create
                return Page();
            }
            //update
            book = await _db.Books.FirstOrDefaultAsync(u=>u.ID==id);
            if(book==null)
            {
                return NotFound();
            }
            return Page();
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (book.ID==0)
                {
                    _db.Books.Add(book);
                }
                else
                {
                    _db.Books.Update(book);
                }

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