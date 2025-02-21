using CsvService.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CsvService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private readonly CsvManager _csvManager;

        public CsvController(CsvManager csvManager)
        {
            _csvManager = csvManager;
        }

        [HttpPost("upload-members")]
        public async Task<IActionResult> UploadMembers([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("No file uploaded.");

            var result = await _csvManager.ProcessMemberCsvAsync(file);
            return Ok(new { Success = result });
        }

        [HttpPost("upload-inventory")]
        public async Task<IActionResult> UploadInventory([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("No file uploaded.");

            var result = await _csvManager.ProcessInventoryCsvAsync(file);
            return Ok(new { Success = result });
        }
    }
}
