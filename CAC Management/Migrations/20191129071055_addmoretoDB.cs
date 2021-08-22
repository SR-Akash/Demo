using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CAC_Management.Migrations
{
    public partial class addmoretoDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherAttendance");

            migrationBuilder.AddColumn<int>(
                name: "DueAmount2",
                table: "Student",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueAmount2",
                table: "Student");

            migrationBuilder.CreateTable(
                name: "TeacherAttendance",
                columns: table => new
                {
                    T_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(nullable: false),
                    T_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAttendance", x => x.T_Id);
                });
        }
    }
}
