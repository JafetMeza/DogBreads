using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogBredsModel;
using DogsBredsW.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DogsBredsW.Pages.ForwardChaining
{
    public class ResultModel : PageModel
    {
        private readonly DogsContext _context;

        public ResultModel(DogsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Raza Raza { get; set; }
        public async Task<ActionResult> OnGet(int id)
        {
            Raza = await _context.Razas
                .Include(r => r.Origenes)
                .ThenInclude(o => o.Origin)
                .Include(r => r.CaracFisics)
                .ThenInclude(o => o.CaracFisic)
                .Include(r => r.TiposDePelo)
                .ThenInclude(o => o.HairType)
                .SingleOrDefaultAsync(r => r.Id == id);
            if (Raza == null)
            {
                return RedirectToPage("/Error");
            }
            return Page();
        }
    }
}