using FluentMigrator;

namespace AMSeCommerce.Infrastructure.Data.Migrations.Versions;

[Migration(MigrationVersionNumber.CreateTableCategories, "Create table Category")]
public class CreateTableCategories0000002 : BaseMigration
{
    public override void Up()
    {
        CreateTable("Categories")
            .WithColumn("Description").AsString().Nullable()
            .WithColumn("ParentCategoryId").AsInt64().Nullable()
            .ForeignKey("FK_Categories_ParentCategory", "Categories", "Id");
    }
}