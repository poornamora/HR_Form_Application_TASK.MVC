using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First_Sample_Project.Migrations
{
    /// <inheritdoc />
    public partial class GetUsers_Storeprocedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        { 
            string SP_Getusers = @"CREATE PROCEDURE [dbo].[GetAllUsers]

            AS BEGIN
               SELECT Id, Name, Email, Password from [dbo].[UserRegistration];
            END
            ";

            migrationBuilder.Sql(SP_Getusers);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string SP_Getusers = @"DROP PROCEDURE [dbo].[GetAllUsers]";

            migrationBuilder.Sql(SP_Getusers);
        }
    }
}
