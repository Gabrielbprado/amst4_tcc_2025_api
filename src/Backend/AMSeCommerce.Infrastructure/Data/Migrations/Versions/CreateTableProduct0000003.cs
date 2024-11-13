using FluentMigrator;

namespace AMSeCommerce.Infrastructure.Data.Migrations.Versions;

[Migration(MigrationVersionNumber.CreateTableProduct, "Create table Product")]
public class CreateTableProduct0000003 : BaseMigration
{
    public override void Up()
    {
        CreateTable("Products")
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Description").AsString().Nullable()
            .WithColumn("Price").AsDecimal(18, 2).NotNullable()
            .WithColumn("StockQuantity").AsInt32().NotNullable()
            .WithColumn("CategoryId").AsInt64().NotNullable().ForeignKey("FK_Products_Categories", "Categories", "Id")
            .WithColumn("ImageIdentifier").AsString().NotNullable()
            .WithColumn("UserIdentifier").AsInt64().NotNullable().ForeignKey("FK_Products_Users", "Customers", "Id");
    }
}
