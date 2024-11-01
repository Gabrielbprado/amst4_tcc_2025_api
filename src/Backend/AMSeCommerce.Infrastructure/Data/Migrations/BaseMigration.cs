using FluentMigrator;
using FluentMigrator.Builders.Create.Table;

namespace AMSeCommerce.Infrastructure.Data.Migrations;

public abstract class BaseMigration : ForwardOnlyMigration
{
    protected ICreateTableColumnOptionOrWithColumnSyntax CreateTable(string tableName)
    {
        return Create.Table(tableName).WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("CreatedAt").AsDate().NotNullable()
            .WithColumn("IsActive").AsBoolean().NotNullable();
    }
}