public class Inventory
{
    public int id_inventory { get; set; } // Primary Key
    public string nama_barang { get; set; }
    public decimal harga_barang { get; set; }
    public DateTime tanggal_pengadaan { get; set; }
    public int jumlah { get; set; }
    public string kategori { get; set; }
    public string manufakturer { get; set; }
}
