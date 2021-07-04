using BOOK.API.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOK.API.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book Title",
                        Author = "1st Book Author",
                        Description = "1st Book Description",
                        CreatedDate = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2nd Book Title",
                        Author = "2nd Book Author",
                        CreatedDate = DateTime.Now
                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
