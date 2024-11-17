using FluentMigrator;

namespace AMSeCommerce.Infrastructure.Data.Migrations.Versions;

[Migration(MigrationVersionNumber.CreateTableOrders, "Create table Orders")]
public class CreateTableOrders0000005 : BaseMigration
{
    public override void Up()
    {
        CreateTable("Orders")
            .WithColumn("UserId").AsGuid().NotNullable()
            .ForeignKey("FK_Orders_Customers", "Customers", "Id")
            .WithColumn("OrderDate").AsDateTime().NotNullable()
            .WithColumn("TransactionAmount").AsDecimal(18, 2).NotNullable()
            .WithColumn("Status").AsString().NotNullable()
            .WithColumn("ShippingAddress").AsString().NotNullable()
            .WithColumn("BillingAddress").AsString().Nullable()
            .WithColumn("Description").AsString().NotNullable()
            .WithColumn("PaymentMethodId").AsInt64().NotNullable()
            .WithColumn("ProductId").AsInt64().NotNullable()
            .ForeignKey("FK_Orders_Products", "Products", "Id");

    }
}