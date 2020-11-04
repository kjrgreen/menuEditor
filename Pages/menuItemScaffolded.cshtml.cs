using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using menuEditor.Data;
using menuEditor.Data.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id != null)
            {
                //Add child
                MenuItem parentItem = await _context.menuItems.FirstOrDefaultAsync(m => m.Id == id);
                MenuItem.ParentId = parentItem.Id;
                if (parentItem.Children == null) parentItem.Children = new List<MenuItem>();
                parentItem.Children.Add(MenuItem);
                _context.Attach(parentItem).State = EntityState.Modified;
                try {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuItemExists(MenuItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToPage("./menuEdit");
            }
            else
            {
                //Add top level item
                _context.menuItems.Add(MenuItem);
                await _context.SaveChangesAsync();

                return RedirectToPage("./menuEdit");
            }

        }

        private bool MenuItemExists(int id)
        {
            return _context.menuItems.Any(e => e.Id == id);
        }
    }
}
