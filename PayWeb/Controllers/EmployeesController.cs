using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace PayWeb.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ICompositeViewEngine _viewEngine;

        public EmployeesController(ICompositeViewEngine viewEngine)
        {
            _viewEngine = viewEngine;
        }

        #region GET Methods - Employees
        public IActionResult EmployeeData()
        {
            try
            {
                return PartialView("Employees/_EmployeeDataForm");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        public IActionResult EmployeeTypes()
        {
            try
            {
                var viewEngineResult = _viewEngine.FindView(ControllerContext, "_EmployeeTypesForm", false);
                if (viewEngineResult.Success)
                {
                    return PartialView("_EmployeeTypesForm");
                }
                return Content("Error: Vista _EmployeeTypesForm no encontrada.");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        public IActionResult ContractTypes()
        {
            try
            {
                return PartialView("_ContractTypesForm");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        public IActionResult SalaryTypes()
        {
            try
            {
                return PartialView("_SalaryTypesForm");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        public IActionResult Deductions()
        {
            try
            {
                return PartialView("_DeductionsForm");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        public IActionResult Bonuses()
        {
            try
            {
                return PartialView("_BonusesForm");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        public IActionResult EmployeeNotes()
        {
            try
            {
                return PartialView("Employees/_EmployeeNotes");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        public IActionResult GeneralEmployeeData()
        {
            try
            {
                return PartialView("Employees/_GeneralEmployeeData");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        public IActionResult IncomeConfig()
        {
            try
            {
                return PartialView("Employees/_IncomeConfig");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }

        public IActionResult DefaultIncome()
        {
            try
            {
                return PartialView("Employees/_DefaultIncome");
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message}");
            }
        }
        #endregion

        #region POST Methods - Employees
        [HttpPost]
        public IActionResult SaveEmployeeData(EmployeeViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos del empleado
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveEmployeeTypes(EmployeeTypeViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveContractTypes(ContractTypeViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveSalaryTypes(SalaryTypeViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveDeductions(DeductionViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveBonuses(BonusViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveEmployeeNotes(EmployeeNotesViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos de las observaciones
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveGeneralEmployeeData(GeneralEmployeeDataViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos generales de empleados
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveIncomeConfig(IncomeConfigViewModel model)
        {
            // Aquí iría tu lógica para guardar la configuración de ingresos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveDefaultIncome(DefaultIncomeViewModel model)
        {
            // Aquí iría tu lógica para guardar los ingresos predeterminados
            return Json(new { success = true });
        }
        #endregion

        #region View Models - Employees
        public class EmployeeViewModel
        {
            public string? EmployeeId { get; set; }
            public string? IdentificationNumber { get; set; }
            public string? IdentificationType { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? SecondLastName { get; set; }
            public DateTime? DateOfBirth { get; set; }
            public string? Gender { get; set; }
            public string? MaritalStatus { get; set; }
            public string? Nationality { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
            public string? Address { get; set; }
            public string? City { get; set; }
            public string? State { get; set; }
            public string? PostalCode { get; set; }
            public string? Position { get; set; }
            public string? Department { get; set; }
            public DateTime? HireDate { get; set; }
            public string? EmployeeType { get; set; }
            public string? Supervisor { get; set; }
            public bool? IsActive { get; set; } = true;
        }

        public class EmployeeTypeViewModel
        {
            public string? TypeName { get; set; }
            public string? TypeCode { get; set; }
            public bool? IsActive { get; set; }
        }

        public class ContractTypeViewModel
        {
            public string? ContractName { get; set; }
            public string? ContractCode { get; set; }
            public int? DurationMonths { get; set; }
        }

        public class SalaryTypeViewModel
        {
            public string? SalaryName { get; set; }
            public string? SalaryCode { get; set; }
            public string? CalculationMethod { get; set; }
        }

        public class DeductionViewModel
        {
            public string? DeductionName { get; set; }
            public string? DeductionCode { get; set; }
            public decimal? Amount { get; set; }
            public bool? IsPercentage { get; set; }
        }

        public class BonusViewModel
        {
            public string? BonusName { get; set; }
            public string? BonusCode { get; set; }
            public decimal? Amount { get; set; }
            public bool? IsPercentage { get; set; }
        }

        public class EmployeeNotesViewModel
        {
            public string? EmployeeId { get; set; }
            public DateTime? NoteDate { get; set; } = DateTime.Now;
            public string? NoteContent { get; set; }
            public string? NoteCategory { get; set; }
            public string? NotePriority { get; set; }
            public IFormFileCollection? Attachments { get; set; }
        }

        public class GeneralEmployeeDataViewModel
        {
            public string? CompanyId { get; set; }
            public bool? UseDefaultWorkSchedule { get; set; } = true;
            public TimeSpan? DefaultStartTime { get; set; } = new TimeSpan(8, 0, 0);
            public TimeSpan? DefaultEndTime { get; set; } = new TimeSpan(17, 0, 0);
            public int? DefaultBreakMinutes { get; set; } = 60;
            public decimal? DefaultBaseSalary { get; set; } = 0;
            public string? DefaultTaxCalculationMethod { get; set; } = "average";
            public bool? AutomaticallyCalculateOvertime { get; set; } = true;
            public bool? TrackAttendance { get; set; } = true;
            public string? DefaultEmploymentType { get; set; } = "permanent";
            public int? DefaultProbationPeriodDays { get; set; } = 90;
            public bool? AllowBackdatedTransactions { get; set; } = false;
            public bool? RequireDocumentationForLeave { get; set; } = true;
            public decimal? DefaultVacationDaysPerYear { get; set; } = 15;
            public decimal? DefaultSickDaysPerYear { get; set; } = 10;
        }

        public class IncomeConfigViewModel
        {
            public string? CompanyId { get; set; }
            public decimal? RegularOvertimeRate { get; set; } = 1.25m;
            public decimal? HolidayOvertimeRate { get; set; } = 2.0m;
            public decimal? NightShiftPremium { get; set; } = 0.15m;
            public bool? IncludeBonusInSocialSecurity { get; set; } = true;
            public bool? IncludeOvertimeInThirteenthMonth { get; set; } = true;
            public bool? AutoCalculateIncomeWithholding { get; set; } = true;
            public string? IncomeTaxCalculationType { get; set; } = "monthly";
            public List<string>? TaxableBenefits { get; set; } = new List<string>();
            public List<string>? NonTaxableBenefits { get; set; } = new List<string>();
            public bool? EnableOvertimeTracking { get; set; } = true;
            public bool? RequireOvertimeApproval { get; set; } = true;
            public int? MaxRegularOvertimeHours { get; set; } = 20;
            public bool? TrackCommissions { get; set; } = false;
            public decimal? DefaultCommissionRate { get; set; } = 0;
        }

        public class DefaultIncomeViewModel
        {
            public string? CompanyId { get; set; }
            public List<DefaultIncomeItem>? DefaultIncomes { get; set; }
        }

        public class EmployeeBaseInfoViewModel
        {
            public string? EmployeeCode { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
        }

        public class DefaultIncomeItem
        {
            public string? Id { get; set; }
            public string? IncomeType { get; set; }
            public string? IncomeCode { get; set; }
            public string? IncomeName { get; set; }
            public decimal? DefaultAmount { get; set; } = 0;
            public bool? ApplyToAllEmployees { get; set; } = false;
            public string? CalculationType { get; set; } = "fixed";
            public string? FrequencyType { get; set; } = "monthly";
            public bool? TaxExempt { get; set; } = false;
            public bool? IncludeInSocialSecurity { get; set; } = true;
            public bool? IncludeInThirteenthMonth { get; set; } = true;
            public bool? IsActive { get; set; } = true;
            public string? ApplicableToEmployeeTypes { get; set; } = "all";
            public string? AccountingCode { get; set; }
            public string? Description { get; set; }
        }
        #endregion
    }
}