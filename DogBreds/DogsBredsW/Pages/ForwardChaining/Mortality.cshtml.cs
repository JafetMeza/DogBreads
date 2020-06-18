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
    public class MortalityModel : PageModel
    {
        private readonly DogsContext _context;

        public MortalityModel(DogsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string Carac { get; set; }
        public List<SelectListItem> Caracteristics { get; set; }
        public async Task<ActionResult> OnGet(int id, int TPid, int Oid, string Act)
        {
            var razas = await _context.Razas
                .Include(r => r.TiposDePelo)
                .Include(r => r.Origenes)
                .Include(r => r.CaracFisics).Where(h =>
            h.CaracFisics.Any(c => c.CaracFisicId == id) &&
            h.TiposDePelo.Any(t => t.HairTypeId == TPid) &&
            h.Origenes.Any(o => o.OriginId == Oid) &&
            h.Actividad == Act).ToListAsync();
            if (razas.Count == 1)
                return RedirectToPage("/ForwardChaining/Result", new { id = razas[0].Id });
            Caracteristics = await GenerateList(id, TPid, Oid, Act);
            return Page();
        }

        public async Task<ActionResult> OnPost(int id, int TPid, int Oid, string Act)
        {
            Caracteristics = await GenerateList(id, TPid, Oid, Act);
            if (Carac == "0")
            {
                ModelState.AddModelError("", "Debe seleccionar una opción.");
                return Page();
            }
            return RedirectToPage("/ForwardChaining/Heigth", new { id = id, TPid = TPid, Oid = Oid, Act = Act, Mor = Carac });
        }

        public async Task<List<SelectListItem>> GenerateList(int id, int TPid, int Oid, string Act)
        {
            var razas = await _context.Razas
                .Include(r => r.TiposDePelo)
                .Include(r => r.Origenes)
                .Include(r => r.CaracFisics).Where(h =>
            h.CaracFisics.Any(c => c.CaracFisicId == id) &&
            h.TiposDePelo.Any(t => t.HairTypeId == TPid) &&
            h.Origenes.Any(o => o.OriginId == Oid) &&
            h.Actividad == Act).ToListAsync();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in razas)
            {
                if (!list.Any(s => s.Value == item.EsperanzaDeVida))
                {
                    list.Add(new SelectListItem { Value = item.EsperanzaDeVida, Text = item.EsperanzaDeVida });
                }
            }
            return list;
        }
    }
}