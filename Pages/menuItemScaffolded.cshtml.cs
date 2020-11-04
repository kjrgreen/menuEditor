using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using menuEditor.Data;
using menuEditor.Data.Models;

namespace menuEditor.Pages
{
    public class menuItemScaffoldedModel : PageModel
    {
        private readonly menuEditor.Data.ApplicationDbContext _context;

        public menuItemScaffoldedModel(menuEditor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MenuItem MenuItem { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.menuItems.Add(MenuItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./menuEdit");
        }
    }
}
