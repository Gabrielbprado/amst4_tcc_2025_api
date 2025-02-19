using FluentMigrator;


namespace AMSeCommerce.Infrastructure.Data.Migrations.Versions;

[Migration(MigrationVersionNumber.CreateHomeSectionTable, "Create table HomeSection")]
public class CreateTableHomeSection0000009 : BaseMigration
{
    public override void Up()
    {
        CreateTable("HomeSection")
            .WithColumn("Title").AsString().NotNullable()
            .WithColumn("SectionType").AsString().NotNullable()
            .WithColumn("OrderIndex").AsInt32().NotNullable()
            .WithColumn("Filter").AsString().Nullable()
            .WithColumn("CategoryId").AsInt64().NotNullable().ForeignKey("FK_HomeSection_Categories", "Categories", "Id");
    }
}