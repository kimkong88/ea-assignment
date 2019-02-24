using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment.Data.Migrations
{
	public partial class InitialCreate : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.EnsureSchema(
				name: "blog");

			migrationBuilder.CreateTable(
				name: "author",
				schema: "blog",
				columns: table => new
				{
					id = table.Column<Guid>(nullable: false),
					name = table.Column<string>(nullable: true),
					created_at = table.Column<DateTimeOffset>(nullable: false),
					updated_at = table.Column<DateTimeOffset>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_author", x => x.id);
				});

			migrationBuilder.CreateTable(
				name: "post",
				schema: "blog",
				columns: table => new
				{
					id = table.Column<Guid>(nullable: false),
					author_id = table.Column<Guid>(nullable: true),
					title = table.Column<string>(nullable: true),
					content = table.Column<string>(nullable: true),
					created_at = table.Column<DateTimeOffset>(nullable: false),
					updated_at = table.Column<DateTimeOffset>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_post", x => x.id);
					table.ForeignKey(
						name: "FK_post_author_author_id",
						column: x => x.author_id,
						principalSchema: "blog",
						principalTable: "author",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateTable(
				name: "comment",
				schema: "blog",
				columns: table => new
				{
					id = table.Column<Guid>(nullable: false),
					author_id = table.Column<Guid>(nullable: true),
					post_id = table.Column<Guid>(nullable: true),
					content = table.Column<string>(nullable: true),
					created_at = table.Column<DateTimeOffset>(nullable: false),
					updated_at = table.Column<DateTimeOffset>(nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_comment", x => x.id);
					table.ForeignKey(
						name: "FK_comment_author_author_id",
						column: x => x.author_id,
						principalSchema: "blog",
						principalTable: "author",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
					table.ForeignKey(
						name: "FK_comment_post_post_id",
						column: x => x.post_id,
						principalSchema: "blog",
						principalTable: "post",
						principalColumn: "id",
						onDelete: ReferentialAction.Restrict);
				});

			migrationBuilder.CreateIndex(
				name: "IX_author_name",
				schema: "blog",
				table: "author",
				column: "name",
				unique: true);

			migrationBuilder.CreateIndex(
				name: "IX_comment_author_id",
				schema: "blog",
				table: "comment",
				column: "author_id");

			migrationBuilder.CreateIndex(
				name: "IX_comment_post_id",
				schema: "blog",
				table: "comment",
				column: "post_id");

			migrationBuilder.CreateIndex(
				name: "IX_post_author_id",
				schema: "blog",
				table: "post",
				column: "author_id");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "comment",
				schema: "blog");

			migrationBuilder.DropTable(
				name: "post",
				schema: "blog");

			migrationBuilder.DropTable(
				name: "author",
				schema: "blog");
		}
	}
}
