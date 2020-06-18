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
    public class OriginModel : PageModel
    {
        private readonly DogsContext _context;

        public OriginModel(DogsContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string Carac { get; set; }
        public List<SelectListItem> Caracteristics { get; set; }
        public async Task<ActionResult> OnGet(int id, int TPid)
        {
            var razas = await _context.Razas.Where(h => 
            h.CaracFisics.Any(c => c.CaracFisicId == id) &&
            h.TiposDePelo.Any(c => c.HairTypeId == TPid)).ToListAsync();
            if (razas.Count == 1)
                return RedirectToPage("/ForwardChaining/Result", new { id = razas[0].Id });
            Caracteristics = await GenerateList(id, TPid);
            return Page();
        }

        public async Task<ActionResult> OnPost(int id, int TPid)
        {
            Caracteristics = await GenerateList(id, TPid);
            if (Carac == "0")
            {
                ModelState.AddModelError("", "Debe seleccionar una opción.");
                return Page();
            }
            return RedirectToPage("/ForwardChaining/Activity", new { id = id, TPid = TPid, Oid = int.Parse(Carac) });
        }

        public async Task<List<SelectListItem>> GenerateList(int id, int TPid)
        {
            var razas = await _context.Razas
                .Include(r => r.Origenes)
                .ThenInclude(t => t.Origin)
                .Include(r => r.CaracFisics)
                .Where(h => h.TiposDePelo.Any(c => c.HairTypeId == TPid) &&
                h.CaracFisics.Any(c => c.CaracFisicId == id)).ToListAsync();
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in razas)
            {
                foreach (var Origin in item.Origenes)
                {

                    if (!list.Any(s => s.Value == Origin.OriginId.ToString()))
                    {
                        list.Add(new SelectListItem { Value = Origin.OriginId.ToString(), Text = Origin.Origin.Nombre });
                    }
                }
            }
            return list;
        }
    }
}