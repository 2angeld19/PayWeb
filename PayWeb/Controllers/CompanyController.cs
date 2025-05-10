using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace PayWeb.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompositeViewEngine _viewEngine;

        public CompanyController(ICompositeViewEngine viewEngine)
        {
            _viewEngine = viewEngine;
        }

        #region GET Methods - Company
        public IActionResult CreateCompany()
        {
            try
            {
                return PartialView("_CreateCompanyForm");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }
        #endregion

        #region POST Methods - Company
        [HttpPost]
        public IActionResult SaveCompany(CompanyViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos de la compañía
            return Json(new { success = true });
        }
        #endregion

        #region View Models - Company
        public class CompanyViewModel
        {
            public int? CompanyNumber { get; set; }
            public string? ShortName { get; set; }
            public string? BankNumber { get; set; }
            public string? InterfaceCode { get; set; }
            public string? EmployerName { get; set; }
            public string? WorkplaceName { get; set; }
            public string? LegalRepresentative { get; set; }
            public string? FiscalAddress { get; set; }
            public IFormFile? Logo { get; set; }
            public string? LogoPath { get; set; }
            public string? EconomicActivity { get; set; }
            public string? License { get; set; }
            public int? CorrelationNumber { get; set; }
            public string? EmployerNumber { get; set; }
            public string? LegalId { get; set; }
            public string? Dv { get; set; }
            public string? NaturalId { get; set; }
            public string? Phone { get; set; }
            public string? Fax { get; set; }
            public int? LastThirteenthMonthPaid { get; set; }
            public DateTime? LastPeriodPaid { get; set; }
            public int? LastClosedYear { get; set; }
            public DateTime? LastPaymentToCreditors { get; set; }
            public string? DataPath { get; set; }
            public bool? IsConstructionCompany { get; set; }
            public bool? IsAgricultureCompany { get; set; }
            public bool? CostBreakdownByActivities { get; set; }
            public bool? IsSemVisa { get; set; }
        }
        #endregion
    }
}