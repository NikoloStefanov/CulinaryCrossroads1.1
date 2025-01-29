using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CullinaryCrossroads1._1.Infrastructure.Migrations
{
    public partial class UpdateLikerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LikerId",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LikerId",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
