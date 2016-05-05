using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CryptoMarket.Models;

namespace CryptoMarket.Migrations
{
    [DbContext(typeof(CryptoMarketContext))]
    partial class CryptoMarketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CryptoMarket.Entities.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("CryptoMarket.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientType");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<int>("ImageId");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Client");
                });

            modelBuilder.Entity("CryptoMarket.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AvailableSupply");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 6);

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<double>("DayChange");

                    b.Property<double>("DayVolume");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 1000);

                    b.Property<double>("HourChange");

                    b.Property<int>("ImageId");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("LinkId");

                    b.Property<double>("MarketCap");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<int>("TypeId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CryptoMarket.Models.CurrencyData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CryptoCode");

                    b.Property<int?>("CurrencyId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<double>("DayChange");

                    b.Property<string>("FiatCode");

                    b.Property<string>("FiatDescription");

                    b.Property<string>("FiatPublicCode");

                    b.Property<double>("OneHourChange");

                    b.Property<double>("Price");

                    b.Property<double>("Volume");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CryptoMarket.Models.FiatAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountTypeId");

                    b.Property<double>("AvailableBalance");

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<double>("WithDrawLimit");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CryptoMarket.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<int>("TypeId");

                    b.Property<string>("Url");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CryptoMarket.Models.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int>("ClientId");

                    b.Property<int>("CounterOfferLimit");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<int>("Fee");

                    b.Property<string>("FirstCurrency");

                    b.Property<int?>("ImageId");

                    b.Property<double>("MarketRate");

                    b.Property<double>("MaxLimit");

                    b.Property<double>("MinLimit");

                    b.Property<int>("MiningSpeed");

                    b.Property<int>("ParentId");

                    b.Property<double>("Rate");

                    b.Property<string>("SecondCurrency");

                    b.Property<int>("Status");

                    b.Property<int>("TtlSeconds");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CryptoMarket.Models.Relationship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClientId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<int>("RelationshipId");

                    b.Property<double>("TrustLevel");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CryptoMarket.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<int>("ClientId");

                    b.Property<int>("CustomerId");

                    b.Property<int>("CustomerWalletId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<double>("Fee");

                    b.Property<double>("Marigin");

                    b.Property<double>("MarketRate");

                    b.Property<int>("OfferHistoryId");

                    b.Property<string>("OrderId");

                    b.Property<int>("StatusId");

                    b.Property<double>("StatusLevel");

                    b.Property<int>("VendorWalletId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CryptoMarket.Models.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Balance");

                    b.Property<int>("ClientId");

                    b.Property<int>("CurrencyId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<int>("FiatAccountId");

                    b.Property<int>("ImageId");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<string>("PublicKey");

                    b.Property<int>("TypeId");

                    b.Property<double>("WithdrawLimit");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("CryptoMarket.Models.Customer", b =>
                {
                    b.HasBaseType("CryptoMarket.Models.Client");

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("Address3");

                    b.Property<string>("Country");

                    b.Property<int>("CustomerTypeId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MailCode");

                    b.Property<string>("Title");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Customer");
                });

            modelBuilder.Entity("CryptoMarket.Models.Vendor", b =>
                {
                    b.HasBaseType("CryptoMarket.Models.Client");

                    b.Property<int>("CustomerCount");

                    b.Property<string>("Name");

                    b.Property<double>("PublicRating");

                    b.Property<double>("Rating");

                    b.Property<int>("TransactionCount");

                    b.Property<int>("VendorTypeId");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Vendor");
                });

            modelBuilder.Entity("CryptoMarket.Models.CurrencyData", b =>
                {
                    b.HasOne("CryptoMarket.Models.Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");
                });

            modelBuilder.Entity("CryptoMarket.Models.Offer", b =>
                {
                    b.HasOne("CryptoMarket.Models.Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("CryptoMarket.Models.Image")
                        .WithMany()
                        .HasForeignKey("ImageId");
                });

            modelBuilder.Entity("CryptoMarket.Models.Relationship", b =>
                {
                    b.HasOne("CryptoMarket.Models.Client")
                        .WithMany()
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("CryptoMarket.Models.Transaction", b =>
                {
                    b.HasOne("CryptoMarket.Models.Client")
                        .WithMany()
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("CryptoMarket.Models.Wallet", b =>
                {
                    b.HasOne("CryptoMarket.Models.Client")
                        .WithMany()
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CryptoMarket.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CryptoMarket.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("CryptoMarket.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
