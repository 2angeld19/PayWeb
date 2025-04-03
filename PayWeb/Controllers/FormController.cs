using Microsoft.AspNetCore.Mvc;

namespace PayWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : Controller
    {
        [HttpPost("setCurrentForm")]
        public IActionResult SetCurrentForm([FromBody] FormData formData)
        {
            if (formData == null)
            {
                return BadRequest("Los datos del formulario son nulos");
            }

            // Usar cadena vacía en lugar de nulo
            string currentForm = formData.CurrentForm ?? "";
            string modalTitle = formData.ModalTitle ?? "";

            // Almacenar en la sesión
            HttpContext.Session.SetString("CurrentForm", currentForm);
            HttpContext.Session.SetString("ModalTitle", modalTitle);

            // Para depuración
            Console.WriteLine($"Configurando CurrentForm: {currentForm}, ModalTitle: {modalTitle}");

            return Ok();
        }
    }

    public class FormData
    {
        public string? CurrentForm { get; set; }
        public string? ModalTitle { get; set; }
    }
}
