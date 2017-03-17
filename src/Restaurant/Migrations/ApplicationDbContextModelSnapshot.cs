using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Restaurant.Models;

namespace Restaurant.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Restaurant.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("Id");

                    b.Property<DateTime>("Joined");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("MemberID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Restaurant.Models.Menu1", b =>
                {
                    b.Property<int>("Menu1ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description1");

                    b.Property<int>("Ingredients1");

                    b.Property<string>("Location");

                    b.Property<string>("Name1");

                    b.Property<string>("NameOfRest1");

                    b.Property<decimal>("Price1");

                    b.Property<int>("Stars1");

                    b.Property<string>("Type1");

                    b.Property<string>("TypeOfMeat");

                    b.HasKey("Menu1ID");

                    b.ToTable("Menu1s");
                });

            modelBuilder.Entity("Restaurant.Models.Menu2", b =>
                {
                    b.Property<int>("Menu2ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description2");

                    b.Property<int>("Ingredients2");

                    b.Property<string>("Location");

                    b.Property<string>("Name2");

                    b.Property<string>("NameOfRest2");

                    b.Property<decimal>("Price2");

                    b.Property<int>("Stars2");

                    b.Property<string>("Type2");

                    b.Property<string>("TypeOfMeat");

                    b.HasKey("Menu2ID");

                    b.ToTable("Menu2s");
                });

            modelBuilder.Entity("Restaurant.Models.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 500);

                    b.Property<DateTime>("Date");

                    b.Property<int?>("FromMemberID");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 30);

                    b.HasKey("MessageID");

                    b.HasIndex("FromMemberID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Restaurant.Models.NewMessage", b =>
                {
                    b.Property<int>("NewMessageID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 175);

                    b.Property<int?>("MessageID");

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.HasKey("NewMessageID");

                    b.HasIndex("MessageID");

                    b.ToTable("NewMessage");
                });

            modelBuilder.Entity("Restaurant.Models.Message", b =>
                {
                    b.HasOne("Restaurant.Models.Member", "From")
                        .WithMany()
                        .HasForeignKey("FromMemberID");
                });

            modelBuilder.Entity("Restaurant.Models.NewMessage", b =>
                {
                    b.HasOne("Restaurant.Models.Message")
                        .WithMany("NewMessage")
                        .HasForeignKey("MessageID");
                });
        }
    }
}
