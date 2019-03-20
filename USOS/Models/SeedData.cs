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
                var dontNeedToSeed = context.Students.Any();
                dontNeedToSeed &= context.Teachers.Any();
                dontNeedToSeed &= context.Courses.Any();
                dontNeedToSeed &= context.Semesters.Any();
                dontNeedToSeed &= context.Subjects.Any();

                if (dontNeedToSeed)
                    return;
                if (context.Students.Any() == false)
                {
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
                if (context.Teachers.Any() == false)
                {
                    context.Teachers.AddRange(
                    new Teacher
                    {
                        FirstName = "Wojciech",
                        LastName = "Kowalski",
                        Address = "Zwierzyniecka 11/113 Bialystok",
                        Email = "w.kowalski@gmail.com",
                        Pesel = "36475829330",
                        TelephoneNumber = "123123456",
                        Login = "wkowalski",
                        Password = "kowalskiw"
                    },
                    new Teacher
                    {
                        FirstName = "Robert",
                        LastName = "Nowak",
                        Address = "Kopernika 1/12 Bialystok",
                        Email = "r.nowak@gmail.com",
                        Pesel = "23432567456",
                        TelephoneNumber = "156123456",
                        Login = "rnowak",
                        Password = "root"
                    }
                    );
                    context.SaveChanges();
                }
                if(context.Courses.Any() == false)
                {
                    context.Courses.AddRange(
                        new Course
                        {
                            Name = "Automatyka i robotyka",
                            StartYear = 2013
                        },
                        new Course
                        {
                            Name = "Inzynieria biomedyczna",
                            StartYear = 2017
                        }
                    );
                    context.SaveChanges();
                }
                if (context.Semesters.Any() == false){
                    var course = context.Courses.FirstOrDefault(c => c.Name == "Automatyka i robotyka");
                    context.Semesters.AddRange(
                        new Semester
                        {
                            Since = new DateTime(2013, 9, 29),
                            Until = new DateTime(2014, 1, 31),
                            Course = course
                        },
                        new Semester
                        {
                            Since = new DateTime(2014, 2, 1),
                            Until = new DateTime(2014, 9, 28),
                            Course = course
                        },
                        new Semester
                        {
                            Since = new DateTime(2014, 9, 29),
                            Until = new DateTime(2015, 1, 31),
                            Course = course
                        },
                        new Semester
                        {
                            Since = new DateTime(2015, 2, 1),
                            Until = new DateTime(2015, 9, 28),
                            Course = course
                        },
                        new Semester
                        {
                            Since = new DateTime(2015, 9, 29),
                            Until = new DateTime(2016, 1, 31),
                            Course = course
                        },
                        new Semester
                        {
                            Since = new DateTime(2016, 2, 1),
                            Until = new DateTime(2016, 9, 28),
                            Course = course
                        },
                        new Semester
                        {
                            Since = new DateTime(2016, 9, 29),
                            Until = new DateTime(2017, 1, 31),
                            Course = course
                        }
                        );
                    context.SaveChanges();
                }
                if (context.Subjects.Any() == false)
                {
                    var semester = context.Semesters.FirstOrDefault(s => s.Id == 1);
                    context.Subjects.AddRange(
                        new Subject
                        {
                            Semester = semester,
                            Name = "Matematyka"
                        },
                        new Subject
                        {
                            Semester = semester,
                            Name = "Grafika inzynierska"
                        },
                        new Subject
                        {
                            Semester = semester,
                            Name = "Materialy konstrukcyjne"
                        },
                        new Subject
                        {
                            Semester = semester,
                            Name = "Podstawy informatyki"
                        },
                        new Subject
                        {
                            Semester = semester,
                            Name = "Sieci komputerowe"
                        },
                        new Subject
                        {
                            Semester = semester,
                            Name = "Podstawy ekonomii"
                        },
                        new Subject
                        {
                            Semester = semester,
                            Name = "Podstawy przedsiebiorczosci"
                        },
                        new Subject
                        {
                            Semester = semester,
                            Name = "Bezpieczenstwo i higiena pracy"
                        }
                        );
                    context.SaveChanges();
                }
            }
        }
    }
}
