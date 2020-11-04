using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using menuEditor.Data;
using menuEditor.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace menuEditor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;
        public List<MenuItem> MenuItems { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }



        async public Task OnGetAsync()
        {
            MenuItems = await _context.menuItems.ToListAsync();
        }
    }
}
