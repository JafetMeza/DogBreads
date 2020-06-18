using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogBredsModel;
using DogsBredsW.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DogsBredsW.Pages.BackwardChaining
{
    public class RazasModel : PageModel
    {
        private readonly DogsContext _context;

        public RazasModel(DogsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Raza> Razas { get; set; }
        public async Task<ActionResult> OnGet()
        {
            Razas = new List<Raza>();
            Razas = await _context.Razas.ToListAsync();
            return Page();
        }
    }
}