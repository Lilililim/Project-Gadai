using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectGadai.API.Migrations
{
    /// <inheritdoc />
    public partial class pelangganmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pelanggans",
                columns: table => new
                {
                    idpelanggan = table.Column<string>(name: "id_pelanggan", type: "nvarchar(450)", nullable: false),
                    namapelanggan = table.Column<string>(name: "nama_pelanggan", type: "nvarchar(max)", nullable: true),
                    nomorktp = table.Column<string>(name: "nomor_ktp", type: "nvarchar(max)", nullable: true),
                    nomorhp = table.Column<string>(name: "nomor_hp", type: "nvarchar(max)", nullable: true),
                    kelamain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    jenisusaha = table.Column<string>(name: "jenis_usaha", type: "nvarchar(max)", nullable: true),
                    makstransaksi = table.Column<int>(name: "maks_transaksi", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelanggans", x => x.idpelanggan);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pelanggans");
        }
    }
}
