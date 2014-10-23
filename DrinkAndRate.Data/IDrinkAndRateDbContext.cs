namespace DrinkAndRate.Data
{
    using DrinkAndRate.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IDrinkAndRateDbContext : IDisposable
    {
        IDbSet<Article> Articles { get; set; }

        IDbSet<BeerRating> BeerRatings { get; set; }

        IDbSet<Beer> Beers { get; set; }

        IDbSet<Brand> Brands { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Event> Events { get; set; }

        IDbSet<Image> Images { get; set; }

		IDbSet<UsersEvents> UsersEvents { get; set; }
		IDbSet<AppUser> Users { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}