using Microsoft.AspNetCore.Identity;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using Sinfonica.Web.Areas.Admin.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
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


            var user3 = await this.userHelper.GetUserByEmailAsync("inmnoreply@gmail.com");

            if (user3 == null)
            {
                user3 = new Sinfonica.Web.Areas.Admin.Data.Entities.User
                {
                    FirstName = "INM",
                    LastName = "NoReply",
                    Email = "inmnoreply@gmail.com",
                    UserName = "inmnoreply@gmail.com",
                    PhoneNumber = "60439999"
                };

                var result3 = await this.userHelper.AddUserAsync(user3, "123456");

                if (result3 != IdentityResult.Success)
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


            var isInRole3 = await this.userHelper.IsUserInRoleAsync(user3, "Admin");
            if (!isInRole3)
            {
                await this.userHelper.AddUserToRoleAsync(user3, "Admin");
                var token = await this.userHelper.GenerateEmailConfirmationTokenAsync(user3);
                await this.userHelper.ConfirmEmailAsync(user3, token);
            }
            


            if (!this.context.Departamentos.Any())
            {
                this.AddDepartamento("Tecnicas Musicales");
                this.AddDepartamento("Vientos y Percusion");
                this.AddDepartamento("Cuerdas");

                if (!this.context.Catedras.Any())
                {
                    var dep1 = await this.context.Departamentos.FindAsync(1);
                    var dep2 = await this.context.Departamentos.FindAsync(2);
                    var dep3 = await this.context.Departamentos.FindAsync(3);
                    this.AddCatedra("Saxofon",dep2 );
                    this.AddCatedra("Sin Catedra", dep1);
                    this.AddCatedra("Violines", dep3);
                    this.AddCatedra("Trombon", dep2);
                    this.AddCatedra("Clarinete", dep2);

                    if (!this.context.Profesors.Any())
                    {
                        var cat1 = await this.context.Catedras.FindAsync(1);
                        var cat2 = await this.context.Catedras.FindAsync(2);
                        var cat3 = await this.context.Catedras.FindAsync(3);
                        var cat4= await this.context.Catedras.FindAsync(4);
                        var cat5 = await this.context.Catedras.FindAsync(5);
                        CultureInfo culture = new CultureInfo("en-US");
                        DateTime dt1 = Convert.ToDateTime("01/21/1977 12:10:15 PM", culture);
                        DateTime dt2 = Convert.ToDateTime("05/09/1967 12:10:15 PM", culture);
                        DateTime dt3 = Convert.ToDateTime("10/01/1987 12:10:15 PM", culture);
                        DateTime dt4 = Convert.ToDateTime("09/15/1970 12:10:15 PM", culture);

                        this.AddProfesor("Oscar", "Soto", "Leon", "oscar@gmail.com", dt1, cat2, dep1);
                        this.AddProfesor("Harold", "Guillen", "Monge", "harold@gmail.com", dt2, cat1, dep2);
                        this.AddProfesor("Pedro", "Mora", "Solis", "pedtiro@gmail.com", dt3, cat3, dep3);
                        this.AddProfesor("Karina", "Perez", "Ramirez", "karina@gmail.com", dt4, cat5, dep2);


                    }

                }

            }

            if (!this.context.Directors.Any())
            {
                CultureInfo culture = new CultureInfo("en-US");
                DateTime dt1 = Convert.ToDateTime("01/21/1977 12:10:15 PM", culture);
                DateTime dt2 = Convert.ToDateTime("05/09/1967 12:10:15 PM", culture);
                DateTime dt3 = Convert.ToDateTime("10/01/1987 12:10:15 PM", culture);
                DateTime dt4 = Convert.ToDateTime("09/15/1970 12:10:15 PM", culture);

                this.AddDirector("Andres", "Porras", "Guevara", "andresp@gmail.com", dt1);
                this.AddDirector("Gabriela", "Mora", "Mora", "gaby@gmail.com", dt2);
                this.AddDirector("Ernesto", "Gallardo", "Contreras", "ernesto@gmail.com", dt3);
                this.AddDirector("Harold", "Guillen", "Monge", "harold@gmail.com", dt4);


                if (!this.context.Conjuntos.Any())
                {


                    var d1 = await this.context.Directors.FindAsync(1);
                    var d2 = await this.context.Directors.FindAsync(2);
                    var d3 = await this.context.Directors.FindAsync(3);
                    var d4 = await this.context.Directors.FindAsync(4);

                    this.AddConjuntos("Banda Sinfonica Intermedia", d1);
                    this.AddConjuntos("Banda Sinfonica Juvenil", d2);
                    this.AddConjuntos("Orquesta Sinfonica Elemental", d3);
                    this.AddConjuntos("Ensamble de Saxofones", d4);


                }



            }






           await this.context.SaveChangesAsync();


        }



        private void AddDepartamento(string nombre)
        {
            this.context.Departamentos.Add(new Departamento
            {
                NombreDepartamento = nombre,
                Estado = true,
                Informacion = ""


            }) ;

            
        }


        private void AddCatedra(string nombre, Departamento departamento)
        {
            this.context.Catedras.Add(new Catedra
            {
                NombreCatedra = nombre,
                Estado = true,
                Departamentos = departamento,
                Informacion = "Aqui va la Informacion de la Catedra"
            });
        }

        private void AddProfesor(string nombre, string a1, string a2, string correo, DateTime fecha, Catedra c, Departamento d)
        {
            this.context.Profesors.Add(new Profesor
            {
                Nombre = nombre,
                PrimerApellido = a1,
                SegundoApellido = a2,
                Estado = true,
                Correo = correo,
                FechaNacimiento = fecha,
                Carrera = "Aqui va la trayectoria del director",
                Informacion = "Aqui va otra informacion acerca del director",
                Estudios = "Aqui van los estudios del director",
                ImageUrl = "~/images/Profesores/97e52a8c-174a-47ee-89ae-9bdccf86b39f.jpg",
                Catedras = c,
                Departamentos = d,
                Telefono = 82345678
                

            });
        }




        private void AddDirector(string nombre, string a1, string a2, string correo, DateTime fecha)
        {
            this.context.Directors.Add(new Director
            {
                Nombre = nombre,
                PrimerApellido = a1,
                SegundoApellido = a2,
                Estado = true,
                Correo = correo,
                FechaNacimiento = fecha,
                Carrera = "Aqui va la trayectoria del director",
                Informacion = "Aqui va otra informacion acerca del director",
                Estudios = "Aqui van los estudios del director",
                ImageUrl = "~/images/Profesores/97e52a8c-174a-47ee-89ae-9bdccf86b39f.jpg"

            });
            
        }

        private void AddConjuntos(string nombre, Director director)
        {
            this.context.Conjuntos.Add(new Conjunto
            {
                NombreConjunto = nombre,
                Estado = true,
                Informacion = "Aqui va informacion acerca del conjunto",
                Director = director
                
            });
            
        }



    }
}
