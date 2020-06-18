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
    public class CaracteristicInfoModel : PageModel
    {
        private readonly DogsContext _context;

        public CaracteristicInfoModel(DogsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public CaracFisic RazaCarac { get; set; }
        public async Task<ActionResult> OnGet(int id)
        {
            RazaCarac = await _context.Caracteristicas
                .Include(r => r.RazaCaracFisics)
                .ThenInclude(o => o.Raza)
                .SingleOrDefaultAsync(r => r.Id == id);
            if (RazaCarac == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
    }
}