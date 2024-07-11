using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EasyQuestionAnswer",
                table: "Risks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HardQuestionAnswer",
                table: "Risks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeduimQuestionAnswer",
                table: "Risks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegularQuestionAnswer",
                table: "Risks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EasyQuestionAnswer",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "HardQuestionAnswer",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "MeduimQuestionAnswer",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "RegularQuestionAnswer",
                table: "Risks");
        }
    }
}
