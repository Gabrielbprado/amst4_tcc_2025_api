using FluentMigrator;

namespace AMSeCommerce.Infrastructure.Data.Migrations.Versions;

[Migration(MigrationVersionNumber.CreateUserTable, "Create table Customers")]
public class CreateTableCustomers0000001 : BaseMigration
{
    public override void Up()
    {
        CreateTable("Customers")
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("Password").AsString().NotNullable()
            .WithColumn("UserIdentifier").AsGuid().NotNullable() 
            .WithColumn("Email").AsString().NotNullable()
            .WithColumn("Cpf").AsString().NotNullable(); 
    }

}