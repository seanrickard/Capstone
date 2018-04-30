using Microsoft.EntityFrameworkCore.Migrations;

namespace PurchaseReq.DAL.EF.Migrations
{
    public partial class attachmentbyte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_EmployeeId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "AttachmentPath",
                schema: "Order",
                table: "Attachments");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                schema: "Order",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "File",
                schema: "Order",
                table: "Attachments",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_EmployeeId",
                schema: "Order",
                table: "Orders",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_EmployeeId",
                schema: "Order",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "File",
                schema: "Order",
                table: "Attachments");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeId",
                schema: "Order",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "AttachmentPath",
                schema: "Order",
                table: "Attachments",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_EmployeeId",
                schema: "Order",
                table: "Orders",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
