// <copyright file="20190703130649_PasswordMigration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PayingSystem.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

#pragma warning disable SA1601 // Partial elements should be documented
    public partial class PasswordMigration : Migration
#pragma warning restore SA1601 // Partial elements should be documented
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.CreateTable(
            //    name: "Addresses",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        Country = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
            //        City = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
            //        Street = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
            //        HOUSE = table.Column<string>(unicode: false, maxLength: 6, nullable: false),
            //        Flat = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Addresses", x => x.Id);
            //    });

            // migrationBuilder.CreateTable(
            //    name: "Clients",
            //    columns: table => new
            //    {
            //        ClientId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        FirstName = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
            //        LastName = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
            //        Email = table.Column<string>(unicode: false, maxLength: 40, nullable: false),
            //        PhoneNumber = table.Column<string>(unicode: false, maxLength: 12, nullable: false),
            //        AddressId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__tmp_ms_x__E67E1A24DE1A5C39", x => x.ClientId);
            //        table.ForeignKey(
            //            name: "FK__Clients__Address__6477ECF3",
            //            column: x => x.AddressId,
            //            principalTable: "Addresses",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            // migrationBuilder.CreateTable(
            //    name: "Accounts",
            //    columns: table => new
            //    {
            //        CardNumber = table.Column<int>(nullable: false),
            //        ClientId = table.Column<int>(nullable: false),
            //        Expire = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate()+(5))"),
            //        Balance = table.Column<double>(nullable: false),
            //        HashPassword = table.Column<string>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Accounts__A4E9FFE84A9473EA", x => x.CardNumber);
            //        table.ForeignKey(
            //            name: "FK__Accounts__Client__5DCAEF64",
            //            column: x => x.ClientId,
            //            principalTable: "Clients",
            //            principalColumn: "ClientId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            // migrationBuilder.CreateTable(
            //    name: "Shops",
            //    columns: table => new
            //    {
            //        ShopName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
            //        AddressId = table.Column<int>(nullable: false),
            //        CardNumber = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Shops__C40BBF388095871C", x => new { x.ShopName, x.AddressId });
            //        table.ForeignKey(
            //            name: "FK__Shops__AddressId__656C112C",
            //            column: x => x.AddressId,
            //            principalTable: "Addresses",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK__Shops__CardNumbe__300424B4",
            //            column: x => x.CardNumber,
            //            principalTable: "Accounts",
            //            principalColumn: "CardNumber",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            // migrationBuilder.CreateTable(
            //    name: "ProductLists",
            //    columns: table => new
            //    {
            //        ProductListId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ShopName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
            //        AddressId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__tmp_ms_x__86F3FF2598A9B94C", x => x.ProductListId);
            //        table.ForeignKey(
            //            name: "FK__ProductLists__60A75C0F",
            //            columns: x => new { x.ShopName, x.AddressId },
            //            principalTable: "Shops",
            //            principalColumns: new[] { "ShopName", "AddressId" },
            //            onDelete: ReferentialAction.Restrict);
            //    });

            // migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        ProductId = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        ProductListId = table.Column<int>(nullable: false),
            //        ProductName = table.Column<string>(unicode: false, maxLength: 30, nullable: false),
            //        Price = table.Column<double>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__tmp_ms_x__B40CC6CDA5D2A16C", x => x.ProductId);
            //        table.ForeignKey(
            //            name: "FK__Products__Produc__68487DD7",
            //            column: x => x.ProductListId,
            //            principalTable: "ProductLists",
            //            principalColumn: "ProductListId",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            // migrationBuilder.CreateIndex(
            //    name: "IX_Accounts_ClientId",
            //    table: "Accounts",
            //    column: "ClientId");

            // migrationBuilder.CreateIndex(
            //    name: "IX_Clients_AddressId",
            //    table: "Clients",
            //    column: "AddressId");

            // migrationBuilder.CreateIndex(
            //    name: "IX_ProductLists_ShopName_AddressId",
            //    table: "ProductLists",
            //    columns: new[] { "ShopName", "AddressId" });

            // migrationBuilder.CreateIndex(
            //    name: "IX_Products_ProductListId",
            //    table: "Products",
            //    column: "ProductListId");

            // migrationBuilder.CreateIndex(
            //    name: "IX_Shops_AddressId",
            //    table: "Shops",
            //    column: "AddressId");

            // migrationBuilder.CreateIndex(
            //    name: "IX_Shops_CardNumber",
            //    table: "Shops",
            //    column: "CardNumber");
            migrationBuilder.AddColumn<string>(
            name: "HashPassword",
            table: "Accounts",
            nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductLists");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
