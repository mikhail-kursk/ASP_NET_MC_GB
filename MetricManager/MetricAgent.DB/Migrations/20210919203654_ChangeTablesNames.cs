using Microsoft.EntityFrameworkCore.Migrations;

namespace MetricAgent.DB.Migrations
{
    public partial class ChangeTablesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RamEntity",
                table: "RamEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NetworkEntity",
                table: "NetworkEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HddEntity",
                table: "HddEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DotnetEntity",
                table: "DotnetEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CpuEntity",
                table: "CpuEntity");

            migrationBuilder.RenameTable(
                name: "RamEntity",
                newName: "RamMetrics");

            migrationBuilder.RenameTable(
                name: "NetworkEntity",
                newName: "NetworkMetrics");

            migrationBuilder.RenameTable(
                name: "HddEntity",
                newName: "HddMetrics");

            migrationBuilder.RenameTable(
                name: "DotnetEntity",
                newName: "DotnetMetrics");

            migrationBuilder.RenameTable(
                name: "CpuEntity",
                newName: "CpuMetrics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RamMetrics",
                table: "RamMetrics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetworkMetrics",
                table: "NetworkMetrics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HddMetrics",
                table: "HddMetrics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DotnetMetrics",
                table: "DotnetMetrics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CpuMetrics",
                table: "CpuMetrics",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RamMetrics",
                table: "RamMetrics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NetworkMetrics",
                table: "NetworkMetrics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HddMetrics",
                table: "HddMetrics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DotnetMetrics",
                table: "DotnetMetrics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CpuMetrics",
                table: "CpuMetrics");

            migrationBuilder.RenameTable(
                name: "RamMetrics",
                newName: "RamEntity");

            migrationBuilder.RenameTable(
                name: "NetworkMetrics",
                newName: "NetworkEntity");

            migrationBuilder.RenameTable(
                name: "HddMetrics",
                newName: "HddEntity");

            migrationBuilder.RenameTable(
                name: "DotnetMetrics",
                newName: "DotnetEntity");

            migrationBuilder.RenameTable(
                name: "CpuMetrics",
                newName: "CpuEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RamEntity",
                table: "RamEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NetworkEntity",
                table: "NetworkEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HddEntity",
                table: "HddEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DotnetEntity",
                table: "DotnetEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CpuEntity",
                table: "CpuEntity",
                column: "Id");
        }
    }
}
