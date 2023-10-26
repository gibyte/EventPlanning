namespace EventPlanning.Model
{
    public class Home : Root
    {
        public List<Event> Events { get; set; }
        public Home()
        {
            Events ??= new List<Event>();
        }
    }
}
