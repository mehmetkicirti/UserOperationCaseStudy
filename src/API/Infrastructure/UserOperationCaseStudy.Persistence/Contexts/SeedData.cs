using Bogus;
using Bogus.DataSets;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserOperationCaseStudy.Domain.Entities;

namespace UserOperationCaseStudy.Persistence.Contexts
{
    public class SeedData
    {
        private static IList<User> GetUsers()
        {
            var result = new Faker<User>("tr")
                .RuleFor(u => u.Id, u => Guid.NewGuid())
                .RuleFor(u => u.BirthDate, u => u.Date.Past(u.Random.Int(1, 70), DateTime.Now))
                .RuleFor(u => u.Name, u => u.Person.UserName)
                .RuleFor(u => u.Surname, u => u.Person.LastName)
                .RuleFor(u => u.ImagePath, u => u.Image.LoremPixelUrl(LoremPixelCategory.People))
                .Generate(15);

            return result;
        }

        public static async Task SeedAsync(IConfiguration configuration)
        {
            var context = new UserOperationDBContext(configuration);
            if (context.Users.Any())
            {
                await Task.CompletedTask;
                return;
            }

            var users = GetUsers();

            await context.AddRangeAsync(users);

            await context.SaveChangesAsync();
        }
    }
}
