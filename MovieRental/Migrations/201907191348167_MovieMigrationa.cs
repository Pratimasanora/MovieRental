namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieMigrationa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MovieName = c.String(),
                    NoInStocks = c.Int(nullable: false),
                    ReleaseDate = c.DateTime(nullable: false),
                    AddedDate = c.DateTime(nullable: false),
                    GenreId = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId)
                .Index(t => t.GenreId);

            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);


        }
        
        public override void Down()
        {
            
        }
    }
}
