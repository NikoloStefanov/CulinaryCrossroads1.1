using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CullinaryCrossroads1._1.Infrastructure.Migrations
{
    public partial class AddLikerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LikerId",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e283cb1-5ea3-4a2a-abc7-8dff88d9bdce", "AQAAAAEAACcQAAAAEHOfGirRiO4RxzVP5a7/5L+WA0yUKfE+FAT6QbZNqPFX0bkIO/065IR/H47BQ+XoPA==", "cbbaa13e-74ec-4b6f-acce-6b6d2e1cefdc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c263c2e7-ce1b-4f88-9a7c-db793ac9b8b3", "AQAAAAEAACcQAAAAECJSckB+GCUoTaSEkjLButg6Hopj6xVxpbhcHeIalnSt65JXNfJJFWgYS78gkxLU7g==", "01eb5825-090a-42e3-afe2-80e1b0113855" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikerId",
                table: "Foods");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a77dde11-2fd4-4b04-afb5-d13db9200800", "AQAAAAEAACcQAAAAEO667yb9gHH38AtyQSo/rjVBjVBgL0z7UUUfEdDD3k0mv5UeFLbRdJ4wbERCgYTpcg==", "6917bb74-92dd-4479-a80f-4f594e22ed7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ecab2fb-7fbc-462e-9e1a-9c63dcd574d9", "AQAAAAEAACcQAAAAEMfujCihca9tQ2cxPgtA2FAMy5dUKj28ds+b/c16NiKtyqVTTMfZKyQh6xd+IWm8Cw==", "c3224a46-6139-409c-bcda-47a325fc223e" });
        }
    }
}
