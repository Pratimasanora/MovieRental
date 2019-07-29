namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieMigrationappdata : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            //AddColumn("dbo.Genres", "Name", c => c.String()).ForeignKey("dbo.Genres", t => t.Genre_Id)
            //    .Index(t => t.Genre_Id);
        }
        
        public override void Down()
        {
           
        }
    }
}
