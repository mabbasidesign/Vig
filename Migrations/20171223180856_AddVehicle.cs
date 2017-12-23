using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Viga.Migrations
{
    public partial class AddVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Makes_MakeID",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "Model");

            migrationBuilder.RenameIndex(
                name: "IX_Models_MakeID",
                table: "Model",
                newName: "IX_Model_MakeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactEmail = table.Column<string>(maxLength: 255, nullable: true),
                    ContactName = table.Column<string>(maxLength: 255, nullable: false),
                    ContactPhone = table.Column<string>(maxLength: 255, nullable: false),
                    IsRegistered = table.Column<bool>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    ModelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleFeature",
                columns: table => new
                {
                    VehicleId = table.Column<int>(nullable: false),
                    FeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFeature", x => new { x.VehicleId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_VehicleFeature_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleFeature_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ModelId",
                table: "Vehicle",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFeature_FeatureId",
                table: "VehicleFeature",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Makes_MakeID",
                table: "Model",
                column: "MakeID",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_Makes_MakeID",
                table: "Model");

            migrationBuilder.DropTable(
                name: "VehicleFeature");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "Models");

            migrationBuilder.RenameIndex(
                name: "IX_Model_MakeID",
                table: "Models",
                newName: "IX_Models_MakeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Makes_MakeID",
                table: "Models",
                column: "MakeID",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
