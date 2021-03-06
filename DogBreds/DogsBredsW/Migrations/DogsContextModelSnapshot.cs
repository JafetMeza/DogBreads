﻿// <auto-generated />
using DogsBredsW.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DogsBredsW.Migrations
{
    [DbContext(typeof(DogsContext))]
    partial class DogsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DogBredsModel.CaracFisic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Caracteristicas");
                });

            modelBuilder.Entity("DogBredsModel.HairType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HairTypes");
                });

            modelBuilder.Entity("DogBredsModel.Origin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Origenes");
                });

            modelBuilder.Entity("DogBredsModel.Raza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actividad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Altura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EsperanzaDeVida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Razas");
                });

            modelBuilder.Entity("DogBredsModel.RazaCaracFisic", b =>
                {
                    b.Property<int>("CaracFisicId")
                        .HasColumnType("int");

                    b.Property<int>("RazaId")
                        .HasColumnType("int");

                    b.HasKey("CaracFisicId", "RazaId");

                    b.HasIndex("RazaId");

                    b.ToTable("RazaCaracFisics");
                });

            modelBuilder.Entity("DogBredsModel.RazaHairType", b =>
                {
                    b.Property<int>("HairTypeId")
                        .HasColumnType("int");

                    b.Property<int>("RazaId")
                        .HasColumnType("int");

                    b.HasKey("HairTypeId", "RazaId");

                    b.HasIndex("RazaId");

                    b.ToTable("RazaHairTypes");
                });

            modelBuilder.Entity("DogBredsModel.RazaOrigen", b =>
                {
                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<int>("RazaId")
                        .HasColumnType("int");

                    b.HasKey("OriginId", "RazaId");

                    b.HasIndex("RazaId");

                    b.ToTable("RazaOrigenes");
                });

            modelBuilder.Entity("DogBredsModel.RazaCaracFisic", b =>
                {
                    b.HasOne("DogBredsModel.CaracFisic", "CaracFisic")
                        .WithMany("RazaCaracFisics")
                        .HasForeignKey("CaracFisicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogBredsModel.Raza", "Raza")
                        .WithMany("CaracFisics")
                        .HasForeignKey("RazaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DogBredsModel.RazaHairType", b =>
                {
                    b.HasOne("DogBredsModel.HairType", "HairType")
                        .WithMany("RazaHairTypes")
                        .HasForeignKey("HairTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogBredsModel.Raza", "Raza")
                        .WithMany("TiposDePelo")
                        .HasForeignKey("RazaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DogBredsModel.RazaOrigen", b =>
                {
                    b.HasOne("DogBredsModel.Origin", "Origin")
                        .WithMany("RazaOrigenes")
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogBredsModel.Raza", "Raza")
                        .WithMany("Origenes")
                        .HasForeignKey("RazaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
