using EventPlanning.Control;
using EventPlanning.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventPlanning.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRepozitory _db;
        [BindProperty]
        public Home? Home { get; set; }
        public IndexModel( IRepozitory db)
        {
            _db = db;
        }
        public IActionResult OnGet(int delEvent = 0)
        {
            if (delEvent>0) _db.DeleteEvent(delEvent);
            Home = _db.GetHome();
            if (Home == null) return NotFound();
            return Page();
        }
    }
}