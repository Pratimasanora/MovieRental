namespace MovieRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataInUsersTables : DbMigration
    {
        public override void Up()
        {
            Sql(@" INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'16628d9c-8ed3-499e-b8a4-91bf5dd5a0f2', N'Pratima@gmail.com', 0, N'AETLQupV3pUqpYrOkd9OK4qO55kxcCj9S8CfwFo8Z5xgOd5hwRaP6qL1dYJEPjqq9w==', N'9580b644-8cef-4a3a-a039-f0563e989ccd', NULL, 0, 0, NULL, 1, 0, N'Pratima@gmail.com') ");
        }
        
        public override void Down()
        {
        }
    }
}
