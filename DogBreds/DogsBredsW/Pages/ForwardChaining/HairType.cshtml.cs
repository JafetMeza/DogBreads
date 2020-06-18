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
    public class HairTypeModel : PageModel
    {
        private readonly DogsContext _context;

        public HairTypeModel(DogsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string Carac { get; set; }
        public List<SelectListItem> Caracteristics { get; set; }
        public async Task<ActionResult> OnGet(int id)
        {
            var razas = await _context.Razas.Where(h => h.CaracFisics.Any(c => c.CaracFisicId == id)).ToListAsync();
            if (razas.Count == 1)
                return RedirectToPage("/ForwardChaining/Result", new { id = razas[0].Id });
            Caracteristics = await GenerateList(id);
            return Page();
        }

        public async Task<ActionResult> OnPost(int id)
        {
            Caracteristics = await GenerateList(id);
            if (Carac == "0")
            {
                ModelState.AddModelError("", "Debe seleccionar una opción.");
                return Page();
            }
            return RedirectToPage("/ForwardChaining/Origin", new { id = id, TPid = int.Parse(Carac) });
        }

        public async Task<List<SelectListItem>> GenerateList(int id)
        {
            var razas = await _context.Razas
                .Include(r => r.TiposDePelo)
                .ThenInclude(t => t.HairType)
                .Where(h => h.CaracFisics.Any(c => c.CaracFisicId == id)).ToListAsync();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach(var item in razas)
            {
                foreach(var ptype in item.TiposDePelo)
                {

                    if (!list.Any(s => s.Value == ptype.HairTypeId.ToString()))
                    {
                        list.Add(new SelectListItem { Value = ptype.HairTypeId.ToString(), Text = ptype.HairType.Nombre });
                    }
                }
            }
            return list;
        }
    }
}