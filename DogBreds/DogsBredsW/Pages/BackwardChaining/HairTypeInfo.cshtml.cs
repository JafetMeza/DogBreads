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
    public class HairTypeInfoModel : PageModel
    {
        private readonly DogsContext _context;

        public HairTypeInfoModel(DogsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public HairType HairType { get; set; }
        public async Task<ActionResult> OnGet(int id)
        {
            HairType = await _context.HairTypes
                .Include(r => r.RazaHairTypes)
                .ThenInclude(o => o.Raza)
                .SingleOrDefaultAsync(r => r.Id == id);
            if (HairType == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
    }
}