namespace DrinkAndRate.Data
{
    using DrinkAndRate.Models;
	using Microsoft.AspNet.Identity.EntityFramework;

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
		IRepository<IdentityRole> Roles { get; }

        int SaveChanges();
    }
}