using Microsoft.AspNetCore.Mvc;
using FanCode_BE.interfaces;
using FanCode_BE.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FanCode_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ItodoService _todoService;
        private readonly ILogger _logger;
        public TodoController(ILogger<TodoController> logger, ItodoService itodo)
        {
            _todoService = itodo;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("request logged");
            try
            {

                return StatusCode(200, await _todoService.GetTodos());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "something went wrong");
            }
        }

    }
}
