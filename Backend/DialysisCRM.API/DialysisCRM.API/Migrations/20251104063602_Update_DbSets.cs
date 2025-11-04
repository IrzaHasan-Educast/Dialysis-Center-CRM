using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DialysisCRM.API.Migrations
{
    /// <inheritdoc />
    public partial class Update_DbSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurancs_Patients_PatientId",
                table: "Insurancs");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReferrals_Patients_PatientId",
                table: "PatientReferrals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientReferrals",
                table: "PatientReferrals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insurancs",
                table: "Insurancs");

            migrationBuilder.RenameTable(
                name: "PatientReferrals",
                newName: "Referrals");

            migrationBuilder.RenameTable(
                name: "Insurancs",
                newName: "Insurances");

            migrationBuilder.RenameIndex(
                name: "IX_PatientReferrals_PatientId",
                table: "Referrals",
                newName: "IX_Referrals_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Insurancs_PatientId",
                table: "Insurances",
                newName: "IX_Insurances_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Referrals",
                table: "Referrals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insurances",
                table: "Insurances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_Patients_PatientId",
                table: "Insurances",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Referrals_Patients_PatientId",
                table: "Referrals",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_Patients_PatientId",
                table: "Insurances");

            migrationBuilder.DropForeignKey(
                name: "FK_Referrals_Patients_PatientId",
                table: "Referrals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Referrals",
                table: "Referrals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insurances",
                table: "Insurances");

            migrationBuilder.RenameTable(
                name: "Referrals",
                newName: "PatientReferrals");

            migrationBuilder.RenameTable(
                name: "Insurances",
                newName: "Insurancs");

            migrationBuilder.RenameIndex(
                name: "IX_Referrals_PatientId",
                table: "PatientReferrals",
                newName: "IX_PatientReferrals_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Insurances_PatientId",
                table: "Insurancs",
                newName: "IX_Insurancs_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientReferrals",
                table: "PatientReferrals",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insurancs",
                table: "Insurancs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurancs_Patients_PatientId",
                table: "Insurancs",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReferrals_Patients_PatientId",
                table: "PatientReferrals",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
