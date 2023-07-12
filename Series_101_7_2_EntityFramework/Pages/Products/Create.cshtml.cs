using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Series_101_7_2_EntityFramework.Data;
using Series_101_7_2_EntityFramework.Models;

namespace Series_101_7_2_EntityFramework.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly Series_101_7_2_EntityFramework.Data.PizzadbContext _context;

        public CreateModel(Series_101_7_2_EntityFramework.Data.PizzadbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Products == null || Product == null)
            {
                return Page();
            }

            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
