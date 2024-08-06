using FluentMigrator;

namespace CrudProductsFluentMigrator.Migrations;

[Migration(202408061715, "Create products table.")]
public class M202408061715 : Migration
{
    public override void Down()
    {
        Delete.Table("Products"); 
    }

    public override void Up()
    {
        Create.Table("Products")
         .WithColumn("Id").AsInt64().PrimaryKey().Identity()
         .WithColumn("Name").AsString(100).NotNullable()
         .WithColumn("Category").AsString(100).NotNullable()
         .WithColumn("Price").AsDecimal(10, 2).NotNullable(); 
    }
}
