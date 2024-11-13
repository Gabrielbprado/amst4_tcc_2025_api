using FluentMigrator;

namespace AMSeCommerce.Infrastructure.Data.Migrations.Versions;

[Migration(MigrationVersionNumber.CreateTableShoppingCart, "Create table ShoppingCart")]
public class CreateTableShoppingCart0000007 : BaseMigration
{
    public override void Up()
    {
        CreateTable("ShoppingCart")
            .WithColumn("UserId").AsGuid().NotNullable()
            .ForeignKey("FK_Shopping_Customers", "Customers", "Id")
            .WithColumn("Quantity").AsInt32().NotNullable();
    }
}