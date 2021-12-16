using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheOnlineBookStore.Models;

namespace TheOnlineBookStore.Data
{
    public class DatabaseInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DatabaseContext>();

                context.Database.EnsureCreated();


                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Author>()
                    {
                       new Author()
                       {
                           //Id = 1,
                           PictureURL = "https://images-na.ssl-images-amazon.com/images/I/41VDzk4kdML._SX450_.jpg",
                           Name = "Joseph Murphy",
                           About = "Dr. Murphy changed the lives of people all over the world. His legacy is being carried forward by the JMWGroupforlife.com and Dr-Joseph-Murphy.com."
                       }

                    });
                    context.SaveChanges();
                }


                if (!context.Publishers.Any())
                {
                    context.Publishers.AddRange(new List<Publisher>()
                    {
                        new Publisher()
                       {
                          //Id = 1,
                           Name = "TarcherPerigee",
                           PictureURL = "https://upload.wikimedia.org/wikipedia/commons/0/02/TarcherPerigee_logo.png",
                           About = "TarcherPerigee is a book publisher and imprint of Penguin Group focused primarily on mind, body and spiritualism titles, founded in 1973 by Jeremy P. Tarcher in Los Angeles."

                       }
                    });
                    context.SaveChanges();
                }

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            //Id = 1,
                            Name = "The Power of your subconscious mind",
                            About = "Here is the complete, original text of the millions-selling self- help guide that reveals your invisible power to attain any goal-paired with a compelling bonus work, How to Attract Money.",
                            Price = 11.50,
                            CoverURL = "https://images-na.ssl-images-amazon.com/images/I/51+L4Ii7L2L._SX349_BO1,204,203,200_.jpg",
                            UnitsSold = 0,
                            UnitsAvailable = 100,
                            Genre = BookGenre.Motivation,
                            PublisherID = 1
                        }

                    });
                    context.SaveChanges();
                }

                if (!context.Authors_Books.Any())
                {
                    context.Authors_Books.AddRange(new List<AuthorsAndBooks>()
                    {
                       new AuthorsAndBooks
                       {
                           AuthorID = 1,
                           BookID = 1
                       }

                    });
                    context.SaveChanges();
                }


            }
        }

        /*
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@theonlinebookstore.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "dbadmin@5510");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@theonlinebookstore.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "user@5510");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
        */
    }
}
