using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USOSData;
using USOSData.Models;

namespace USOS.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new USOSContext(
                serviceProvider.GetRequiredService<DbContextOptions<USOSContext>>()))
            {
                if (context.Students.Any())
                    return;

                context.Students.AddRange(
                    new Student
                    {
                        FirstName = "Mateusz",
                        LastName = "Adamowicz",
                        Address = "Wiejska 6/75 Bialystok",
                        Email = "mateusz.adamowicz.1994@gmail.com",
                        IndexNumber = "93072",
                        Pesel = "12345678901",
                        TelephoneNumber = "123123456",
                        Login = "kotwica407",
                        Password = "admin"
                    },
                    new Student
                    {
                        FirstName = "Robert",
                        LastName = "Wawrzyniak",
                        Address = "Kreta 2/11 Warszawa",
                        Email = "r.kreta.1994@gmail.com",
                        IndexNumber = "93472",
                        Pesel = "12345678131",
                        TelephoneNumber = "123123456",
                        Login = "rwaw",
                        Password = "root"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
