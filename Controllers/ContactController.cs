using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Data;
using RestApi.Models;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // url : localhost/api/Contact
    public class ContactController : ControllerBase
    {
        // koneksi ke database
        private readonly ContactContext _db;
        public ContactController(ContactContext a)
        {
            _db = a;
        }

        // tes API 
        //     [HttpGet]
        //     public string Index()
        //     {
        //         return "API Contact Berhasil";
        //     }

        // get All data with API Endpoints
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _db.Contacts.ToListAsync());
        }

        // API untuk POST
        [HttpPost]
        public async Task<IActionResult> Store(Contact request)
        {
            var contact = new Contact()
            {
                Fullname = request.Fullname,
                Email = request.Email,
                Phone = request.Phone,
                Address = request.Address
            };
            await _db.Contacts.AddAsync(contact);
            await _db.SaveChangesAsync();
            return Ok(contact);
        }

        // Endpoints untuk update 
        [HttpPut]
        // localhost/api/Contact/1
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, Contact request)
        {
            // kita cari id yg ingin diupdate
            var contact = await _db.Contacts.FindAsync(id);
            // logika jika ada id dan data exits (Update)
            if (contact != null)
            {
                contact.Fullname = request.Fullname;
                contact.Email = request.Email;
                contact.Phone = request.Phone;
                contact.Address = request.Address;
                // query ke database
                await _db.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }

        // Enpoint untuk Delete contact
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // cara data yang ingin dihapus berdasarkan id
            var contact = await _db.Contacts.FindAsync(id);
            if (contact != null)
            {
                _db.Remove(contact);
                await _db.SaveChangesAsync();
                return Ok(contact);
            }
            return NotFound();
        }

    }
}