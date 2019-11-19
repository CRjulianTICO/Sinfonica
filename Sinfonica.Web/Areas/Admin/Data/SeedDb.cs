using Microsoft.AspNetCore.Identity;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using Sinfonica.Web.Areas.Admin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data
{
    public class SeedDb
    {
        private readonly UserManager<Sinfonica.Web.Areas.Admin.Data.Entities.User> userManager;
        private readonly DataContext context;
        private Random random;
        private readonly IUserHelper userHelper;

        public SeedDb(DataContext context, UserManager<Sinfonica.Web.Areas.Admin.Data.Entities.User> userManager, IUserHelper userHelper)
        {
            this.context = context;
            this.random = new Random();
            this.userHelper = userHelper;
            this.userManager = userManager;
        }





        public async Task SeedAsync()
        {


            await this.context.Database.EnsureCreatedAsync();


            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");




            var user = await this.userHelper.GetUserByEmailAsync("juan@gmail.com");
            if (user == null)
            {
                user = new Sinfonica.Web.Areas.Admin.Data.Entities.User
                {
                    FirstName = "Juan",
                    LastName = "Zuluaga",
                    Email = "juan@gmail.com",
                    UserName = "juan@gmail.com",
                    PhoneNumber = "35025652981"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder 1");
                }

                //  await this.userHelper.AddUserToRoleAsync(user, "Admin");

            }



            var user2 = await this.userHelper.GetUserByEmailAsync("pedro@gmail.com");
            if (user2 == null)
            {
                user2 = new Sinfonica.Web.Areas.Admin.Data.Entities.User
                {
                    FirstName = "Pedro",
                    LastName = "Martinez",
                    Email = "pedro@gmail.com",
                    UserName = "pedro@gmail.com",
                    PhoneNumber = "7452652981"
                };

                var result2 = await this.userHelper.AddUserAsync(user2, "123456");

                if (result2 != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder 2");
                }

                // await this.userHelper.AddUserToRoleAsync(user2, "Customer");

            }




            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isInRole2 = await this.userHelper.IsUserInRoleAsync(user2, "Customer");
            if (!isInRole2)
            {
                await this.userHelper.AddUserToRoleAsync(user2, "Customer");
            }



            /*

            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("iWatch Series 4", user);
                this.AddProduct("iPad Air 2", user);
                await this.context.SaveChangesAsync();
            }
        }*/





            /*

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailable = true,
                Stock = this.random.Next(100),
                LastPurchase = System.DateTime.Now,
                LastSale = System.DateTime.Now,
                User = user
            });
        }*/




        }
    }
}
