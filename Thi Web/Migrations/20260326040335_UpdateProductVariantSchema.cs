using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Thi_Web.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductVariantSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferralCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferredByCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommissionBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoyaltyPoints = table.Column<int>(type: "int", nullable: false),
                    MembershipTier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercent = table.Column<int>(type: "int", nullable: false),
                    MaxDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MinOrderAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTickets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StoreBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommissionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommissionLogs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoyaltyPointsAwarded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsTradeInEligible = table.Column<bool>(type: "bit", nullable: false),
                    MaxTradeInValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WarrantyPolicy = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariantGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariantGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariantGroups_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SpecName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SpecValue = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSpecifications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariants_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreInventories",
                columns: table => new
                {
                    StoreBranchId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreInventories", x => new { x.StoreBranchId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_StoreInventories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreInventories_StoreBranches_StoreBranchId",
                        column: x => x.StoreBranchId,
                        principalTable: "StoreBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarrantyPackages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PackageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarrantyPackages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarrantyPackages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wishlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wishlists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wishlists_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariantOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVariantGroupId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorHex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariantOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariantOptions_ProductVariantGroups_ProductVariantGroupId",
                        column: x => x.ProductVariantGroupId,
                        principalTable: "ProductVariantGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariantSelections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductVariantOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariantSelections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariantSelections_ProductVariantOptions_ProductVariantOptionId",
                        column: x => x.ProductVariantOptionId,
                        principalTable: "ProductVariantOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariantSelections_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductVariantValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductVariantId = table.Column<int>(type: "int", nullable: false),
                    ProductVariantOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVariantValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVariantValues_ProductVariantOptions_ProductVariantOptionId",
                        column: x => x.ProductVariantOptionId,
                        principalTable: "ProductVariantOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductVariantValues_ProductVariants_ProductVariantId",
                        column: x => x.ProductVariantId,
                        principalTable: "ProductVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Máy tính xách tay các loại", "Laptop" },
                    { 2, "Chuột máy tính có dây và không dây", "Chuột" },
                    { 3, "Bàn phím cơ và membrane", "Bàn phím" },
                    { 4, "Màn hình máy tính các kích thước", "Màn hình" },
                    { 5, "CPU, RAM, GPU, SSD và các linh kiện khác", "Linh kiện PC" },
                    { 6, "Tai nghe gaming và văn phòng", "Tai nghe" },
                    { 7, "SSD, HDD lưu trữ dữ liệu", "Ổ cứng" },
                    { 8, "Ghế gaming chuyên dụng", "Ghế gaming" },
                    { 9, "Smartphone iOS và Android", "Điện thoại" },
                    { 10, "Key Office, Windows, phần mềm AI và thiết kế", "Bản quyền phần mềm" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "DiscountPrice", "ImageUrl", "IsActive", "IsTradeInEligible", "MaxTradeInValue", "Name", "Price", "Stock", "WarrantyPolicy" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop gaming cao cấp Intel Core i9-14900HX, RTX 4070 8GB, RAM 16GB DDR5, SSD 1TB PCIe 4.0, màn hình 16 inch QHD 165Hz", 42990000m, "https://2tmobile.com/wp-content/uploads/2024/08/asus-rog-strix-g16-2024-g614-2tmobile.jpg", true, false, null, "ASUS ROG Strix G16 2024", 45990000m, 10, "Bảo hành chính hãng 12 tháng" },
                    { 2, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop văn phòng cao cấp Intel Core i7-13700H, RTX 4060 8GB, màn hình OLED 3.5K 60Hz, RAM 16GB, SSD 512GB, pin 86Whr", null, "https://cdn.tgdd.vn/Products/Images/44/314837/dell-xps-15-9530-i7-71015716-thumb-600x600.jpg", true, false, null, "Dell XPS 15 9530", 38990000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 3, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop Apple chip M3 Pro 11 nhân, màn hình Liquid Retina XDR 14.2 inch, RAM 18GB, SSD 512GB, pin 18 giờ, MagSafe 3", null, "https://cdn2.fptshop.com.vn/unsafe/1920x0/filters:format(webp):quality(75)/2024_2_16_638436790518626265_macbook-pro-14-2023-m3-pro-max-den%20(1).jpg", true, false, null, "MacBook Pro M3 Pro 14 inch", 52990000m, 6, "Bảo hành chính hãng 12 tháng" },
                    { 4, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop mỏng nhẹ Apple chip M3 8 nhân, màn hình Liquid Retina 15.3 inch, RAM 8GB, SSD 256GB, pin 18 giờ, không quạt tản nhiệt", 30990000m, "https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/mba15-midnight-select-202306?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1684518479433", true, false, null, "MacBook Air M3 15 inch", 32990000m, 10, "Bảo hành chính hãng 12 tháng" },
                    { 5, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop doanh nhân siêu mỏng Intel Core Ultra 7 155U, RAM 32GB LPDDR5, SSD 1TB, màn hình 2.8K OLED, pin 15 giờ, cân nặng chỉ 1.12kg", null, "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/laptop-lenovo-thinkpad-x1-gen-12-21kc008nvn-02.jpg?v=1732531914903", true, false, null, "Lenovo ThinkPad X1 Carbon Gen 12", 42990000m, 5, "Bảo hành chính hãng 12 tháng" },
                    { 6, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop 2-in-1 cao cấp Intel Core Ultra 5 125H, màn hình OLED cảm ứng 2.8K 120Hz, RAM 16GB, SSD 512GB, bút HP Tilt Pen đi kèm", 32990000m, "https://hanoicomputercdn.com/media/product/84656_laptop_hp_spectre_x360_14_eu0051tu__a2nl3pa___2_.jpg", true, false, null, "HP Spectre x360 14", 35990000m, 7, "Bảo hành chính hãng 12 tháng" },
                    { 7, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop gaming tầm trung Intel Core i5-13500H, RTX 4050 6GB, RAM 16GB DDR5, SSD 512GB, màn hình 16 inch FHD 144Hz, tản nhiệt 4 quạt", 20990000m, "https://hanoicomputercdn.com/media/product/74895_laptop_acer_gaming_nitro_16_phoenix_an16_41_r50z__nh_qlksv_001___1_.jpg", true, false, null, "Acer Nitro 16 AN16-51", 22990000m, 15, "Bảo hành chính hãng 12 tháng" },
                    { 8, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop gaming flagship Intel Core i9-14900HX, RTX 4090 16GB, RAM 64GB DDR5, SSD 2TB, màn hình 17 inch QHD+ 240Hz, Thunderbolt 4", null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTBlp9sfbMVTiWQPh6IG7zyUx0qTOUPbIqviQ&s", true, false, null, "MSI Raider GE78 HX", 79990000m, 3, "Bảo hành chính hãng 12 tháng" },
                    { 9, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop mỏng nhẹ Intel Core Ultra 9 185H, màn hình OLED 2.8K 120Hz, RAM 32GB LPDDR5X, SSD 1TB, pin 75Whr sạc nhanh 65W", null, "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/l/a/laptop-asus-zenbook-14-oled-ux3405ma-pp152w-3.jpg", true, false, null, "ASUS Zenbook 14 OLED UX3405", 28990000m, 12, "Bảo hành chính hãng 12 tháng" },
                    { 10, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop gaming siêu cao cấp Intel Core i9-14900HX, RTX 4090 16GB, màn hình OLED 4K 240Hz, RAM 32GB DDR5, SSD 2TB", 84990000m, "https://lapvip.vn/upload/products/original/razer-blade-16-2024-1710757551.jpg", true, false, null, "Razer Blade 16 2024", 89990000m, 3, "Bảo hành chính hãng 12 tháng" },
                    { 11, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop siêu nhẹ Intel Core Ultra 7 155H, màn hình 17 inch WQXGA IPS, RAM 16GB, SSD 512GB, cân nặng 1.35kg, pin 90Whr 20 giờ", null, "https://anphat.com.vn/media/product/48813_17.jpg", true, false, null, "LG Gram 17 2024", 34990000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 12, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Laptop 2-in-1 màn hình AMOLED 16 inch 3K cảm ứng, Intel Core Ultra 7 155H, RAM 16GB, SSD 512GB, bút S Pen tích hợp, pin 76Whr", 35990000m, "https://lapvip.vn/upload/products/original/samsung-galaxy-book4-pro-360-16-2024-1711965445.jpg", true, false, null, "Samsung Galaxy Book4 Pro 360", 38990000m, 6, "Bảo hành chính hãng 12 tháng" },
                    { 13, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chuột gaming không dây siêu nhẹ 60g, cảm biến HERO 2 25600 DPI, pin 95 giờ, kết nối LIGHTSPEED, thiết kế đối xứng pro", 2690000m, "https://bizweb.dktcdn.net/thumb/grande/100/329/122/products/chuot-gaming-khong-day-logitech-g-pro-x-superlight-2-d9fa496b-1eb8-49e5-a9a1-4c275aa234a3.jpg?v=1741142613607", true, false, null, "Logitech G Pro X Superlight 2", 2990000m, 30, "Bảo hành chính hãng 12 tháng" },
                    { 14, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chuột gaming ergonomic không dây, cảm biến Focus Pro 30000 DPI, 6 nút lập trình, pin 90 giờ, kết nối HyperSpeed 4000Hz", null, "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/chuot-gaming-khong-day-razer-deathadder-v3-pro-7.jpg?v=1767322699743", true, false, null, "Razer DeathAdder V3 Pro", 2490000m, 25, "Bảo hành chính hãng 12 tháng" },
                    { 15, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chuột gaming không dây siêu nhẹ 74g lưới, cảm biến TrueMove Air+ 18000 DPI, IP54, 9 nút, pin 180 giờ", 1790000m, "https://product.hstatic.net/200000722513/product/_q100_crop-fit_optimize_subsampling-2_36b24c7c9351454b988c38bf55e36b1b_8b41cbe6c65541ec84f85186542b9c3e.png", true, false, null, "SteelSeries Aerox 5 Wireless", 1990000m, 20, "Bảo hành chính hãng 12 tháng" },
                    { 16, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chuột văn phòng cao cấp, cảm biến 8000 DPI, cuộn MagSpeed điện từ, pin 70 ngày, Bluetooth + USB, 7 nút tùy chỉnh", null, "https://product.hstatic.net/200000722513/product/mx-master-3s-mouse-top-view-graphite_880f7c80882541c2b4e349b7ed0fa439_de0fb8d222ec49bfb11d909a1f116f7e.png", true, false, null, "Logitech MX Master 3S", 1690000m, 40, "Bảo hành chính hãng 12 tháng" },
                    { 17, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chuột gaming không dây esports, cảm biến 3200 DPI, thiết kế ergonomic tay phải, không cần driver, kết nối 2.4G độ trễ thấp", null, "https://gearshop.vn/upload/resizer.php?src=/upload/images/Product/Zowie/CHU%E1%BB%98T/EC3-CW/ZOWIE-EC2-cw-(1).JPG&w=800&h=800&q=72&zc=2", true, false, null, "Zowie EC2-CW", 2190000m, 15, "Bảo hành chính hãng 12 tháng" },
                    { 18, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chuột gaming không dây siêu nhẹ 55g, cảm biến PAW3395 26000 DPI, thiết kế đối xứng, pin 70 giờ, polling 1000Hz", null, "https://product.hstatic.net/200000637319/product/ezgif-3-82221cec1f_d5437d20e2d243baac6a0ca726705ca5_master.png", true, false, null, "Pulsar X2V2 Wireless", 1890000m, 18, "Bảo hành chính hãng 12 tháng" },
                    { 19, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chuột không dây Apple thiết kế mỏng phẳng, Multi-Touch surface, kết nối Bluetooth, sạc Lightning, tương thích Mac", null, "https://cdnv2.tgdd.vn/mwg-static/tgdd/Products/Images/86/332191/chuot-apple-magic-mouse-usb-c-trang-2-638677956759654977-750x500.jpg", true, false, null, "Apple Magic Mouse", 1590000m, 25, "Bảo hành chính hãng 12 tháng" },
                    { 20, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chuột gaming không dây, cảm biến Focus Pro 30000 DPI, cuộn HyperScroll Tilt, 11 nút lập trình, đèn RGB Chroma, pin 90 giờ", 1990000m, "https://product.hstatic.net/200000722513/product/thumbchuot-recovered_757cce0149c042149f8b58f30fcb3307_8868cbe7339a46e9813f2eb8bdb334ee.png", true, false, null, "Razer Basilisk V3 Pro", 2290000m, 22, "Bảo hành chính hãng 12 tháng" },
                    { 21, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chuột gaming không dây 89g, cảm biến HERO 25600 DPI, 13 nút lập trình, đèn LIGHTFORCE, cuộn LIGHTTUNE, pin 130 giờ", null, "https://product.hstatic.net/200000722513/product/g502x-plus-gallery-2-white_69229c9ba5534ad5bfae7d827037a28f_365394a31b6342e4949249099adb755e_master.png", true, false, null, "Logitech G502 X Plus", 2190000m, 18, "Bảo hành chính hãng 12 tháng" },
                    { 22, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chuột gaming không dây siêu nhẹ 60g, cảm biến PixArt PAW3395 26000 DPI, pin 200 giờ, thiết kế ergonomic tay phải, USB-C sạc", null, "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/chuot-gaming-khong-day-corsair-m75-air-ch-931d100-ap-5.jpg?v=1730307642997", true, false, null, "Corsair M75 Air Wireless", 1790000m, 20, "Bảo hành chính hãng 12 tháng" },
                    { 23, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bàn phím cơ 75% không dây, khung nhôm CNC, switch QMK/VIA, hotswap, Bluetooth 5.1, pin 4000mAh, gasket mount", null, "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/ban-phim-co-khong-day-keychron-q1-pro-carbon-black-rgb-knob-hotswap-keychron-k-pro-switch-3.jpg?v=1706719750593", true, false, null, "Keychron Q1 Pro", 3290000m, 20, "Bảo hành chính hãng 12 tháng" },
                    { 24, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bàn phím cơ 65% premium switch Cherry MX Red, hotswap socket, đèn RGB per-key, thiết kế compact gaming, PBT double-shot keycaps", 2490000m, "https://owlgaming.vn/wp-content/uploads/2024/01/ban-phim-co-ducky-one-3-cosmic-blue-sf-65.jpg", true, false, null, "Ducky One 3 SF 65%", 2690000m, 15, "Bảo hành chính hãng 12 tháng" },
                    { 25, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bàn phím cơ TKL không dây GL Low Profile switch, đèn RGB LIGHTSYNC, pin 40 giờ, LIGHTSPEED 1ms, Bluetooth 5.0, thiết kế mỏng", null, "https://bizweb.dktcdn.net/thumb/grande/100/329/122/products/ban-phim-co-khong-day-logitech-g915-x-lightspeed-tkl-07.jpg?v=1727148060207", true, false, null, "Logitech G915 TKL Wireless", 3990000m, 10, "Bảo hành chính hãng 12 tháng" },
                    { 26, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bàn phím cơ fullsize switch Razer Yellow, đèn Chroma RGB per-key, macro dial, wrist rest từ tính, USB passthrough, media keys", null, "https://product.hstatic.net/200000722513/product/phim_6c19f3491c624a93acecf707c68a9cd8_137391e150d54883a044e69479533a20_84db1b13d01a4a5887432c33da001df9.png", true, false, null, "Razer BlackWidow V4 Pro", 3490000m, 12, "Bảo hành chính hãng 12 tháng" },
                    { 27, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bàn phím cơ TKL giá tốt switch Akko CS Jelly Pink, hotswap, đèn RGB, PBT double-shot keycaps, thiết kế màu sắc đẹp", 990000m, "https://product.hstatic.net/200000722513/product/thumbphim-recovered-recovered_267e97e1955a416ebc59d2aabcdf227e_943e2216bceb4b11904c6249de9c260a.gif", true, false, null, "Akko 3087 DS Ocean Star", 1190000m, 35, "Bảo hành chính hãng 12 tháng" },
                    { 28, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bàn phím cơ fullsize cao cấp switch Cherry MX Brown, thiết kế tối giản không đèn, PBT double-shot keycaps bền, chất lượng build quality xuất sắc", null, "https://pcmarket.vn/media/product/6962_leopold_fc900rc_egbpd_lbox_800x800_fefefe.jpg", true, false, null, "Leopold FC900R PD", 1990000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 29, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bàn phím không dây Apple slim profile, phím scissor mechanism, Touch ID tích hợp, Bluetooth, sạc Lightning, dành cho Mac", null, "https://cdn2.cellphones.com.vn/x/media/catalog/product/b/a/ban-phim-apple-magic-keyboard-touch-id-2021-1.jpg", true, false, null, "Apple Magic Keyboard Touch ID", 2390000m, 15, "Bảo hành chính hãng 12 tháng" },
                    { 30, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bàn phím cơ 75% không dây low profile, switch Gateron Low Profile 2.0, Bluetooth 5.0 + USB, RGB, pin 3000mAh, gasket mount", 1990000m, "https://imagor.owtg.one/unsafe/fit-in/800x800/https://d28jzcg6y4v9j1.cloudfront.net/media/core/products/2024/1/12/ban-phim-co-nuphy-air75-v2-qmkvia-thinkpro-nicespace-OMe.jpg", true, false, null, "NuPhy Air75 V2", 2190000m, 18, "Bảo hành chính hãng 12 tháng" },
                    { 31, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bàn phím cơ 60% analog hall effect, rapid trigger công nghệ, switch Lekker 60g, polling 1000Hz, dành cho esports pro player", null, "https://wooting-website.ams3.cdn.digitaloceanspaces.com/products/keyboards/60HE/60HE_OG.webp", true, false, null, "Wooting 60HE+", 3890000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 32, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bàn phím gaming TKL không dây, switch OmniPoint 2.0 điều chỉnh actuation, OLED display, đèn RGB, LIGHTSPEED 1ms, pin 45 giờ", 3990000m, "https://azaudio.vn/wp-content/uploads/2024/10/steelseries-apex-pro-tkl-wireless-gen3-2024-1.jpg", true, false, null, "SteelSeries Apex Pro TKL Wireless", 4490000m, 10, "Bảo hành chính hãng 12 tháng" },
                    { 33, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Màn hình gaming 27 inch 2K 165Hz Nano IPS, 1ms GtG, AMD FreeSync Premium Pro, G-Sync Compatible, HDR400, DisplayPort 1.4 + HDMI 2.0", 7990000m, "https://product.hstatic.net/200000722513/product/mnt-27gp850-gallery-04_57090512e4fb42de84bfa6adae25fbc0_652629fef6d94187b64adcf2214feacb_master.jpg", true, false, null, "LG 27GP850-B Nano IPS 2K 165Hz", 8990000m, 12, "Bảo hành chính hãng 12 tháng" },
                    { 34, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Màn hình gaming cong 32 inch 4K 144Hz VA, HDR600, 1ms, G-Sync Compatible, DisplayHDR 600, USB Hub, Height Adjustable", null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTECPlrTgI0ra_JLCn9dybbIpX3CfpbqLIskQ&s", true, false, null, "Samsung Odyssey G7 32 inch 4K", 15990000m, 6, "Bảo hành chính hãng 12 tháng" },
                    { 35, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Màn hình gaming 27 inch 2K 240Hz IPS, 1ms GTG, G-Sync, ELMB Sync, HDR400, DisplayPort 1.4, ASUS Extreme Low Motion Blur", null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTqzji31Gw5mFbChp54R0rK9tC2FA9obH5jDA&s", true, false, null, "ASUS ROG Swift PG279QM 240Hz", 18990000m, 5, "Bảo hành chính hãng 12 tháng" },
                    { 36, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Màn hình văn phòng 27 inch 4K 60Hz IPS Black, Delta-E < 2, 100% sRGB, USB-C 90W, KVM built-in, Height/Pivot/Tilt/Swivel", null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSnlHv2p4Jrm8g1XIkGyC496YfQ_tYdOD1U4A&s", true, false, null, "Dell U2723D UltraSharp 4K", 14990000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 37, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Màn hình gaming 27 inch 2K 144Hz IPS, HDRi tự động, loa 2.1 tích hợp, FreeSync Premium, USB-C, remote điều khiển", 8990000m, "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/man-hinh-2k-benq-27-inch-ips-144hz-benq-ex2780q-4.png?v=1633663195497", true, false, null, "BenQ EX2780Q 2K 144Hz IPS", 9990000m, 10, "Bảo hành chính hãng 12 tháng" },
                    { 38, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Màn hình gaming 28 inch 4K 155Hz IPS, G-Sync Ultimate, HDR400, 1ms GTG, VESA DisplayHDR 400, thiết kế gaming premium", null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRogRnwSVtN-tEuw8XzzFkw4N2tOn4zIYXMLQ&s", true, false, null, "Acer Predator X28 4K 155Hz", 22990000m, 4, "Bảo hành chính hãng 12 tháng" },
                    { 39, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Màn hình gaming 27 inch 2K 165Hz Rapid IPS Quantum Dot, 1ms, FreeSync Premium, 99% DCI-P3, USB Hub, Night Vision tắt tối", 7490000m, "https://product.hstatic.net/1000333506/product/msi_mag274qrf_qd_gearvn_66dcd66a1bab4d8a8a9742be876a97a5_376dce3f245142e7bee4b73bb22b6a04.jpg", true, false, null, "MSI MAG 274QRF-QD 2K 165Hz", 8490000m, 12, "Bảo hành chính hãng 12 tháng" },
                    { 40, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Màn hình OLED gaming siêu rộng 45 inch cong 800R, 2K 240Hz, 0.03ms, G-Sync Compatible, HDR True Black 400, DCI-P3 98.5%", 34990000m, "https://product.hstatic.net/200000420363/product/man-hinh-gaming-lg-45gr95qe-b.atv-7_2ed757535246423b8d193e1ce6c55dd6_master.png", true, false, null, "LG 45GR95QE OLED 45 inch 240Hz", 38990000m, 3, "Bảo hành chính hãng 12 tháng" },
                    { 41, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Màn hình gaming 27 inch 2K 240Hz Fast IPS, 1ms, KVM built-in, USB-C 18W, FreeSync Premium Pro, thiết kế không viền 3 cạnh", null, "https://product.hstatic.net/1000333506/product/-240hz-1ms-hdr400-chuyen-game-2_a9485e1eb61540e0be158de0e1438f31_large_cc6318cde73245daaadf72972ca248a8.jpg", true, false, null, "Gigabyte M27Q X 2K 240Hz", 7990000m, 14, "Bảo hành chính hãng 12 tháng" },
                    { 42, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Màn hình đồ họa chuyên nghiệp 27 inch 4K 60Hz IPS, Delta-E < 1, 100% sRGB/P3, Calman Verified, USB-C 96W, HDMI 2.1, DisplayPort 1.4", null, "https://product.hstatic.net/200000722513/product/man-hinh-asus-proart-pa248crv-24-inch-1.png_f5f89eeec36f4ca98e12a1b4fae08ace_master.jpg", true, false, null, "ASUS ProArt PA279CRV 4K USB-C", 17990000m, 5, "Bảo hành chính hãng 12 tháng" },
                    { 43, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Card đồ họa gaming 16GB GDDR6X, DLSS 3.5 Frame Generation, Ray Tracing Ada, PCIe 4.0 x16, TDP 285W, 4x DisplayPort 1.4a + HDMI 2.1", null, "https://bizweb.dktcdn.net/100/329/122/products/vga-gigabyte-geforce-rtx-4070-ti-super-gaming-oc-16g-gddr6x.jpg?v=1743639363470", true, false, null, "NVIDIA GeForce RTX 4070 Ti Super", 24990000m, 5, "Bảo hành chính hãng 12 tháng" },
                    { 44, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "CPU AMD flagship 16 nhân 32 luồng, 4.2GHz base 5.7GHz boost, 3D V-Cache 128MB L3, TDP 120W, socket AM5, dành cho gaming và workstation", 17990000m, "https://nguyencongpc.vn/media/product/24427-cpu-amd-ryzen-9-7950x3d.jpg", true, false, null, "AMD Ryzen 9 7950X3D", 19990000m, 6, "Bảo hành chính hãng 12 tháng" },
                    { 45, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "CPU Intel flagship 24 nhân (8P+16E) 36 luồng, 3.2GHz base 6.2GHz boost, TDP 150W, socket LGA1700, hỗ trợ DDR5 và DDR4", 15490000m, "https://hanoicomputercdn.com/media/product/83745_cpu_intel_core_i9_14900ks_up_to_6_2ghz_24_nhan_32_luong_36mb_cache_125w_socket_intel_lga_1700_raptor_lake.jpg", true, false, null, "Intel Core i9-14900KS", 16990000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 46, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "RAM DDR5 4x16GB dual channel, 6000MHz CL36, XMP 3.0, Intel Extreme Memory Profile, tản nhiệt nhôm thấp, tương thích Intel và AMD", 5490000m, "https://bizweb.dktcdn.net/thumb/grande/100/329/122/products/ram-pc-corsair-vengeance-rgb-64gb-6000mhz-ddr5-2x32gb-cmh64gx5m2d6000c40-01.jpg?v=1759114857510", true, false, null, "Corsair Vengeance DDR5 64GB 6000MHz", 5990000m, 20, "Bảo hành chính hãng 12 tháng" },
                    { 47, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SSD NVMe PCIe 4.0 2TB, đọc 7450 MB/s ghi 6900 MB/s, cache 2GB LPDDR4, tản nhiệt heatshield, TBW 1200TB, bảo hành 5 năm", 3490000m, "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/ssd-samsung-990-pro-pcie-gen-4-0-x4-nvme-v-nand-m-2-2280-1tb-mz-v9p1t0bw-2-0e7ba42e-7ddc-4be9-8415-12a33d609067.jpg?v=1661577087873", true, false, null, "Samsung 990 Pro 2TB NVMe PCIe 4.0", 3990000m, 20, "Bảo hành chính hãng 12 tháng" },
                    { 48, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Mainboard AMD B650E ATX socket AM5, DDR5 7200MHz OC, PCIe 5.0 x16, WiFi 6E, Bluetooth 5.3, 4x M.2 PCIe 4.0, 2.5G LAN, USB4 Type-C", null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT9ycJT2BLgmVktCDTju07N11tvWIBWjkz5bA&s", true, false, null, "ASUS ROG Strix B650E-F Gaming WiFi", 8490000m, 6, "Bảo hành chính hãng 12 tháng" },
                    { 49, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Nguồn 1000W modular 80+ Gold, fan Zero RPM mode, ATX 3.0, PCIe 5.0 native, cổng side-connector độc đáo, bảo hành 10 năm", null, "https://bizweb.dktcdn.net/thumb/grande/100/329/122/products/nguon-may-tinh-corsair-rm1000x-shift-1000w-80-plus-gold-cp-9020253-na.jpg?v=1758522543577", true, false, null, "Corsair RM1000x Shift 80+ Gold", 4990000m, 10, "Bảo hành chính hãng 12 tháng" },
                    { 50, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tản nhiệt CPU dual tower cao cấp, 2 quạt 140mm NF-A15, TDP 250W+, socket 1700/AM5, chiều cao 165mm, zero noise ở tải thấp", null, "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/tan-nhiet-khi-noctua-nh-d15-chromax-black-nh-d15-chromax-black-1.jpg?v=1680255731507", true, false, null, "Noctua NH-D15 chromax.black", 1890000m, 15, "Bảo hành chính hãng 12 tháng" },
                    { 51, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Card đồ họa AMD RDNA3 24GB GDDR6, compute 61 TFLOPS, DisplayPort 2.1, HDMI 2.1, Radeon Super Resolution, FSR3, TDP 355W", 19990000m, "https://nguyencongpc.vn/media/product/24039-24gb-gddr624gb-gddr624gb-gddr6.jpg", true, false, null, "AMD Radeon RX 7900 XTX 24GB", 21990000m, 4, "Bảo hành chính hãng 12 tháng" },
                    { 52, 5, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "RAM DDR5 2x16GB 7200MHz CL34, XMP 3.0, tản nhiệt nhôm RGB cao cấp, hỗ trợ Intel 12th/13th/14th gen, kit được test kỹ càng", 2990000m, "https://product.hstatic.net/200000722513/product/z51_5fd17076678d4f5b8bdb7d1d9833c578_d741c129305e401aa8e9f1740c10a5d4.png", true, false, null, "G.SKILL Trident Z5 RGB DDR5 32GB", 3490000m, 22, "Bảo hành chính hãng 12 tháng" },
                    { 53, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tai nghe gaming không dây cao cấp driver 40mm neodymium, ANC chủ động AI, Hi-Res Audio 96kHz/24-bit, pin hot-swap 2 viên, đa nền tảng PC/PS", null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR2ZkasOuaFwbP4nVfmQGu3li1VwMSVaxcZrQ&s", true, false, null, "SteelSeries Arctis Nova Pro Wireless", 8990000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 54, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tai nghe chống ồn số 1 thế giới, 8 mic ANC, Hi-Res Audio 30Hz-40kHz, pin 30 giờ, Bluetooth 5.2 LDAC, multipoint 2 thiết bị, QN2e chip", 6490000m, "https://www.sony.com/image/5d02da5df552836db894cead8a68f5f3?fmt=png-alpha&wid=440", true, false, null, "Sony WH-1000XM5", 7490000m, 15, "Bảo hành chính hãng 12 tháng" },
                    { 55, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tai nghe gaming không dây kỷ lục pin 300 giờ, driver 50mm Dual Chamber riêng bass/mid-treble, âm thanh 7.1 ảo, mic cardioid tháo rời", null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRiaX2_-TxCRX7NW_Meft2MQIz5LzgQmfmVog&s", true, false, null, "HyperX Cloud Alpha Wireless", 3290000m, 20, "Bảo hành chính hãng 12 tháng" },
                    { 56, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tai nghe gaming không dây esports, driver 50mm Triforce Titanium 3 đơn vị riêng, mic SuperCardioid, pin 70 giờ, THX Spatial Audio 360°", 3490000m, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrlw5BRMj_JjOz9ansvdIWI6c_qhupBhkv2g&s", true, false, null, "Razer BlackShark V2 Pro 2023", 3990000m, 12, "Bảo hành chính hãng 12 tháng" },
                    { 57, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tai nghe true wireless ANC H2 chip, Transparency mode Adaptive, Personalized Spatial Audio, IP54, MagSafe, pin 6h + 24h case, USB-C", 5490000m, "https://cdn.tgdd.vn/Products/Images/54/315014/tai-nghe-bluetooth-airpods-pro-2nd-gen-usb-c-charge-apple-1-750x500.jpg", true, false, null, "Apple AirPods Pro 2nd Gen", 5990000m, 20, "Bảo hành chính hãng 12 tháng" },
                    { 58, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tai nghe gaming không dây 47.4g siêu nhẹ, driver PRO-G 50mm graphene, Blue VO!CE mic AI, pin 50 giờ, LIGHTSPEED + Bluetooth", null, "https://www.tncstore.vn/media/product/9068-tai-nghe-logitech-g-pro-x-2-light-speed-wireless-black-1.jpg", true, false, null, "Logitech G PRO X 2 Lightspeed", 4490000m, 10, "Bảo hành chính hãng 12 tháng" },
                    { 59, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tai nghe studio open-back 250 Ohm, dải tần 5-35000Hz, driver Tesla, thiết kế velour earpads, không dây, dành cho mixing/mastering chuyên nghiệp", null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRYyWb_ibwSyoXT9KVra20AclwyCZKiHlZpAQ&s", true, false, null, "Beyerdynamic DT 990 Pro 250 Ohm", 2890000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 60, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tai nghe true wireless ANC thông minh, driver 2-way coaxial, SSC Hi-Fi codec, IP57, pin 6h + 24h case, Galaxy AI real-time translation", 3490000m, "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/t/a/tai-nghe-samsung-galaxy-buds-3-pro_8_.png", true, false, null, "Samsung Galaxy Buds3 Pro", 3990000m, 18, "Bảo hành chính hãng 12 tháng" },
                    { 61, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tai nghe gaming không dây, driver 50mm, ANC + Ambient Aware, JBL QuantumSURROUND, 2.4GHz + Bluetooth, pin 34 giờ ANC off", 2890000m, "https://bizweb.dktcdn.net/thumb/1024x1024/100/451/485/products/jbl-quantum-910-1.jpg?v=1662366706857", true, false, null, "JBL Quantum 910 Wireless", 3290000m, 12, "Bảo hành chính hãng 12 tháng" },
                    { 62, 6, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tai nghe audiophile open-back, driver 38mm transducer, E.A.R. technology, dải tần 12-38500Hz, thiết kế ergonomic, đi kèm 2 cáp 3m và 1.2m", 1690000m, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQi2gXKqNpaPILYBnL5POSvzrVd2F3Vi8kBxg&s", true, false, null, "Sennheiser HD 599 SE", 1990000m, 10, "Bảo hành chính hãng 12 tháng" },
                    { 63, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SSD gaming NVMe PCIe 4.0 2TB, đọc 7300 MB/s ghi 6600 MB/s, Game Mode 2.0, tối ưu PS5, tản nhiệt heatsink tùy chọn, TBW 1200TB", 3490000m, "https://bizweb.dktcdn.net/thumb/1024x1024/100/329/122/products/wd-black-sn850x-2tb-3d-hr.jpg?v=1741160387027", true, false, null, "WD Black SN850X 2TB NVMe PCIe 4.0", 3990000m, 20, "Bảo hành chính hãng 12 tháng" },
                    { 64, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ổ cứng HDD 3.5 inch 4TB, 5400 RPM, cache 256MB, SATA III 6Gb/s, phù hợp NAS và lưu trữ dữ liệu lớn, bảo hành 2 năm", null, "https://bizweb.dktcdn.net/100/329/122/products/seagate-barracuda-3-5-4tb-1.jpg?v=1638370587313", true, false, null, "Seagate Barracuda 4TB HDD 3.5 inch", 1990000m, 30, "Bảo hành chính hãng 12 tháng" },
                    { 65, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SSD PCIe 5.0 nhanh nhất thế giới 2TB, đọc 12400 MB/s ghi 11800 MB/s, heatsink tản nhiệt graphene, DirectStorage Xbox, bảo hành 5 năm", 4490000m, "https://lagihitech.vn/wp-content/uploads/2023/08/SSD-Crucial-T700-2TB-M2-PCIe-Gen-5.0-CT2000T700SSD3-hinh-3.jpg", true, false, null, "Crucial T700 2TB PCIe 5.0 NVMe", 4990000m, 10, "Bảo hành chính hãng 12 tháng" },
                    { 66, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ổ cứng NAS chuyên dụng 20TB, 7200 RPM, cache 256MB, IronWolf Health Management, tối ưu cho NAS 24/7, bảo hành 5 năm + Rescue", null, "https://npp.com.vn/wp-content/uploads/2023/06/ST20000NT001.jpg", true, false, null, "Seagate IronWolf Pro 20TB NAS", 9990000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 67, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SSD di động USB 3.2 Gen 2x2 tốc độ 2000 MB/s, 4TB, chống shock, IP65 bụi/nước, nhỏ gọn 88g, cáp USB-C + USB-A đi kèm", 2990000m, "https://product.hstatic.net/200000320233/product/1696736456-908-o-cung-di-dong-ssd-portable-1tb-samsung-t9-mau-den-6_533557ae3e164a77aa8e2aa8326a5013_1024x1024.jpg", true, false, null, "Samsung T9 4TB Portable SSD", 3490000m, 15, "Bảo hành chính hãng 12 tháng" },
                    { 68, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SSD NVMe PCIe 4.0 2TB enterprise-grade, đọc 7000 MB/s ghi 7000 MB/s, controller Phison E18, TBW 1.6PB, nhiệt độ hoạt động -40°C đến 85°C", null, "https://tandoanh.vn/wp-content/uploads/2022/11/Kingston-KC3000-H1.jpg", true, false, null, "Kingston KC3000 2TB PCIe 4.0", 3290000m, 18, "Bảo hành chính hãng 12 tháng" },
                    { 69, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ổ cứng HDD 2.5 inch 1TB cho laptop, 5400 RPM, cache 128MB, SATA III, chiều dày 7mm, phù hợp nâng cấp laptop đời cũ", 790000m, "https://western.com.vn/media/product/136_o_cung_wd_blue_1tb_wd10spzx_cho_laptop.jpg", true, false, null, "WD Blue 1TB 2.5 inch HDD", 890000m, 40, "Bảo hành chính hãng 12 tháng" },
                    { 70, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SSD NVMe PCIe 4.0 2TB heatsink tản nhiệt, đọc 7300 MB/s ghi 6800 MB/s, controller Phison E18, dung lượng cache 2GB DDR4", 2190000m, "https://bizweb.dktcdn.net/thumb/grande/100/410/941/products/12-a45f3025-8e41-4640-9854-02f9b96f4840.jpg?v=1678674691927", true, false, null, "Silicon Power XS70 2TB PCIe 4.0", 2490000m, 20, "Bảo hành chính hãng 12 tháng" },
                    { 71, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Thẻ nhớ CFexpress Type B 256GB tốc độ cao, đọc 1800 MB/s ghi 1700 MB/s, dành cho máy ảnh/quay phim 8K RAW, bền bỉ -25°C đến 85°C", 4490000m, "https://www.winwinstore.vn/wp-content/uploads/2025/08/4-the-nho-sd-lexar-64gb-professional-1800x-uhs-ii-v60.webp", true, false, null, "Lexar Professional 1800x CFexpress B", 4990000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 72, 7, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "SSD NVMe PCIe 4.0 4TB dung lượng lớn, đọc 7100 MB/s ghi 6600 MB/s, Phison E18, TBW 3000TB, bảo hành 5 năm, dành cho creative professional", 6990000m, "https://tuanphong.vn/pictures/full/2021/05/1621500196-331-o-cung-ssd-m2-pcie-1tb-sabrent-rocket-4-plus-nvme-2280-1.jpg", true, false, null, "Sabrent Rocket 4 Plus 4TB NVMe", 7990000m, 5, "Bảo hành chính hãng 12 tháng" },
                    { 73, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ghế gaming cao cấp nhất, da Neo Hybrid Leatherette, tựa đầu 4D từ tính, tựa lưng điều chỉnh 165°, lumbar built-in, tay vịn 4D điều chỉnh", 10490000m, "https://images-na.ssl-images-amazon.com/images/I/410uYasNqFL.jpg", true, false, null, "Secretlab TITAN Evo 2022 XL", 11990000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 74, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ghế gaming ergonomic cao cấp nhất, PostureFit SL hỗ trợ cột sống, vải thoáng khí Rhythm, bảo hành 12 năm, tùy chỉnh hoàn toàn", null, "https://tanthanhdanh.vn/wp-content/uploads/2022/01/Herman-Miller-X-Logitech-G-Embody-Gaming-Chair-Cyan-1.jpg", true, false, null, "Herman Miller Embody Gaming Chair", 42990000m, 3, "Bảo hành chính hãng 12 tháng" },
                    { 75, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ghế gaming phổ biến nhất esports, khung thép, đệm PU leather cao cấp, tựa lưng 90-135°, tay vịn 3D, gối đầu và lưng đi kèm", 5490000m, "https://m.media-amazon.com/images/I/61ANYzz96+L._AC_UF894,1000_QL80_.jpg", true, false, null, "DXRacer Formula F08 Gaming Chair", 5990000m, 15, "Bảo hành chính hãng 12 tháng" },
                    { 76, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ghế gaming premium Đức, da vegan PU màng đôi, Memory Foam lumbar, tựa lưng 135°, tải 150kg, 4D armrest, thiết kế thể thao", 7990000m, "https://product.hstatic.net/1000333506/product/noblechairs-hero-series-gaming-chair-black-1_9636fe3c9a6241e5808dec863984f606_1024x1024.jpg", true, false, null, "Noblechairs HERO Gaming Chair", 8990000m, 10, "Bảo hành chính hãng 12 tháng" },
                    { 77, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ghế gaming tải 180kg, vải Linen Cloud 5D, tựa lưng 165°, 4D armrest, tựa đầu và lưng Memory Foam, khung thép 2mm, bảo hành 2 năm", 5990000m, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS32mTNUqtmAETVwJe1HhKOdu_i6Apz_St-iQ&s", true, false, null, "AndaSeat Kaiser 4 XL", 6490000m, 12, "Bảo hành chính hãng 12 tháng" },
                    { 78, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ghế gaming Corsair leatherette cao cấp, tựa lưng 90-180° flat, Memory Foam tựa đầu và lưng, tay vịn 4D, tải 120kg, thiết kế racing", null, "https://nguyencongpc.vn/media/product/23944-corsair-tc200-leatherette-light-grey-white.jpg", true, false, null, "Corsair TC200 Leatherette Gaming Chair", 7990000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 79, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ghế gaming Razer ergonomic, tựa lưng lumbar built-in điều chỉnh, da vegan, tựa đầu memory foam, tay vịn 4D, tải 136kg, bảo hành 2 năm", 8990000m, "https://product.hstatic.net/200000722513/product/ghe-gaming-razer-iskur-v2-rz38-0_0878920999844332a0cd6435d6cc6eaa.png", true, false, null, "Razer Iskur V2", 9990000m, 6, "Bảo hành chính hãng 12 tháng" },
                    { 80, 8, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ghế gaming giá tốt, khung thép chắc chắn, da PU bền, tựa lưng 150°, tay vịn 3D, bơm hơi điều chỉnh độ cao, phù hợp sinh viên", 2590000m, "https://xiaomistoreph.com/cdn/shop/products/Hbada_ChairE301BLA_WBG_2_1000x1000.jpg?v=1749553078", true, false, null, "Xiaomi Gaming Chair", 2990000m, 20, "Bảo hành chính hãng 12 tháng" },
                    { 81, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "iPhone cao cấp nhất Apple chip A18 Pro, màn hình Super Retina XDR 6.9 inch ProMotion 120Hz, camera 48MP Fusion + 12MP Tetra Prism 5x zoom", 32990000m, "https://cdn2.cellphones.com.vn/x/media/catalog/product/p/h/photo_2024-10-02_13-59-00_1.jpg", true, false, null, "iPhone 16 Pro Max 256GB", 34990000m, 15, "Bảo hành chính hãng 12 tháng" },
                    { 82, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "iPhone tầm trung Apple chip A16 Bionic, màn hình Super Retina XDR 6.1 inch, Dynamic Island, camera 48MP chính, USB-C, pin 20 giờ video", 18490000m, "https://cdn.tgdd.vn/Products/Images/42/281570/iphone-15-xanh-thumb-600x600.jpg", true, false, null, "iPhone 15 128GB", 19990000m, 20, "Bảo hành chính hãng 12 tháng" },
                    { 83, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Flagship Android Snapdragon 8 Elite, màn hình Dynamic AMOLED 6.9 inch 120Hz, bút S Pen tích hợp, camera 200MP, Galaxy AI, RAM 12GB", 29990000m, "https://cdn2.fptshop.com.vn/unsafe/512x0/filters:format(webp):quality(75)/galaxy_s25_ultra_titan_silver_blue_2_85ef2eff39.png", true, false, null, "Samsung Galaxy S25 Ultra 512GB", 32990000m, 12, "Bảo hành chính hãng 12 tháng" },
                    { 84, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Flagship Android Snapdragon 8 Elite, màn hình Dynamic AMOLED 6.7 inch 120Hz, camera 50MP, Galaxy AI translation real-time, IP68, RAM 12GB", 20990000m, "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/d/i/dien-thoai-samsung-galaxy-s25_27__2_1_2.png", true, false, null, "Samsung Galaxy S25+ 256GB", 22990000m, 15, "Bảo hành chính hãng 12 tháng" },
                    { 85, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Flagship Google chip Tensor G4, màn hình LTPO OLED 6.8 inch 1-120Hz, camera 50MP + 48MP ultrawide + 48MP 5x zoom, Gemini AI tích hợp", null, "https://product.hstatic.net/1000370129/product/cd246c789aa4695dbbda8af_master_5544aebb4580483ba363207b86b70537_master_71c0f27431f64b86b52bc23bf56d9460_master.jpg", true, false, null, "Google Pixel 9 Pro XL 256GB", 24990000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 86, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Flagship Android Snapdragon 8 Elite, màn hình AMOLED 6.82 inch 1-120Hz, camera Hasselblad 50MP, sạc nhanh 100W, sạc không dây 50W, RAM 16GB", 16990000m, "https://viostore.vn/wp-content/uploads/2024/10/26.png", true, false, null, "OnePlus 13 512GB", 18990000m, 10, "Bảo hành chính hãng 12 tháng" },
                    { 87, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Flagship Xiaomi Snapdragon 8 Elite, màn hình LTPO AMOLED 6.73 inch 1-120Hz, camera Leica 50MP, sạc 90W có dây + 50W không dây, RAM 16GB", 21990000m, "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/i/m/image_1262703570.jpg", true, false, null, "Xiaomi 15 Pro 512GB", 23990000m, 8, "Bảo hành chính hãng 12 tháng" },
                    { 88, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Flagship OPPO Dimensity 9400, màn hình AMOLED 6.78 inch 120Hz BOE, camera Hasselblad 50MP periscope 6x, sạc nhanh 80W + 50W wireless, RAM 16GB", 23990000m, "https://www.xtmobile.vn/vnt_upload/product/06_2024/oppo-find-x8-pro-xtmobile.jpg", true, false, null, "OPPO Find X8 Pro 512GB", 25990000m, 6, "Bảo hành chính hãng 12 tháng" },
                    { 89, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tầm trung Samsung Exynos 1480, màn hình Super AMOLED 6.6 inch FHD+ 120Hz, camera 50MP OIS, IP67, RAM 8GB, pin 5000mAh sạc 45W", 8490000m, "https://cdn-v3.xtmobile.vn/vnt_upload/product/05_2024/thumbs/600_samsung_galaxy_a55_5g_awesome_lemon_8_256gb_6_6_quot_amoled_120hz_full_hd_2.jpg", true, false, null, "Samsung Galaxy A55 5G 256GB", 9490000m, 25, "Bảo hành chính hãng 12 tháng" },
                    { 90, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "iPhone nhỏ gọn giá tốt Apple chip A15 Bionic, màn hình Retina 4.7 inch, camera 12MP, Touch ID Home button, 5G, pin 15 giờ video", 10990000m, "https://cdn.viettablet.com/images/thumbnails/480/516/detailed/52/apple-iphone-se-3-2022-chinh-hang_9szb-as.jpg", true, false, null, "iPhone SE 3rd Gen 64GB", 11990000m, 18, "Bảo hành chính hãng 12 tháng" },
                    { 91, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Flagship Vivo Dimensity 9400, camera Zeiss 200MP periscope + 50MP ultrawide, màn hình AMOLED 6.78 inch 1-120Hz, sạc 90W, pin 6000mAh, RAM 16GB", 20490000m, "https://viostore.vn/wp-content/uploads/2024/10/2-9.png", true, false, null, "Vivo X200 Pro 512GB", 22990000m, 7, "Bảo hành chính hãng 12 tháng" },
                    { 92, 9, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Thiết kế Glyph Interface LED độc đáo, Dimensity 7350 Pro, màn hình AMOLED 6.7 inch 120Hz, camera 50MP + 50MP ultrawide, RAM 12GB, IP54", 7990000m, "https://cdn2.cellphones.com.vn/insecure/rs:fill:0:358/q:90/plain/https://cellphones.com.vn/media/catalog/product/d/i/dien-thoai-nothing-phone-2a-plus_1_.png", true, false, null, "Nothing Phone 2a Plus 256GB", 8990000m, 12, "Bảo hành chính hãng 12 tháng" },
                    { 93, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bộ Office đầy đủ Word, Excel, PowerPoint, Outlook, OneNote, OneDrive 1TB, Teams Premium, cập nhật tự động, 1 người dùng đa thiết bị", 1390000m, "https://www.sieuthimaychu.vn/datafiles/setone/17586163099598.png", true, false, null, "Microsoft 365 Personal 1 năm", 1590000m, 999, "Bảo hành chính hãng 12 tháng" },
                    { 94, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bộ Office cho gia đình 6 người dùng, Word/Excel/PowerPoint/Outlook, OneDrive 1TB/người, 60 phút Skype/tháng, đa thiết bị Win/Mac/iOS/Android", 2090000m, "https://www.sieuthimaychu.vn/datafiles/setone/17586163099598.png", true, false, null, "Microsoft 365 Family 1 năm", 2390000m, 999, "Bảo hành chính hãng 12 tháng" },
                    { 95, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Bản quyền Windows 11 Pro chính hãng Microsoft, kích hoạt trực tuyến vĩnh viễn, hỗ trợ nâng cấp miễn phí, dùng được cho 1 thiết bị, ngôn ngữ đa quốc gia", 990000m, "https://cdn-dynmedia-1.microsoft.com/is/image/microsoftcorp/PT_RGB_Windows11_Pro_EN_375x375", true, false, null, "Windows 11 Pro OEM Key", 1290000m, 999, "Bảo hành chính hãng 12 tháng" },
                    { 96, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Toàn bộ ứng dụng Adobe: Photoshop, Illustrator, Premiere Pro, After Effects, Lightroom, Acrobat Pro, 100GB cloud storage, cập nhật liên tục", 10990000m, "https://cdn.tgdd.vn/GameApp/3/235353/Screentshots/tai-adobe-creative-cloud-phan-mem-ho-tro-quan-ly-va-235353-logo-18-02-2021.png", true, false, null, "Adobe Creative Cloud All Apps 1 năm", 12990000m, 999, "Bảo hành chính hãng 12 tháng" },
                    { 97, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Đăng ký ChatGPT Plus GPT-4o không giới hạn, DALL-E 3 tạo ảnh AI, GPT-4 phân tích file, web browsing real-time, Custom GPTs, ưu tiên tốc độ", null, "https://upload.wikimedia.org/wikipedia/commons/thumb/0/04/ChatGPT_logo.svg/1024px-ChatGPT_logo.svg.png", true, false, null, "ChatGPT Plus 1 tháng", 520000m, 999, "Bảo hành chính hãng 12 tháng" },
                    { 98, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Gói ChatGPT Plus 1 năm tiết kiệm 15%, GPT-4o + DALL-E 3 + Advanced Data Analysis + Browsing, Custom GPTs marketplace, ưu tiên tốc độ 24/7", 4990000m, "https://upload.wikimedia.org/wikipedia/commons/thumb/0/04/ChatGPT_logo.svg/1024px-ChatGPT_logo.svg.png", true, false, null, "ChatGPT Plus 12 tháng", 5290000m, 999, "Bảo hành chính hãng 12 tháng" },
                    { 99, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Đăng ký Claude Pro Anthropic, truy cập Claude 3.5 Sonnet/Opus không giới hạn, Projects tổ chức hội thoại, độ dài context 200K token, ưu tiên tốc độ", null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT0PjFAsBQtufK2kk5JIsWuvChlLDu8FPgtYw&s", true, false, null, "Claude Pro 1 tháng", 520000m, 999, "Bảo hành chính hãng 12 tháng" },
                    { 100, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Tạo ảnh AI không giới hạn Midjourney v6.1, 15 giờ Fast GPU/tháng, Relax mode unlimited, Stealth mode ẩn ảnh, Remix + Vary Region chỉnh sửa", 350000m, "https://i0.wp.com/software.centrix.asia/wp-content/uploads/2024/10/Midjourney-Basic-Plan.png?fit=1080%2C1080&ssl=1", true, false, null, "Midjourney Standard Plan 1 tháng", 390000m, 999, "Bảo hành chính hãng 12 tháng" },
                    { 101, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Thiết kế chuyên nghiệp Canva Pro 1 năm, 100M+ template, 75M+ stock ảnh/video, Background Remover, Magic Resize, Brand Kit, 1TB storage", 990000m, "https://images-eds-ssl.xboxlive.com/image?url=4rt9.lXDC4H_93laV1_eHHFT949fUipzkiFOBH3fAiZZUCdYojwUyX2aTonS1aIwMrx6NUIsHfUHSLzjGJFxxo4K81Ei7WzcnqEk8W.MgwbrV7KGaO26hIr2djuNhOO6._j8uCsDS5VM2l2zZ5lg_lA3NC6rF2454qkJTgncsPY-&format=source", true, false, null, "Canva Pro 1 năm", 1290000m, 999, "Bảo hành chính hãng 12 tháng" },
                    { 102, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Workspace all-in-one Notion Plus + AI không giới hạn, AI viết/tóm tắt/dịch/phân tích, 100GB file storage, unlimited guest, custom domain", 1390000m, "https://upload.wikimedia.org/wikipedia/commons/4/45/Notion_app_logo.png", true, false, null, "Notion AI Plus 1 năm", 1590000m, 999, "Bảo hành chính hãng 12 tháng" },
                    { 103, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Kiểm tra ngữ pháp tiếng Anh AI nâng cao, full-sentence rewrites, tone detector, plagiarism checker, tích hợp 500k+ app, phân tích writing analytics", 2490000m, "https://i0.wp.com/software.centrix.asia/wp-content/uploads/2024/10/Grammarly.png?fit=1080%2C1080&ssl=1", true, false, null, "Grammarly Business 1 năm", 2990000m, 999, "Bảo hành chính hãng 12 tháng" },
                    { 104, 10, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "VPN bảo mật hàng đầu thế giới 6 thiết bị/cùng lúc, 6400+ server 111 quốc gia, Threat Protection chặn malware, Meshnet kết nối thiết bị riêng", 990000m, "https://digitalnext.co.uk/wp-content/uploads/2024/05/NordVPN-image.png", true, false, null, "NordVPN 2 năm", 1390000m, 999, "Bảo hành chính hãng 12 tháng" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionLogs_UserId",
                table: "CommissionLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecifications_ProductId",
                table: "ProductSpecifications",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantGroups_CategoryId",
                table: "ProductVariantGroups",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantOptions_ProductVariantGroupId",
                table: "ProductVariantOptions",
                column: "ProductVariantGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                table: "ProductVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantSelections_ProductId",
                table: "ProductVariantSelections",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantSelections_ProductVariantOptionId",
                table: "ProductVariantSelections",
                column: "ProductVariantOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantValues_ProductVariantId",
                table: "ProductVariantValues",
                column: "ProductVariantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariantValues_ProductVariantOptionId",
                table: "ProductVariantValues",
                column: "ProductVariantOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreInventories_ProductId",
                table: "StoreInventories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WarrantyPackages_ProductId",
                table: "WarrantyPackages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_ProductId",
                table: "Wishlists",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wishlists_UserId",
                table: "Wishlists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CommissionLogs");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductSpecifications");

            migrationBuilder.DropTable(
                name: "ProductVariantSelections");

            migrationBuilder.DropTable(
                name: "ProductVariantValues");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ServiceTickets");

            migrationBuilder.DropTable(
                name: "StoreInventories");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "WarrantyPackages");

            migrationBuilder.DropTable(
                name: "Wishlists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductVariantOptions");

            migrationBuilder.DropTable(
                name: "ProductVariants");

            migrationBuilder.DropTable(
                name: "StoreBranches");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProductVariantGroups");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
