using FluentMigrator;

namespace AMSeCommerce.Infrastructure.Data.Migrations.Versions;

[Migration(MigrationVersionNumber.CreateTableAddress, "Create table Adress")]
public class CreateTableAddress0000008 : BaseMigration
{
    public override void Up()
    {
        CreateTable("Address")
            .WithColumn("StreetName").AsString(100).NotNullable()
            .WithColumn("StreetNumber").AsInt32().NotNullable()
            .WithColumn("ZipCode").AsString(8).NotNullable()
            .WithColumn("City").AsString(100).NotNullable()
            .WithColumn("State").AsString(100).NotNullable()
            .WithColumn("Neighborhood").AsString(100).NotNullable()
            .WithColumn("UserId").AsInt64().NotNullable()
            .ForeignKey("FK_Address_Users", "Customers", "Id");
    }
}
