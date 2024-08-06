using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SistemInventory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KategoriController : ControllerBase
    {
        private readonly DBkonteks _konteks;

        public KategoriController(DBkonteks konteks)
        {
            _konteks = konteks;
        }

        // GET: api/Kategori
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategori>>> GetAllKategori()
        {
            return await _konteks.Kategoris.ToListAsync();
        }

        // GET: api/Kategori/kategori-nama-barang
        [HttpGet("kategori-nama-barang")]
        public async Task<ActionResult<IEnumerable<object>>> GetKategoriNamaBarang()
        {
            var result = await _konteks.Kategoris
                .Select(k => new { k.nama_kategori, k.deskripsi })
                .ToListAsync();

            return Ok(result);
        }

        // GET: api/Kategori/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kategori>> GetKategoriById(int id)
        {
            var kategori = await _konteks.Kategoris.FindAsync(id);

            if (kategori == null)
            {
                return NotFound();
            }

            return kategori;
        }

        // POST: api/Kategori
        [HttpPost]
        public async Task<ActionResult<Kategori>> CreateKategori(Kategori kategori)
        {
            _konteks.Kategoris.Add(kategori);
            await _konteks.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKategoriById), new { id = kategori.id_kategori }, kategori);
        }

        // PUT: api/Kategori/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKategori(int id, Kategori kategori)
        {
            if (id != kategori.id_kategori)
            {
                return BadRequest();
            }

            _konteks.Entry(kategori).State = EntityState.Modified;

            try
            {
                await _konteks.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategoriExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Kategori/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategori(int id)
        {
            var kategori = await _konteks.Kategoris.FindAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }

            _konteks.Kategoris.Remove(kategori);
            await _konteks.SaveChangesAsync();

            return NoContent();
        }

        private bool KategoriExists(int id)
        {
            return _konteks.Kategoris.Any(e => e.id_kategori == id);
        }
    }
}
