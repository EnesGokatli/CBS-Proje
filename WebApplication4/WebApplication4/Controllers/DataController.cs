using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication4.DB;

namespace WebApplication4.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly StoreContext _context;

        public DataController(StoreContext context)
        {
            _context = context;
        }

        [HttpPost("save-data")]  //Post edemedim hata çevirdi 
        public IActionResult SaveData([FromBody] string json)
        {
            try
            {
                // Gelen JSON veriyi Drawing nesnesine dönüştür
                Drawing drawing = JsonConvert.DeserializeObject<Drawing>(json);

                // Drawing nesnesini veritabanına ekle
                _context.Drawings.Add(drawing);
                _context.SaveChanges();

                return Ok("Veri başarıyla eklendi");
            }
            catch (Exception ex)
            {
                return BadRequest("Veri eklenirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
