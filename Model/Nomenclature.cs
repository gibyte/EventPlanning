namespace EventPlanning.Model
{
    public class Nomenclature : Root
    {
        public List<NomenclatureLink> Links { get; set; }
        public Nomenclature()
        {
            Links ??= new List<NomenclatureLink>();
        }
    }
}
