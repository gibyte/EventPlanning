using EventPlanning.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace EventPlanning.Control
{
    public class IRepozitorySQLite : IRepozitory
    {
        private readonly AppDBContext _context;
        public IRepozitorySQLite(AppDBContext context)
        {
            _context = context;
            Initialization();
        }

        private void Initialization()
        {
            if (!_context.Homes.Any())
            {
                AddHome(new Home() { Name = "Планировщик событий" });
            }
        }

        public Home? AddHome(Home home) 
        {
            _context.Homes.Add(home);
            _context.SaveChanges();
            return home;
        }

        public Home? GetHome()
        {
            //return _context.Homes.Include(h => h.Evens).FirstOrDefault();
            return _context.Homes.Include(h => h.Events).FirstOrDefault();
        }

        public Event? AddEvent(Event evnt)
        {
            Home? home = GetHome();
            if (home == null) return null;
            home.Events.Add(evnt);
            _context.SaveChanges();
            return evnt;
        }
        public Event? GetEvent(int id)
        {
            Event? evnt = _context.Events
                .Include(e => e.Nomenclatures).ThenInclude(e => e.Links)
                .Where(e => e.Id == id)
                .ToList()
                .FirstOrDefault();
            return evnt;
        }

        public IEnumerable GetEvents(string name)
        {
            var evnts = _context.Events
                .Include(c => c.Nomenclatures)
                .Where(c => c.Id > 0)
                .OrderByDescending(c => c.Id);
            return evnts;
        }

        public Event? UpEvent(Event evnt) 
        { 
            if (evnt == null) return null;
            if (evnt.Id == 0) return AddEvent(evnt);
            Event? evntDB = GetEvent(evnt.Id);
            if (evntDB == null) return null;
            evntDB.Name = evnt.Name;
            evntDB.DateTime = evnt.DateTime;
            evntDB.Edit = false;
            var newNom = evnt.Nomenclatures.Where(n => n.Id == 0).ToList();
            foreach (var nom in newNom) 
            {
                evntDB.Nomenclatures.Add(nom);
            }
            foreach (var nom in evnt.Nomenclatures)
            {
                var newLinks = nom.Links.Where(n => n.Id == 0).ToList();
                foreach (var link in newLinks)
                {
                    var nomDb = evntDB.Nomenclatures.Where(e => e.Id == nom.Id).ToList().FirstOrDefault();
                    nomDb?.Links.Add(link);;
                }
            }
            _context.SaveChanges();
            return evntDB;
        }
        public Event? DeleteEvent(int id) 
        {
            Home? home = GetHome();
            if (home == null) return null;
            var evntDB = _context.Events
                .Where(e => e.Id == id)
                .ToList()
                .FirstOrDefault();
            if (evntDB == null) return null;
            home.Events.Remove(evntDB);
            _context.SaveChanges();
            return evntDB;
        }

        public NomenclatureLink? GetLink(int id)
        {
            NomenclatureLink? link = _context.NomenclatureLinks.Where(n => n.Id == id).FirstOrDefault();
            return link;
        }

        public NomenclatureLink? AddLink(string link)
        {
            var dbLink = _context.NomenclatureLinks.Where(l => l.Link == link).FirstOrDefault();
                
            if (dbLink == null)
            {
                dbLink = new NomenclatureLink { Link = link };
                _context.NomenclatureLinks.Add(dbLink);
                _context.SaveChanges();
            }
            return dbLink;
        }

        public NomenclatureLink? DeleteLink(int id)
        {
            NomenclatureLink? link = GetLink(id);
            if (link == null) return null;
            _context.NomenclatureLinks.Remove(link);
            _context.SaveChanges();
            return link;
        }

        public Nomenclature? GetNomenclature(int id)
        {
            Nomenclature? nom = _context.Nomenclatures.Where(n => n.Id == id).Include( n => n.Links ).FirstOrDefault();
            return nom;
        }

        public Nomenclature? UpNomenclature(Nomenclature nom)
        {
            Nomenclature? nomDB = GetNomenclature(nom.Id);
            if (nomDB == null) return null;
            nomDB.Name = nom.Name;
            nom.Description = nomDB.Description;
            foreach (var linkDB in nomDB.Links) 
            { 
                var upLinks = nom.Links.Where( l => l.Id == linkDB.Id ).ToList().FirstOrDefault();
                if (upLinks == null) nomDB.Links.Add(upLinks);
            }
            _context.SaveChanges();
            return nomDB;
        }

        public Nomenclature? DeleteNomenclature(int id)
        {
            Nomenclature? nom = GetNomenclature(id);
            if (nom == null) return null;
            _context.Nomenclatures.Remove(nom);
            _context.SaveChanges();
            return nom;
        }

    }
}
