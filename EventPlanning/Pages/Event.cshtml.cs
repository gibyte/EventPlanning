using EventPlanning.Control;
using EventPlanning.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventPlanning.Pages
{
    public class EventModel : PageModel
    {
        private readonly IRepozitory _db;
        [BindProperty]
        public Event? Event { get; set; }
        public EventModel(IRepozitory db)
        {
            _db = db;
        }

        public IActionResult OnGet(int id, bool addNomencl = false, int urlNomencl = 0, int editNomencl = 0, int delNomencl = 0, int delLink = 0)
        {
            if (delNomencl > 0 ) _db.DeleteNomenclature(delNomencl);
            if (delLink > 0 ) _db.DeleteLink(delLink);
            if (id == 0) Event = new() { Edit = true };
            else Event = _db.GetEvent(id);
            if (Event == null) return NotFound();
            if (editNomencl > 0)
            { 
                Nomenclature? nom = Event.Nomenclatures.Where(e => e.Id == editNomencl).FirstOrDefault();
                if (nom != null) { nom.Edit = true; }
            }
            if (urlNomencl > 0)
            {
                Nomenclature? nom = Event.Nomenclatures.Where(e => e.Id == urlNomencl).FirstOrDefault();
                nom?.Links.Add(new NomenclatureLink { Edit = true });
            }
            if (addNomencl) Event.Nomenclatures.Add(new Nomenclature { Edit = true });
            return Page();
        }

        public IActionResult OnPost()
        {
            //if(!ModelState.IsValid)
            //{
            //    return Page();
            //}
            if (Event == null) return NotFound();
            Event = _db.UpEvent(Event);
            if (Event == null) return NotFound();
            return Page();
        }

    }
}
