using FluentMigrator;

namespace AMSeCommerce.Infrastructure.Data.Migrations.Versions;

[Migration(MigrationVersionNumber.CreateTableOrders, "Create table Orders")]
public class CreateTableOrders0000005 : BaseMigration
{
    public override void Up()
    {
        CreateTable("Orders")
            .WithColumn("UserId").AsInt64().NotNullable()
            .ForeignKey("FK_Orders_Users", "Customers", "Id")
            .WithColumn("OrderDate").AsDateTime().NotNullable()
            .WithColumn("TotalAmount").AsDecimal(18, 2).NotNullable()
            .WithColumn("Status").AsString().NotNullable() // Consider adding default value
            .WithColumn("ShippingAddress").AsString().NotNullable()
            .WithColumn("BillingAddress").AsString().Nullable();
    }
}