using Microsoft.EntityFrameworkCore.Migrations;

namespace Assginment.Migrations
{
    public partial class Database_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Users = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Like = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User = table.Column<string>(nullable: true),
                    comment = table.Column<string>(nullable: true),
                    Postid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_Postid",
                        column: x => x.Postid,
                        principalTable: "Posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "id", "Postid", "User", "comment" },
                values: new object[,]
                {
                    { 1, null, "Raju", "I don't" },
                    { 2, null, "Raju", "I don" },
                    { 3, null, "Raja", "I" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "id", "Like", "Message", "Users" },
                values: new object[,]
                {
                    { 1, 5, "I Love Coding", "Raju" },
                    { 2, 2, "I Coding for Life", "Raj" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Postid",
                table: "Comments",
                column: "Postid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
