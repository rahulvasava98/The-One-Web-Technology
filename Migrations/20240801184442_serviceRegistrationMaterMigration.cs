using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace The_One_Web_Technology.Migrations
{
    /// <inheritdoc />
    public partial class serviceRegistrationMaterMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "serviceRegistrationMasters",
                columns: table => new
                {
                    clientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clientfirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clientlastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clientemail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clientlocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clientservice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clientmessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clientPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clientReferenceId = table.Column<int>(type: "int", nullable: false),
                    clientReferenceCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceOtp = table.Column<int>(type: "int", nullable: false),
                    registrationStatus = table.Column<bool>(type: "bit", nullable: false)

                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceRegistrationMasters", x => x.clientId);
                });
        }

        
    }
}
