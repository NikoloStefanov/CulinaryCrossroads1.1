using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CullinaryCrossroads1._1.Infrastructure.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f728d758-02fb-454d-ac3a-b6ff6420acf1", "AQAAAAEAACcQAAAAEPKEXxIrnRFJ2WcHyRi8xm2CYF4gQq2A77IcPNe+DPq5mY6LcLCzv0MMj2KvusMNZw==", "c8f9cda1-a5ad-465c-b9db-39f62a2cf70b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7154d6cc-f4e4-4e40-8fc5-0247bfee6497", "AQAAAAEAACcQAAAAEFNOO6WXXezZUUne56J+R9rS955Z1py+0TbqEtddKbJSBAFTGvqbUSnaPVlglZS60A==", "460754d4-b224-44af-aa1b-652579fa13e8" });
        }
    }
}
