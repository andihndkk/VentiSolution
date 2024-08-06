public class Kategori
{
    public int id_kategori { get; set; } // Primary Key
    public string nama_kategori { get; set; }
    public string deskripsi { get; set; }
    public string note { get; set; }
    public string created_by { get; set; }
    public DateTimeOffset? created_at { get; set; }
    public string? last_modified_by { get; set; }
    public DateTimeOffset? last_modified_at { get; set; }
    public bool is_deleted { get; set; }
}
