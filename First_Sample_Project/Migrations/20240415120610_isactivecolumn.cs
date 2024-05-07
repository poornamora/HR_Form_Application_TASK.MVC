using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First_Sample_Project.Migrations
{
    /// <inheritdoc />
    public partial class isactivecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string SP_Getusers = @"CREATE PROCEDURE [dbo].[SP_GetUsersList]

            AS BEGIN
               SELECT Id, Name, Email, Password,IsActive from [dbo].[UserRegistration] where IsActive=1;
            END
            ";

            migrationBuilder.Sql(SP_Getusers);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string SP_Getusers = @"DROP PROCEDURE [dbo].[SP_GetUsersList]";
            migrationBuilder.Sql(SP_Getusers);
        }
    }
}
