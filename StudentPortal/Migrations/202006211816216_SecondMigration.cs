namespace StudentPortal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CourseGrades", new[] { "Student_Id" });
            DropColumn("dbo.CourseGrades", "UserId");
            RenameColumn(table: "dbo.CourseGrades", name: "Student_Id", newName: "UserId");
            AlterColumn("dbo.CourseGrades", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CourseGrades", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CourseGrades", new[] { "UserId" });
            AlterColumn("dbo.CourseGrades", "UserId", c => c.String());
            RenameColumn(table: "dbo.CourseGrades", name: "UserId", newName: "Student_Id");
            AddColumn("dbo.CourseGrades", "UserId", c => c.String());
            CreateIndex("dbo.CourseGrades", "Student_Id");
        }
    }
}
