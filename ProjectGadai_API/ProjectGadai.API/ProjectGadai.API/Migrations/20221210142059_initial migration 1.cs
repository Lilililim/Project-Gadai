using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectGadai.API.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tanggal_masuk",
                table: "Users",
                newName: "tanggal_masuk");

            migrationBuilder.RenameColumn(
                name: "Maks_transaksi",
                table: "Users",
                newName: "maks_transaksi");

            migrationBuilder.RenameColumn(
                name: "Keterangan",
                table: "Users",
                newName: "keterangan");

            migrationBuilder.RenameColumn(
                name: "No_hp",
                table: "Users",
                newName: "nomor_hp");

            migrationBuilder.RenameColumn(
                name: "Nama",
                table: "Users",
                newName: "nama_user");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tanggal_masuk",
                table: "Users",
                newName: "Tanggal_masuk");

            migrationBuilder.RenameColumn(
                name: "maks_transaksi",
                table: "Users",
                newName: "Maks_transaksi");

            migrationBuilder.RenameColumn(
                name: "keterangan",
                table: "Users",
                newName: "Keterangan");

            migrationBuilder.RenameColumn(
                name: "nomor_hp",
                table: "Users",
                newName: "No_hp");

            migrationBuilder.RenameColumn(
                name: "nama_user",
                table: "Users",
                newName: "Nama");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Users",
                newName: "Id");
        }
    }
}
