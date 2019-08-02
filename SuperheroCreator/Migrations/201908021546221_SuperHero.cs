namespace SuperheroCreator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuperHero : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Superheroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AlterEgo = c.String(),
                        PrimaryAbility = c.String(),
                        SecondaryAbility = c.String(),
                        Catchphrase = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Superheroes");
        }
    }
}
