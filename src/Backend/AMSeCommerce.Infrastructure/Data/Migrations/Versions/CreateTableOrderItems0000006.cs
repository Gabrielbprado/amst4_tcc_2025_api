using FluentMigrator;

namespace AMSeCommerce.Infrastructure.Data.Migrations.Versions;

[Migration(MigrationVersionNumber.CreateTableOrdersItems, "Create table OrdersItems")]
public class CreateTableOrderItems0000006 : BaseMigration
{
    public override void Up()
    {
        CreateTable("OrderItems")
            .WithColumn("OrderId").AsInt64().NotNullable()
            .ForeignKey("FK_OrderItems_Orders", "Orders", "Id")
            .WithColumn("ProductId").AsInt64().NotNullable()
            .ForeignKey("FK_OrderItems_Products", "Products", "Id")
            .WithColumn("Quantity").AsInt32().NotNullable()
            .WithColumn("UnitPrice").AsDecimal(18, 2).NotNullable()
            .WithColumn("TotalPrice").AsDecimal(18, 2).NotNullable();
    }
}