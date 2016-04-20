using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace CryptoMarket.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientType = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CustomerTypeId = table.Column<int>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MailCode = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    CustomerCount = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PublicRating = table.Column<int>(nullable: true),
                    TransactionCount = table.Column<int>(nullable: true),
                    VendorTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AvailableSupply = table.Column<double>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    DayChange = table.Column<double>(nullable: false),
                    DayVolume = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LinkId = table.Column<int>(nullable: false),
                    MarketCap = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    FirstCurrency = table.Column<string>(nullable: true),
                    MaxLimit = table.Column<double>(nullable: false),
                    MinLimit = table.Column<double>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    SecondCurrency = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Relationship",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: false),
                    FriendId = table.Column<int>(nullable: false),
                    TrustLevel = table.Column<double>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relationship_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerWalletId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Fee = table.Column<double>(nullable: false),
                    Marigin = table.Column<double>(nullable: false),
                    MarketRate = table.Column<double>(nullable: false),
                    OfferId = table.Column<int>(nullable: false),
                    OrderId = table.Column<string>(nullable: true),
                    VendorWalletId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Wallet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Balance = table.Column<double>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FiatAccountId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PublicKey = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wallet_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Currency");
            migrationBuilder.DropTable("Offer");
            migrationBuilder.DropTable("Relationship");
            migrationBuilder.DropTable("Transaction");
            migrationBuilder.DropTable("Wallet");
            migrationBuilder.DropTable("Client");
        }
    }
}
