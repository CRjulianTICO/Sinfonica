using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sinfonica.Web.Areas.Admin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinfonica.Web.Areas.Admin.Data
{
    public class DataContext : IdentityDbContext<User>
    {



        public DbSet<Beca> Becas { get; set; }

        public DbSet<Catedra> Catedras { get; set; }

        public DbSet<Conjunto> Conjuntos { get; set; }

        public DbSet<Costo> Costos { get; set; }

        public DbSet<Departamento> Departamentos { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Ingreso> Ingresos { get; set; }

        public DbSet<Institucion> Institucions { get; set; }

        public DbSet<Profesor> Profesors { get; set; }

        public DbSet<Programa> Programas { get; set; }

        public DbSet<Prueba> Pruebas { get; set; }

        public DbSet<Puesto> Puestos { get; set; }

        public DbSet<ProfesorCurso> ProfesorCursos { get; set; }








        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Institucion>()
               .Property(p => p.Bienvenida)
               .HasColumnType("text");
            modelBuilder.Entity<Institucion>()
                .Property(p => p.Organizacion)
                .HasColumnType("text");

            modelBuilder.Entity<Institucion>()
                .Property(p => p.Estudia)
                .HasColumnType("text");

            modelBuilder.Entity<Institucion>()
                .Property(p => p.Informacion)
                .HasColumnType("text");

            modelBuilder.Entity<Institucion>()
                .Property(p => p.Mision)
                .HasColumnType("text");

            modelBuilder.Entity<Institucion>()
                .Property(p => p.Vision)
                .HasColumnType("text");
            modelBuilder.Entity<Institucion>()
                .Property(p => p.Historia)
                .HasColumnType("text");
            modelBuilder.Entity<Institucion>()
                .Property(p => p.Instituto)
                .HasColumnType("text");

            modelBuilder.Entity<ProfesorCurso>()
                .HasKey(c => new { c.CursosId, c.ProfesorId });
            /*
            modelBuilder.Entity<Table2>().Property(e => e.Table1Id).ValueGeneratedNever();
            modelBuilder.Entity<Table2>().Property(e => e.Key).ValueGeneratedNever();\\
            */




            /*
            modelBuilder.Entity<Empleado>().Property(e => e.Puestos).ValueGeneratedNever();
            modelBuilder.Entity<Empleado>().Property(e => e.Puestos).ValueGeneratedNever();
            */




            // modelBuilder.Entity<Empleado>().HasIndex(a => a.PuestosId);


            var cascadeFKs = modelBuilder.Model
                .G­etEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }


            base.OnModelCreating(modelBuilder);
        }




    }
}
