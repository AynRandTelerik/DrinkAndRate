namespace DrinkAndRate.Data
{
    using DrinkAndRate.Models;

    public interface IDrinkAndRateData
    {
        IRepository<Article> Articles { get; }

        IRepository<BeerRating> BeerRatings { get; }

        IRepository<Beer> Beers { get; }

        IRepository<Brand> Brands { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Country> Countries { get; }

        IRepository<Event> Events { get; }

        IRepository<Image> Images { get; }

        IRepository<UsersEvents> UsersEvents { get; }

        IRepository<AppUser> Users { get; }

        int SaveChanges();
    }
}