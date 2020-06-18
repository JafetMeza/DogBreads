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
    public class ActivityModel : PageModel
    {
        private readonly DogsContext _context;

        public ActivityModel(DogsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string Carac { get; set; }
        public List<SelectListItem> Caracteristics { get; set; }
        public async Task<ActionResult> OnGet(int id, int TPid, int Oid)
        {
            var razas = await _context.Razas
                .Include(r => r.TiposDePelo)
                .Include(r => r.Origenes)
                .Include(r => r.CaracFisics).Where(h => 
            h.CaracFisics.Any(x=> x.CaracFisicId == id) &&
            h.Origenes.Any(c => c.OriginId == Oid) &&
            h.TiposDePelo.Any(x => x.HairTypeId == TPid)).ToListAsync();
            if (razas.Count == 1)
                return RedirectToPage("/ForwardChaining/Result", new { id = razas[0].Id });
            Caracteristics = await GenerateList(id, TPid, Oid);
            return Page();
        }

        public async Task<ActionResult> OnPost(int id, int TPid, int Oid)
        {
            Caracteristics = await GenerateList(id, TPid, Oid); 
            if (Carac == "0")
            {
                ModelState.AddModelError("", "Debe seleccionar una opción.");
                return Page();
            }
            return RedirectToPage("/ForwardChaining/Mortality", new { id = id, TPid= TPid, Oid = Oid, Act=Carac });
        }

        public async Task<List<SelectListItem>> GenerateList(int id, int TPid, int Oid)
        {
            var razas = await _context.Razas
                .Include(r => r.TiposDePelo)
                .Include(r => r.Origenes)
                .Include(r => r.CaracFisics)
                .Where(h =>
                    h.CaracFisics.Any(x => x.CaracFisicId == id) &&
                    h.Origenes.Any(c => c.OriginId == Oid) &&
                    h.TiposDePelo.Any(x => x.HairTypeId == TPid)).ToListAsync();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in razas)
            {
                    if (!list.Any(s => s.Value == item.Actividad))
                    {
                        list.Add(new SelectListItem { Value = item.Actividad, Text = item.Actividad });
                    }
            }
            return list;
        }
    }
}