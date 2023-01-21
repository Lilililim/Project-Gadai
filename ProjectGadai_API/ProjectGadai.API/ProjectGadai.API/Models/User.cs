using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace ProjectGadai.API.Models
{
    public class User
    {
        [Key]
        public Guid user_id { get; set; }
        public string nama_user { get; set; }
        public string nomor_hp { get; set; }
        public string keterangan { get; set; }
        public int maks_transaksi { get; set; }
        public DateTime tanggal_masuk { get; set; }
    }
}
