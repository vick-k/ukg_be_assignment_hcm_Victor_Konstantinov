using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HCM.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DepartmentId", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "JobTitleId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Salary", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("1211a2a3-dcd7-4a3d-be2d-aa8d07af4465"), 0, "a88705e9-dbb8-49ea-b6dd-d45c9499a64a", 6, "g.georgiev@hcm.com", false, "George", false, 6, "Georgiev", true, null, "G.GEORGIEV@HCM.COM", "GEORGE", "AQAAAAIAAYagAAAAELIzFatM08flQORp5H615yXvfhZh9KlZKutUaxQMQ3Bme8qWwZX+HQOwNCvrSnha7Q==", null, false, 3500m, "5b670aa2-3db4-447c-9a0c-0e0514018da4", false, "george" },
                    { new Guid("21e27e05-cbee-44b0-88c2-0a6473769deb"), 0, "ee4f6cc3-94f9-494c-b470-235d4c34fc96", 4, "i.ivanov@hcm.com", false, "Ivan", false, 3, "Ivanov", true, null, "I.IVANOV@HCM.COM", "IVAN", "AQAAAAIAAYagAAAAEEiGyHne4+XmmPwsH1pKWpVKzh7KqSzppuHL001gpTOKjiHMPXlwVjXp7OBxdWjyWg==", null, false, 1000m, "80390b3f-b152-4194-9dda-8b85400bbf69", false, "ivan" },
                    { new Guid("9835d1fa-775f-4396-b50e-5135a2112208"), 0, "52b51e41-1efb-46f6-8f66-70f05076ad5c", 6, "p.petrov@hcm.com", false, "Peter", false, 5, "Petrov", true, null, "P.PETROV@HCM.COM", "PETER", "AQAAAAIAAYagAAAAEEgrauZPwkipRnpUF8eqkFzSj8XginHoexlHYF+zbcs++SGN+RO3jYgpb3aNG1E82w==", null, false, 2500m, "afc7ede9-4c46-48f1-80c7-a6c9bf7cbb7a", false, "peter" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1211a2a3-dcd7-4a3d-be2d-aa8d07af4465"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21e27e05-cbee-44b0-88c2-0a6473769deb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9835d1fa-775f-4396-b50e-5135a2112208"));
        }
    }
}
