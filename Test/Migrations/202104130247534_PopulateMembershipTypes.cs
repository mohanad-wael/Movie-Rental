namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Name,SingUpFee,DurationMonths,DiscountRate) VALUES ('Pay As You Go',0,0,0)");
            Sql("INSERT INTO MembershipTypes (Name,SingUpFee,DurationMonths,DiscountRate) VALUES ('Monthly',30,1,10)");
            Sql("INSERT INTO MembershipTypes (Name,SingUpFee,DurationMonths,DiscountRate) VALUES ('Three Monthes',90,3,15)");
            Sql("INSERT INTO MembershipTypes (Name,SingUpFee,DurationMonths,DiscountRate) VALUES ('Annualy',300,12,20)");
        }
        
        public override void Down()
        {
        }
    }
}
