using FluentMigrator;

namespace AMSeCommerce.Infrastructure.Data.Migrations.Versions;

[Migration(MigrationVersionNumber.CreateTableParentCategory, "Create table Orders")]
public class CreateTableParentCategory0000010 : BaseMigration
{
    public override void Up()
    {
        CreateTable("ParentCategory")
            .WithColumn("Description").AsString().Nullable()
            .WithColumn("CategoryId").AsInt64().NotNullable().ForeignKey("FK_ParentCategory_Categories", "Categories", "Id");
    }
}