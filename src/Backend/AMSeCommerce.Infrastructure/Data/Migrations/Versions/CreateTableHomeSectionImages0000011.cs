using FluentMigrator;

namespace AMSeCommerce.Infrastructure.Data.Migrations.Versions;

[Migration(MigrationVersionNumber.CreateHomeSectionImagesTable, "Create table HomeSectionImages")]
public class CreateTableHomeSectionImages0000011 : BaseMigration
{
    public override void Up()
    {
        CreateTable("HomeSection_Images")
            .WithColumn("HomeSectionId").AsInt64().NotNullable()
            .ForeignKey("FK_HomeSection_Images_HomeSection", "HomeSection", "Id")
            .WithColumn("ImageUrl").AsString().NotNullable();
    }
}