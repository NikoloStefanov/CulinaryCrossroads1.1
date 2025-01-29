using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CullinaryCrossroads1._1.Infrastructure.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LikerId",
                table: "Foods");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78098393-a578-416b-a11b-d828ca2b846e", "AQAAAAEAACcQAAAAEEA4Ruqzrr21QzNRGuUjlOXweMcW+NuqcFUTZnsgFvzfXMyFHV0ciI56G3EUEZ12yw==", "7d616f61-5fe5-49b2-afdd-02f52a001d1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "471f8b42-3165-4c07-9dd5-d79554de9f40", "AQAAAAEAACcQAAAAEAfJiyrwbPVYmWaX1MXvjPWyPbcv0Ib3hOaLfWTIaOKbPowD0i/FLKhFQR+dOmyK0g==", "11d1dadb-8da7-43b1-ad0d-ff966ed2db93" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Just-For-Connoisseurs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LikerId",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81de7c03-6522-408f-adf3-74be94859a2b", "AQAAAAEAACcQAAAAELTewnCHXzwEXYAmYSz+iyrUKBIrNqoajN44XdHZU6dsq0crFH6H7UG+PB3kw3pg2g==", "b349c165-58f8-4c23-8fb7-0be676652c8a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9fef245-5048-44d5-8895-423adf913a04", "AQAAAAEAACcQAAAAEMpnstdf7J9VJmiFiuJJr2+kyzjUIEZDbpC9dqdJI3GaV/zgIsajw5s0W68z+CeaVg==", "3f551051-5e7b-4224-add2-164e3e78a558" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Healthy");
        }
    }
}
