using EventPlanning.Model;
using System.Collections;

namespace EventPlanning.Control
{
    public interface IRepozitory
    {
        Home? AddHome(Home home);
        Home? GetHome();

        Event? AddEvent(Event evnt);
        Event? UpEvent(Event evnt);
        Event? DeleteEvent(int id);
        Event? GetEvent(int id);
        IEnumerable GetEvents(string name);

        Nomenclature? GetNomenclature(int id);
        Nomenclature? UpNomenclature(Nomenclature nom);
        Nomenclature? DeleteNomenclature(int id);

        NomenclatureLink? AddLink(string link);
        NomenclatureLink? GetLink(int id);
        NomenclatureLink? DeleteLink(int id);
       
    }
}
