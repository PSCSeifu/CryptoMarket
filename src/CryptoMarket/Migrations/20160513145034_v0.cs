using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace CryptoMarket.Migrations
{
    public partial class v0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    Address3 = table.Column<string>(nullable: true),
                    AdminRating = table.Column<double>(nullable: false),
                    ClientType = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    CustomerTypeId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    EmailId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    ImageId = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    MailCode = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    PublicRating = table.Column<double>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    VendorName = table.Column<string>(nullable: true),
                    VendorTypeId = table.Column<int>(nullable: false)
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
                    CurrencyCode = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    DayChange = table.Column<double>(nullable: false),
                    DayVolume = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    HourChange = table.Column<double>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    LinkId = table.Column<int>(nullable: false),
                    MarketCap = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "FiatAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountTypeId = table.Column<int>(nullable: false),
                    AvailableBalance = table.Column<double>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    WithDrawLimit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiatAccount", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "FiatCurrency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    PublicCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiatCurrency", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<string>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin<string>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RelationshipId = table.Column<int>(nullable: false),
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
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Fee = table.Column<double>(nullable: false),
                    Marigin = table.Column<double>(nullable: false),
                    MarketRate = table.Column<double>(nullable: false),
                    OfferHistoryId = table.Column<int>(nullable: false),
                    OrderId = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    StatusLevel = table.Column<double>(nullable: false),
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
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FiatAccountId = table.Column<int>(nullable: false),
                    ImageId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PublicKey = table.Column<string>(nullable: true),
                    TypeId = table.Column<int>(nullable: false),
                    WithdrawLimit = table.Column<double>(nullable: false)
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
            migrationBuilder.CreateTable(
                name: "CurrencyData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CryptoCode = table.Column<string>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    DayChange = table.Column<double>(nullable: false),
                    FiatCode = table.Column<string>(nullable: true),
                    FiatCodeSymbol = table.Column<string>(nullable: true),
                    FiatDescription = table.Column<string>(nullable: true),
                    FiatPublicCode = table.Column<string>(nullable: true),
                    OneHourChange = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    UnixTimeStamp = table.Column<DateTime>(nullable: false),
                    Volume = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyData_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    CounterOfferLimit = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false),
                    Fee = table.Column<int>(nullable: false),
                    FirstCurrency = table.Column<string>(nullable: true),
                    ImageId = table.Column<int>(nullable: true),
                    MarketRate = table.Column<double>(nullable: false),
                    MaxLimit = table.Column<double>(nullable: false),
                    MinLimit = table.Column<double>(nullable: false),
                    MiningSpeed = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    Rate = table.Column<double>(nullable: false),
                    SecondCurrency = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TtlSeconds = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Offer_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");
            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName");
            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("CurrencyData");
            migrationBuilder.DropTable("FiatAccount");
            migrationBuilder.DropTable("FiatCurrency");
            migrationBuilder.DropTable("Offer");
            migrationBuilder.DropTable("Relationship");
            migrationBuilder.DropTable("Transaction");
            migrationBuilder.DropTable("Wallet");
            migrationBuilder.DropTable("AspNetRoleClaims");
            migrationBuilder.DropTable("AspNetUserClaims");
            migrationBuilder.DropTable("AspNetUserLogins");
            migrationBuilder.DropTable("AspNetUserRoles");
            migrationBuilder.DropTable("Currency");
            migrationBuilder.DropTable("Image");
            migrationBuilder.DropTable("Client");
            migrationBuilder.DropTable("AspNetRoles");
            migrationBuilder.DropTable("AspNetUsers");
        }
    }
}
