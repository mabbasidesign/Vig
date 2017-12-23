using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Vig.Persistance;

namespace Viga.Migrations
{
    [DbContext(typeof(VigaDbContext))]
    [Migration("20171223180856_AddVehicle")]
    partial class AddVehicle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Vig.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Vig.Models.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Makes");
                });

            modelBuilder.Entity("Vig.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MakeID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("MakeID");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("Vig.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(255);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("IsRegistered");

                    b.Property<DateTime>("LastUpdate");

                    b.Property<int>("ModelId");

                    b.HasKey("Id");

                    b.HasIndex("ModelId");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Vig.Models.VehicleFeature", b =>
                {
                    b.Property<int>("VehicleId");

                    b.Property<int>("FeatureId");

                    b.HasKey("VehicleId", "FeatureId");

                    b.HasIndex("FeatureId");

                    b.ToTable("VehicleFeature");
                });

            modelBuilder.Entity("Vig.Models.Model", b =>
                {
                    b.HasOne("Vig.Models.Make", "Make")
                        .WithMany("Models")
                        .HasForeignKey("MakeID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vig.Models.Vehicle", b =>
                {
                    b.HasOne("Vig.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Vig.Models.VehicleFeature", b =>
                {
                    b.HasOne("Vig.Models.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Vig.Models.Vehicle", "Vehicle")
                        .WithMany("Features")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
