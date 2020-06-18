using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogBredsModel;
using DogsBredsW.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DogsBredsW.Pages.BackwardChaining
{
    public class OriginInfoModel : PageModel
    {
        private readonly DogsContext _context;

        public OriginInfoModel(DogsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Origin Origin { get; set; }
        public async Task<ActionResult> OnGet(int id)
        {
            Origin = await _context.Origenes
                .Include(r => r.RazaOrigenes)
                .ThenInclude(o => o.Raza)
                .SingleOrDefaultAsync(r => r.Id == id);
            if (Origin == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
    }
}