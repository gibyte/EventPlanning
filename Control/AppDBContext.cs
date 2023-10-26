using EventPlanning.Model;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning.Control
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<Home> Homes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Nomenclature> Nomenclatures { get; set; }
        public DbSet<NomenclatureLink> NomenclatureLinks { get; set; }
    }
}