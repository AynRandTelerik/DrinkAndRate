namespace DrinkAndRate.Data
{
	using DrinkAndRate.Models;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System;
	using System.Collections.Generic;

	public class DrinkAndRateData : IDrinkAndRateData
	{
		private IDrinkAndRateDbContext context;
		private IDictionary<Type, object> repositories;

		public DrinkAndRateData(IDrinkAndRateDbContext context)
		{
			this.context = context;
			this.repositories = new Dictionary<Type, object>();
		}

		public IRepository<Article> Articles
		{
			get
			{
				return this.GetRepository<Article>();
			}
		}

		public IRepository<BeerRating> BeerRatings
		{
			get
			{
				return this.GetRepository<BeerRating>();
			}
		}

		public IRepository<Beer> Beers
		{
			get
			{
				return this.GetRepository<Beer>();
			}
		}

		public IRepository<Brand> Brands
		{
			get
			{
				return this.GetRepository<Brand>();
			}
		}

		public IRepository<Category> Categories
		{
			get
			{
				return this.GetRepository<Category>();
			}
		}

		public IRepository<Comment> Comments
		{
			get
			{
				return this.GetRepository<Comment>();
			}
		}

		public IRepository<Country> Countries
		{
			get
			{
				return this.GetRepository<Country>();
			}
		}

		public IRepository<Event> Events
		{
			get
			{
				return this.GetRepository<Event>();
			}
		}

		public IRepository<Image> Images
		{
			get
			{
				return this.GetRepository<Image>();
			}
		}

		public IRepository<UsersEvents> UsersEvents
		{
			get
			{
				return this.GetRepository<UsersEvents>();
			}
		}

		public IRepository<AppUser> Users
		{
			get
			{
				return this.GetRepository<AppUser>();
			}
		}

		public IRepository<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> Roles
		{
			get
			{
				return this.GetRepository<IdentityRole>();
			}
		}

		public int SaveChanges()
		{
			return this.context.SaveChanges();
		}

		private IRepository<T> GetRepository<T>() where T : class
		{
			var typeOfRepository = typeof(T);
			if (!this.repositories.ContainsKey(typeOfRepository))
			{
				var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
				this.repositories.Add(typeOfRepository, newRepository);
			}

			return (IRepository<T>)this.repositories[typeOfRepository];
		}
	}
}