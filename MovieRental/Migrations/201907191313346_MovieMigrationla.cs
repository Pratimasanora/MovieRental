namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieMigrationla : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Genres");
        }
        
        public override void Down()
        {
            
        }
    }
}
