using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CryptoMarket.Models;

namespace CryptoMarket.Migrations
{
    [DbContext(typeof(CryptoMarketContext))]
    [Migration("20160421104047_InitalDatabase")]
    partial class InitalDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("CurrencyCode");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<double>("DayChange");

                    b.Property<double>("DayVolume");

                    b.Property<string>("Description");

                    b.Property<int>("ImageId");

                    b.Property<int>("LinkId");

                    b.Property<double>("MarketCap");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<int>("TypeId");

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
        }
    }
}
