namespace DrinkAndRate.Data
{
    using DrinkAndRate.Data.Migrations;
    using DrinkAndRate.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class DrinkAndRateDbContext : IdentityDbContext<AppUser>, IDrinkAndRateDbContext
    {
        public DrinkAndRateDbContext()
            : base("DrinkAndRate", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DrinkAndRateDbContext, Configuration>());
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<BeerRating> BeerRatings { get; set; }

        public virtual IDbSet<Beer> Beers { get; set; }

        public virtual IDbSet<Brand> Brands { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<UsersEvents> UsersEvents { get; set; }

        public static DrinkAndRateDbContext Create()
        {
            return new DrinkAndRateDbContext();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Beer>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.Beer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Beer>()
                .HasMany(e => e.BeerRatings)
                .WithRequired(e => e.Beer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Beer>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Beer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Beer>()
                .HasMany(e => e.Images)
                .WithMany(e => e.Beers)
                .Map(m => m.ToTable("BeersImages")
                .MapLeftKey("BeerID")
                .MapRightKey("ImageID"));

            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Beers)
                .WithRequired(e => e.Brand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Beers)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Brands)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.UsersEvents)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Image>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Image)
                .WillCascadeOnDelete(false);
        }
    }
}