namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Id,Name) VALUES (1,'Comedy')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (2,'Drama')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (3,'Action')");
            Sql("INSERT INTO Genres(Id,Name) VALUES (4,'Family')");
        }
        
        public override void Down()
        {
        }
    }
}
