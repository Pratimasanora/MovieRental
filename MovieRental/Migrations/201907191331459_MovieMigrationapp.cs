namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieMigrationapp : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Genres");
            DropTable("dbo.Movies");
        }
        
        public override void Down()
        {
            
        }
    }
}
