﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sinfonica.Web.Areas.Admin.Data;

namespace Sinfonica.Web.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191225021226_LastEntities")]
    partial class LastEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Beca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Informacion");

                    b.Property<string>("Requisitos");

                    b.HasKey("Id");

                    b.ToTable("Becas");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Catedra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartamentosId");

                    b.Property<bool>("Estado");

                    b.Property<string>("Informacion");

                    b.Property<string>("NombreCatedra");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentosId");

                    b.ToTable("Catedras");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Conjunto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DirectorId");

                    b.Property<bool>("Estado");

                    b.Property<string>("Informacion");

                    b.Property<string>("NombreConjunto");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Conjuntos");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Costo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Costo1Semestre");

                    b.Property<double>("Costo2Semestre");

                    b.Property<DateTime>("FechaLim1Sem");

                    b.Property<DateTime>("FechaLim2Sem");

                    b.Property<string>("Informacion");

                    b.Property<double>("Matricula");

                    b.Property<int?>("ProgramasId");

                    b.HasKey("Id");

                    b.HasIndex("ProgramasId");

                    b.ToTable("Costos");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CondigoCurso");

                    b.Property<bool>("Estado");

                    b.Property<string>("Informacion");

                    b.Property<string>("NombreCurso");

                    b.HasKey("Id");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado");

                    b.Property<string>("Informacion");

                    b.Property<string>("NombreDepartamento");

                    b.HasKey("Id");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Director", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correo");

                    b.Property<bool>("Estado");

                    b.Property<string>("Informacion");

                    b.Property<string>("Nombre");

                    b.Property<string>("PrimerApellido");

                    b.Property<string>("SegundoApellido");

                    b.Property<int>("Telefono");

                    b.HasKey("Id");

                    b.ToTable("Directors");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Correo");

                    b.Property<bool>("Estado");

                    b.Property<string>("Nombre");

                    b.Property<string>("PrimerApellido");

                    b.Property<int?>("PuestosId");

                    b.Property<string>("SegundoApellido");

                    b.Property<int>("Telefono");

                    b.HasKey("Id");

                    b.HasIndex("PuestosId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Encabezado");

                    b.Property<bool>("Estado");

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Informacion");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Ingreso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AntesAplicar");

                    b.Property<string>("Formulario");

                    b.Property<int?>("PruebasId");

                    b.Property<string>("RequisitosExtranjeros");

                    b.Property<string>("RequisitosNacionales");

                    b.HasKey("Id");

                    b.HasIndex("PruebasId");

                    b.ToTable("Ingresos");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Institucion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bienvenida")
                        .HasColumnType("text");

                    b.Property<string>("Estudia")
                        .HasColumnType("text");

                    b.Property<string>("Historia")
                        .HasColumnType("text");

                    b.Property<string>("Informacion")
                        .HasColumnType("text");

                    b.Property<string>("Instituto")
                        .HasColumnType("text");

                    b.Property<string>("Mision")
                        .HasColumnType("text");

                    b.Property<string>("Organizacion")
                        .HasColumnType("text");

                    b.Property<string>("Vision")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Institucions");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Profesor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CatedrasId");

                    b.Property<string>("Correo");

                    b.Property<int?>("DepartamentosId");

                    b.Property<bool>("Estado");

                    b.Property<string>("Informacion");

                    b.Property<string>("Nombre");

                    b.Property<string>("PrimerApellido");

                    b.Property<string>("SegundoApellido");

                    b.Property<int>("Telefono");

                    b.HasKey("Id");

                    b.HasIndex("CatedrasId");

                    b.HasIndex("DepartamentosId");

                    b.ToTable("Profesors");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.ProfesorCurso", b =>
                {
                    b.Property<int>("CursosId");

                    b.Property<int>("ProfesorId");

                    b.HasKey("CursosId", "ProfesorId");

                    b.HasIndex("ProfesorId");

                    b.ToTable("ProfesorCursos");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Programa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado");

                    b.Property<string>("Informacion");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Programas");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Prueba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Encabezado");

                    b.Property<string>("Informacion");

                    b.Property<DateTime>("PrimeraFecha");

                    b.Property<DateTime?>("SegundaFeacha");

                    b.Property<DateTime?>("TerceraFecha");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Pruebas");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Puesto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado");

                    b.Property<string>("Informacion");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Puestos");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Catedra", b =>
                {
                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.Departamento", "Departamentos")
                        .WithMany("Catedras")
                        .HasForeignKey("DepartamentosId");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Conjunto", b =>
                {
                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.Director", "Director")
                        .WithMany("Conjuntos")
                        .HasForeignKey("DirectorId");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Costo", b =>
                {
                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.Programa", "Programas")
                        .WithMany("Costos")
                        .HasForeignKey("ProgramasId");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Empleado", b =>
                {
                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.Puesto", "Puestos")
                        .WithMany("Empleados")
                        .HasForeignKey("PuestosId");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Ingreso", b =>
                {
                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.Prueba", "Pruebas")
                        .WithMany("Ingresos")
                        .HasForeignKey("PruebasId");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.Profesor", b =>
                {
                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.Catedra", "Catedras")
                        .WithMany("Profesors")
                        .HasForeignKey("CatedrasId");

                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.Departamento", "Departamentos")
                        .WithMany("Profesors")
                        .HasForeignKey("DepartamentosId");
                });

            modelBuilder.Entity("Sinfonica.Web.Areas.Admin.Data.Entities.ProfesorCurso", b =>
                {
                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.Curso", "Cursos")
                        .WithMany("ProfesorCurso")
                        .HasForeignKey("CursosId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Sinfonica.Web.Areas.Admin.Data.Entities.Profesor", "Profesors")
                        .WithMany("ProfesorCurso")
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
