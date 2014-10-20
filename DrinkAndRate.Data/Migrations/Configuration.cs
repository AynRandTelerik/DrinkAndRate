namespace DrinkAndRate.Data.Migrations
{
    using DrinkAndRate.Models;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DrinkAndRateDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DrinkAndRateDbContext context)
        {
            var hasCountry = context.Countries.Any();

            if (!hasCountry)
            {
                var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\countries.json");
                var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);

                foreach (var contry in countries)
                {
                    context.Countries.Add(contry);
                }

                context.SaveChanges();
            }

            var hasCategories = context.Categories.Any();

            if (!hasCategories)
            {
                context.Categories.AddOrUpdate(
                    new Category { Name = "Dark" },
                    new Category { Name = "Light" }
                );
            }
        }
    }
}