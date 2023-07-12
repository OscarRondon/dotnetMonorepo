using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Series_101_7_2_EntityFramework.Data;
using Series_101_7_2_EntityFramework.Models;
using Series_101_7_2_EntityFramework.Pages;

namespace Series_101_7_2_EntityFramework.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Series_101_7_2_EntityFramework.Data.PizzadbContext _context;

        public IndexModel(Series_101_7_2_EntityFramework.Data.PizzadbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Products != null)
            {
                Product = await _context.Products.ToListAsync();
            }
        }
    }
}
