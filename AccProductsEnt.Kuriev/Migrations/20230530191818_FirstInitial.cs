﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccProductsEnt.Kuriev.Migrations
{
    public partial class FirstInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ReseiptDate = table.Column<DateTime>(type: "date", nullable: false),
                    ImplementationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Implemented = table.Column<int>(type: "integer", nullable: false),
                    Remainder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCard_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accountings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    WaybillId = table.Column<int>(type: "integer", nullable: false),
                    PriceProduct = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting_", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TIN = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    TIN = table.Column<int>(type: "integer", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NameOfSuppliedRaw = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    StorageName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "date", nullable: false),
                    AccountCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountCards_StorageId_Storages_Id",
                        column: x => x.AccountCardId,
                        principalTable: "AccountCards",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PricePerPiece = table.Column<decimal>(type: "money", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Price_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_PriceListId_PriceLists_Id",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Raws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RawName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    PriceRaw = table.Column<decimal>(type: "money", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ProviderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raws_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Raws_ProviderId_Provider_Id",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Implementations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ImplementationDate = table.Column<DateTime>(type: "date", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Implementation_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Implementations_StorageId_Storages_Id",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Workshops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    WorkshopName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProccesName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RawId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workshop_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workshops_RawId_Raws_Id",
                        column: x => x.RawId,
                        principalTable: "Raws",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    OrdersDate = table.Column<DateTime>(type: "date", nullable: false),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    ImplementationId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_CliientId_Clients_Id",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ImplementationId_Implementations_Id",
                        column: x => x.ImplementationId,
                        principalTable: "Implementations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ProductName = table.Column<string>(type: "integer", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    DateOfManufacture = table.Column<DateTime>(type: "date", nullable: false),
                    PricePerPiece = table.Column<decimal>(type: "money", nullable: false),
                    ImgPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    AccountingId = table.Column<int>(type: "int", nullable: false),
                    ImplementationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AccountingId_Accountings_Id",
                        column: x => x.AccountingId,
                        principalTable: "Accountings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_ImplementationId_Implementations_Id",
                        column: x => x.ImplementationId,
                        principalTable: "Implementations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_StorageId_Storages_Id",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_WorkcshopId_Workshops_Id",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    nvarchar = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Experience = table.Column<int>(type: "integer", nullable: false),
                    Wage = table.Column<decimal>(type: "money", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    AccountingId = table.Column<int>(type: "int", nullable: false),
                    ImplementationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_AccountingId_Accountings_Id",
                        column: x => x.AccountingId,
                        principalTable: "Accountings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Staffs_ImplementationId_Implementations_Id",
                        column: x => x.ImplementationId,
                        principalTable: "Implementations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Staffs_StorageId_Storages_Id",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Staffs_WorkshopId_Workshops_Id",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TechnicalProcesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ProcessName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TimeOfTheEvent = table.Column<DateTime>(type: "Date", nullable: false),
                    RawId = table.Column<int>(type: "int", nullable: false),
                    WorkshopId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalProcesses_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalProcesses_RawId_Raw_Id",
                        column: x => x.RawId,
                        principalTable: "Raws",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TechnicalProcesses_WorkshopId_Workshop_Id",
                        column: x => x.WorkshopId,
                        principalTable: "Workshops",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WriteOffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    WriteOffDate = table.Column<DateTime>(type: "date", nullable: false),
                    Cause = table.Column<string>(type: "nvarchar", nullable: false),
                    QuntityProduct = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteOffs_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_WriteOffId_WriteOffs_Id",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    PostTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    JobResponsibilities = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_PostId_Posts_Id",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Implementations_StorageId",
                table: "Implementations",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ImplementationId",
                table: "Orders",
                column: "ImplementationId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_StaffId",
                table: "Posts",
                column: "StaffId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PriceLists_ClientId",
                table: "PriceLists",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccountingId",
                table: "Products",
                column: "AccountingId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ImplementationId",
                table: "Products",
                column: "ImplementationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StorageId",
                table: "Products",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_WorkshopId",
                table: "Products",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Raws_ProviderId",
                table: "Raws",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_AccountingId",
                table: "Staffs",
                column: "AccountingId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_ImplementationId",
                table: "Staffs",
                column: "ImplementationId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StorageId",
                table: "Staffs",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_WorkshopId",
                table: "Staffs",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_AccountCardId",
                table: "Storages",
                column: "AccountCardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalProcesses_RawId",
                table: "TechnicalProcesses",
                column: "RawId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalProcesses_WorkshopId",
                table: "TechnicalProcesses",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Workshops_RawId",
                table: "Workshops",
                column: "RawId");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffs_ProductId",
                table: "WriteOffs",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "TechnicalProcesses");

            migrationBuilder.DropTable(
                name: "WriteOffs");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Accountings");

            migrationBuilder.DropTable(
                name: "Implementations");

            migrationBuilder.DropTable(
                name: "Workshops");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Raws");

            migrationBuilder.DropTable(
                name: "AccountCards");

            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
