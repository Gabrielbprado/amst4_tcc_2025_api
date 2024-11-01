using FluentMigrator;

namespace AMSeCommerce.Infrastructure.Data.Migrations.Versions;

[Migration(MigrationVersionNumber.CreateTableProductImage, "Create table ProductImages")]
public class CreateTableProductImages0000004 : BaseMigration
{
    public override void Up()
    {
        CreateTable("ProductImages")
            .WithColumn("ProductId").AsInt64().NotNullable()
            .ForeignKey("FK_ProductImages_Products", "Products", "Id")
            .WithColumn("ImageUrl").AsString().NotNullable()
            .WithColumn("IsMainImage").AsBoolean().NotNullable().WithDefaultValue(false);
    }
}