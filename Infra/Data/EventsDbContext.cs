using abc.Facade.Models;
using Microsoft.EntityFrameworkCore;

namespace abc.Infra.Data
{
    public class EventsDbContext : DbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public EventsDbContext(DbContextOptions<EventsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            InitializeTables(builder);
        }

        public static void InitializeTables(ModelBuilder builder)
        {
            builder.Entity<Event>().ToTable(nameof(Events));
            builder.Entity<Participant>().ToTable(nameof(Participants));
            builder.Entity<Enrollment>().ToTable(nameof(Enrollments));
        }
    }
}