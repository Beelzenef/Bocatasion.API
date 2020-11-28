using Bocatasion.API.Data.Contracts.Entities;
using Bocatasion.API.Models;
using Bogus;
using System.Collections.Generic;
using System.Linq;

namespace Bocatasion.API.QA
{
    public static class SandwichBuilder
    {
        public static SandwichModel BuildValidSandwichModel()
        {
            Faker<SandwichModel> fake = new Faker<SandwichModel>()
                .CustomInstantiator(_ => new SandwichModel())
                .RuleFor(v => v.Id, f => f.Random.Int())
                .RuleFor(v => v.Name, f => f.Random.String2(10))
                .RuleFor(v => v.Description, f => f.Random.String2(20))
                .RuleFor(v => v.Disabled, f => f.Random.Bool())
                .RuleFor(v => v.ImageUrl, f => f.Internet.Url())
                .RuleFor(v => v.Price, f => f.Random.Int());

            return fake.Generate();
        }

        public static IEnumerable<SandwichModel> BuildSandwichModelCollection(int? count = 3)
        {
            Faker faker = new Faker();
            IEnumerable<SandwichModel> items = faker.Make(count.Value, () => BuildValidSandwichModel());

            return items.ToList();
        }

        public static Sandwich BuildValidSandwich(int id)
        {
            Faker<Sandwich> fake = new Faker<Sandwich>()
                .CustomInstantiator(_ => new Sandwich())
                .RuleFor(v => v.Id, f => id == 0 ? f.Random.Int(): id)
                .RuleFor(v => v.Name, f => f.Random.String2(10))
                .RuleFor(v => v.Description, f => f.Random.String2(20))
                .RuleFor(v => v.Disabled, f => f.Random.Bool())
                .RuleFor(v => v.ImageUrl, f => f.Internet.Url())
                .RuleFor(v => v.Price, f => f.Random.Int());

            return fake.Generate();
        }

        public static IEnumerable<Sandwich> BuildValidSandwichCollection(int? count = 3)
        {
            Faker faker = new Faker();
            IEnumerable<Sandwich> items = faker.Make(count.Value, () => BuildValidSandwich(0));

            return items.ToList();
        }
    }
}
