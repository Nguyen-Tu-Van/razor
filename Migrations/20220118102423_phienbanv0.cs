using System;
using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using RazorEntity.Models;

#nullable disable

namespace RazorEntity.Migrations
{
    public partial class phienbanv0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            Randomizer.Seed = new Random(8675309);

            var fakeArticle = new Faker<Article>();

            fakeArticle.RuleFor(x => x.Title, x => x.Lorem.Sentence(5, 10));
            fakeArticle.RuleFor(x => x.CreatedDate, x => x.Date.Between(new DateTime(2020, 1, 1), new DateTime(2021, 1, 1)));
            fakeArticle.RuleFor(x => x.Content, x => x.Lorem.Sentence(10, 18));

            for(int i = 0; i < 100; i++)
            {
                Article article = fakeArticle.Generate();

                migrationBuilder.InsertData(
                    table: "Article",
                    columns: new[] { "Title", "CreatedDate", "Content" },
                    values: new object[]
                    {
                    article.Title,
                    article.CreatedDate,
                    article.Content
                    }
                    );
            }    
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
