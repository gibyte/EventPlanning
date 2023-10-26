using EventPlanning.Model;
using System.Collections;

namespace EventPlanning.Control
{
    public class IRepozitoryMSSQL : IRepozitory
    {
        private readonly AppDBContext _context;
        public IRepozitoryMSSQL(AppDBContext context)
        {
            _context = context;
        }

        public Home? GetHome(int id)
        {
            throw new NotImplementedException();
        }
        public Event? GetEvent(int id)
        {
            throw new NotImplementedException();
        }
        public void AddLink(string link)
        {
            throw new NotImplementedException();
        }

        Home? IRepozitory.AddHome(Home home)
        {
            throw new NotImplementedException();
        }

        Home? IRepozitory.GetHome()
        {
            throw new NotImplementedException();
        }

        Event? IRepozitory.GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public Event? AddEvent(Event evnt)
        {
            throw new NotImplementedException();
        }

        Event? IRepozitory.AddEvent(Event evnt)
        {
            throw new NotImplementedException();
        }

        Event? IRepozitory.UpEvent(Event evnt)
        {
            throw new NotImplementedException();
        }

        Event? IRepozitory.DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public NomenclatureLink? DeleteLink(int id)
        {
            throw new NotImplementedException();
        }

        public Nomenclature? UpNomenclature(Nomenclature nom) 
        {
            throw new NotImplementedException();
        }
        public Nomenclature? DeleteNomenclature(int id)
        {
            throw new NotImplementedException();
        }

        public Nomenclature? GetNomenclature(int id)
        {
            throw new NotImplementedException();
        }

        public NomenclatureLink? GetLink(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetEvents(string name)
        {
            throw new NotImplementedException();
        }

        IEnumerable IRepozitory.GetEvents(string name)
        {
            throw new NotImplementedException();
        }

        Nomenclature? IRepozitory.GetNomenclature(int id)
        {
            throw new NotImplementedException();
        }

        Nomenclature? IRepozitory.DeleteNomenclature(int id)
        {
            throw new NotImplementedException();
        }

        NomenclatureLink? IRepozitory.AddLink(string link)
        {
            throw new NotImplementedException();
        }

        NomenclatureLink? IRepozitory.GetLink(int id)
        {
            throw new NotImplementedException();
        }

        NomenclatureLink? IRepozitory.DeleteLink(int id)
        {
            throw new NotImplementedException();
        }

    }
}
