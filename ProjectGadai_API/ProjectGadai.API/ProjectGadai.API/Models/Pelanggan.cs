using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ProjectGadai.API.Models
{
    public class Pelanggan
    {
        [Key]
        public string id_pelanggan { get; set; }
        public string nama_pelanggan { get; set; }
        public string nomor_ktp { get; set; }
        public string nomor_hp { get; set; }
        public string kelamain { get; set; }
        public string jenis_usaha { get; set; }
        public int maks_transaksi { get; set; }
    }
}
