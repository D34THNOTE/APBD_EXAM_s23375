

using Microsoft.EntityFrameworkCore;

namespace Exam.Models
{
    public class MainDbContext : DbContext
    {
        public MainDbContext()
        {
        }

        public MainDbContext(DbContextOptions opt)
        : base(opt)
        {
        }
        
        
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artist_Event> ArtistEvents { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Organiser> Organisers { get; set; }
        public DbSet<Event_Organiser> EventsOrganisers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies(); // need to use this because related data wouldn't load otherwise
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=master;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Artist>(opt =>
            {
                opt.HasData(
                    new Artist { IdArtist = 1, Nickname = "art1"},
                    new Artist { IdArtist = 2, Nickname = "art2"}
                );
            });
            
            modelBuilder.Entity<Event>(opt =>
            {
                opt.HasData(
                    new Event { IdEvent = 1, Name = "Test event 1", StartDate = DateTime.Now, 
                        EndDate = DateTime.Now.AddHours(8)},
                    new Event { IdEvent = 2, Name = "Test event 2", StartDate = DateTime.Now.AddDays(1), 
                        EndDate = DateTime.Now.AddDays(1).AddHours(8)}
                );
            });
            
            modelBuilder.Entity<Organiser>(opt =>
            {
                opt.HasData(
                    new Organiser { IdOrganiser = 1, Name = "Organizer 1"},
                    new Organiser { IdOrganiser = 2, Name = "Organizer 2"}
                );
            });
            
            modelBuilder.Entity<Artist_Event>(opt =>
            {
                opt.HasKey(e => new { e.IdArtist, e.IdEvent }).HasName("Artist_Event_pk");
                
                opt.HasOne(ae => ae.Artist)
                    .WithMany(a => a.ArtistEvents)
                    .HasForeignKey(ae => ae.IdArtist)
                    .OnDelete(DeleteBehavior.Cascade);
                
                opt.HasOne(ae => ae.Event)
                    .WithMany(a => a.ArtistEvents)
                    .HasForeignKey(ae => ae.IdEvent)
                    .OnDelete(DeleteBehavior.Cascade);
                
                opt.HasData(
                    new Artist_Event { IdEvent = 1, IdArtist = 2, PerformanceDate = DateTime.Now.AddHours(5)},
                    new Artist_Event { IdEvent = 2, IdArtist = 2, PerformanceDate = DateTime.Now.AddDays(1).AddHours(5)}
                );
            });
            
            modelBuilder.Entity<Event_Organiser>(opt =>
            {
                opt.HasKey(e => new { e.IdEvent, e.IdOrganiser }).HasName("Event_Organiser`_pk");
                
                opt.HasOne(eo => eo.Organiser)
                    .WithMany(a => a.EventOrganisers)
                    .HasForeignKey(eo => eo.IdOrganiser)
                    .OnDelete(DeleteBehavior.Cascade);
                
                opt.HasOne(eo => eo.Event)
                    .WithMany(a => a.EventOrganisers)
                    .HasForeignKey(eo => eo.IdEvent)
                    .OnDelete(DeleteBehavior.Cascade);
                
                opt.HasData(
                    new Event_Organiser { IdEvent = 1, IdOrganiser = 1},
                    new Event_Organiser { IdEvent = 2, IdOrganiser = 2}
                );
            });

        }

    }
}