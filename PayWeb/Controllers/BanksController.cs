using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace PayWeb.Controllers
{
    public class BanksController : Controller
    {
        private readonly ICompositeViewEngine _viewEngine;

        public BanksController(ICompositeViewEngine viewEngine)
        {
            _viewEngine = viewEngine;
        }

        #region GET Methods - Banks
        public IActionResult Banks()
        {
            try
            {
                return PartialView("_BanksForm");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        public IActionResult PaymentMethods()
        {
            try
            {
                return PartialView("Employees/_PaymentMethodsForm");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        public IActionResult PayFrequency()
        {
            try
            {
                return PartialView("_PayFrequencyForm");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        public IActionResult FileFormats()
        {
            try
            {
                return PartialView("_FileFormatsForm");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }
        #endregion

        #region POST Methods - Banks
        [HttpPost]
        public IActionResult SaveBanks(BankViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SavePaymentMethods(PaymentMethodViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SavePayFrequency(PayFrequencyViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveFileFormats(FileFormatViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }
        #endregion

        #region View Models - Banks
        public class BankViewModel
        {
            public string? BankName { get; set; }
            public string? BankCode { get; set; }
            public string? AccountNumber { get; set; }
        }

        public class PaymentMethodViewModel
        {
            public string? MethodName { get; set; }
            public string? MethodCode { get; set; }
            public bool? IsElectronic { get; set; }
        }

        public class PayFrequencyViewModel
        {
            public string? FrequencyName { get; set; }
            public string? FrequencyCode { get; set; }
            public int? DaysInterval { get; set; }
        }

        public class FileFormatViewModel
        {
            public string? FormatName { get; set; }
            public string? FormatCode { get; set; }
            public string? FileExtension { get; set; }
        }
        #endregion
    }
}