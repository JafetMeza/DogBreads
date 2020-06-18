using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogsBredsW.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DogsBredsW.Pages.ForwardChaining
{
    public class HomeModel : PageModel
    {
        private readonly DogsContext _context;

        public HomeModel(DogsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string Carac { get; set; }
        public List<SelectListItem> Caracteristics { get; set; }
        public async Task<ActionResult> OnGet()
        {
            Caracteristics = await GenerateList();
            return Page();
        }

        public async Task<ActionResult> OnPost()
        {
            Caracteristics = await GenerateList();
            if (Carac == "0")
            {
                ModelState.AddModelError("", "Debe seleccionar una opción.");
                return Page();
            }
            return RedirectToPage("/ForwardChaining/HairType", new { id = int.Parse(Carac) });
        }

        public async Task<List<SelectListItem>> GenerateList()
        {
            var caracteristicas = await _context.Caracteristicas.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nombre
            }).ToListAsync();
            return caracteristicas;
        }
    }
}