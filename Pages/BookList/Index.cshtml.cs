﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booklist.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Booklist.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book>books { get; set; }

        public async Task OnGet()
        {
            books = await _db.Books.ToListAsync();
        }
    }
}