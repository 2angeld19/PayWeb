using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace PayWeb.Controllers
{
    public class FormController : Controller
    {
        private readonly ICompositeViewEngine _viewEngine;

        public FormController(ICompositeViewEngine viewEngine)
        {
            _viewEngine = viewEngine;
        }

        #region POST Methods - General Data
        [HttpPost]
        public IActionResult SaveBranches(BranchViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveDepartments(DepartmentViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SavePositions(PositionViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveSchedules(ScheduleViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveCostCenters(CostCenterViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveProjects(ProjectViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SavePhases(PhaseViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult SaveDivision(DivisionViewModel model)
        {
            // Aquí iría tu lógica para guardar los datos
            return Json(new { success = true });
        }
        #endregion

        #region POST Methods - Employees
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

        #region View Models - General Data
        public class BranchViewModel
        {
            public string? BranchName { get; set; }
            public string? BranchAddress { get; set; }
            public string? BranchPhone { get; set; }
        }

        public class DepartmentViewModel
        {
            public string? DepartmentName { get; set; }
            public string? DepartmentCode { get; set; }
            public string? ManagerId { get; set; }
        }

        public class PositionViewModel
        {
            public string? PositionName { get; set; }
            public string? PositionCode { get; set; }
            public string? DepartmentId { get; set; }
        }

        public class ScheduleViewModel
        {
            public string? ScheduleName { get; set; }
            public TimeSpan? StartTime { get; set; }
            public TimeSpan? EndTime { get; set; }
            public int? LunchBreak { get; set; }
        }

        public class CostCenterViewModel
        {
            public string? CostCenterName { get; set; }
            public string? CostCenterCode { get; set; }
            public decimal? Budget { get; set; }
        }

        public class ProjectViewModel
        {
            public string? ProjectName { get; set; }
            public string? ProjectCode { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
        }

        public class PhaseViewModel
        {
            public string? PhaseName { get; set; }
            public string? PhaseCode { get; set; }
            public string? ProjectId { get; set; }
        }

        public class DivisionViewModel
        {
            public string? DivisionName { get; set; }
            public string? DivisionCode { get; set; }
            public string? ManagerId { get; set; }
        }
        #endregion

        #region View Models - Employees
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

        #region GET Methods - General Data
        public IActionResult Branches()
        {
            try
            {
                // Intenta encontrar la vista
                var viewEngineResult = _viewEngine.FindView(ControllerContext, "_BranchesForm", false);

                if (viewEngineResult.Success)
                {
                    return PartialView("_BranchesForm");
                }
                else
                {
                    return Content($"Error: Vista no encontrada. Ubicaciones buscadas: {string.Join(", ", viewEngineResult.SearchedLocations)}");
                }
            }
            catch (Exception ex)
            {
                return Content($"Error: {ex.Message} - {ex.StackTrace}");
            }
        }

        public IActionResult Departments()
        {
            return PartialView("_DepartmentsForm");
        }

        public IActionResult Positions()
        {
            return PartialView("_PositionsForm");
        }

        public IActionResult Schedules()
        {
            return PartialView("_SchedulesForm");
        }

        public IActionResult CostCenters()
        {
            return PartialView("_CostCentersForm");
        }

        public IActionResult Projects()
        {
            return PartialView("_ProjectsForm");
        }

        public IActionResult Phases()
        {
            return PartialView("_PhasesForm");
        }

        public IActionResult Division()
        {
            return PartialView("_DivisionForm");
        }
        #endregion

        #region GET Methods - Employees
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
        #endregion

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
                return PartialView("_PaymentMethodsForm");
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
    }
}