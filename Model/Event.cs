namespace EventPlanning.Model
{
    public class Event : Root
    {
        public DateTime DateTime { get; set; }
        public List<Nomenclature> Nomenclatures { get; set; }
        public Event() 
        {
            Nomenclatures ??= new List<Nomenclature>();
        }
    }
}