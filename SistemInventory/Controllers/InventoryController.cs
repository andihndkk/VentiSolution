using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemInventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        readonly DBkonteks _konteks;
        public InventoryController(DBkonteks konteks)
        {
            _konteks = konteks;
        }

        // GET: api/<InventoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> Get()
        {
            var inventories = await _konteks.Inventories
                .Include(i => i.kategori)
                .ToListAsync();
            return Ok(inventories);
            
        }

        [HttpGet("categoriesnames")]
        public async Task<IActionResult> GetCategoriesAndNames()
        {
            var categoriesAndNames = await _konteks.Inventories
                .Select(i => new
                {
                    i.id_kategori,
                    i.nama_barang
                    
                })
                .ToListAsync();

            return Ok(categoriesAndNames);
        }

        // GET api/<InventoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inventory = await _konteks.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        // POST api/<InventoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Inventory newInventory)
        {
            if (newInventory == null)
            {
                return BadRequest("Invalid data.");
            }

            _konteks.Inventories.Add(newInventory);
            await _konteks.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = newInventory.id_inventory }, newInventory);
        }

        // PUT api/<InventoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Inventory updatedInventory)
        {
            if (updatedInventory == null || id != updatedInventory.id_inventory)
            {
                return BadRequest("Invalid data.");
            }

            var existingInventory = await _konteks.Inventories.FindAsync(id);

            if (existingInventory == null)
            {
                return NotFound();
            }

            existingInventory.nama_barang = updatedInventory.nama_barang;
            existingInventory.harga_barang = updatedInventory.harga_barang;
            existingInventory.tanggal_pengadaan = updatedInventory.tanggal_pengadaan;
            existingInventory.jumlah = updatedInventory.jumlah;
            existingInventory.id_kategori = updatedInventory.id_kategori;
            existingInventory.manufakturer = updatedInventory.manufakturer;

            _konteks.Inventories.Update(existingInventory);
            await _konteks.SaveChangesAsync();

            return NoContent(); // Mengembalikan status 204 No Content
        }

        // DELETE api/<InventoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var inventory = await _konteks.Inventories.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            _konteks.Inventories.Remove(inventory);
            await _konteks.SaveChangesAsync();

            return NoContent(); // Mengembalikan status 204 No Content
        }
    }
}
