using CSWork21.Contexts;
using CSWork21.Enities;
using Microsoft.AspNetCore.Identity;
using CSWork21.Models;
using System.Threading.Tasks;

namespace CSWork21.Data
{
    public static class CreateDB
    {
        public static void PhoneBook(PhoneBookDbContext dbcontext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, bool withTestData = false)
        {
            bool hasCreated = dbcontext.Database.EnsureCreated();

            if (hasCreated && withTestData)
            {
                for (int i = 0; i <= 10; i++)
                    dbcontext.Add(CreateContact(i));

                Task creator = CreateRoles(roleManager, userManager);
                creator.Wait();

                dbcontext.SaveChanges();
            }
        }

        private static Contact CreateContact(int num)
        {
            Contact contact = new Contact();
            contact.FirstName = $"Name{num}";
            contact.LastName = $"LastName{num}";
            contact.ThirdName = $"ThirdName{num}";
            contact.Phone = $"{num}{num}{num}{num}";
            contact.Address = $"Address{num}";
            contact.Desc = $"Desc{num}";
            return contact;
        }

        private async static Task<bool> CreateRoles(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            await roleManager.CreateAsync(new IdentityRole("user"));
            await roleManager.CreateAsync(new IdentityRole("administrator"));

            await CreateUser(userManager, "user", "1234", "user");
            await CreateUser(userManager, "admin", "1234", "administrator");
            return true;
        }

        private async static Task<bool> CreateUser(UserManager<User> userManager, string login, string password, string role)
        {
            var user = new User { UserName = login };
            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, role);
            return true;
        }
    }

    
}
