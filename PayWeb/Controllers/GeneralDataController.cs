using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace PayWeb.Controllers
{
    public class GeneralDataController : Controller
    {
        private readonly ICompositeViewEngine _viewEngine;

        public GeneralDataController(ICompositeViewEngine viewEngine)
        {
            _viewEngine = viewEngine;
        }

        #region GET Methods - General Data
        public IActionResult Branches()
        {
            return PartialView("GeneralData/_BranchesForm");
        }

        public IActionResult Departments()
        {
            return PartialView("GeneralData/_DepartmentsForm");
        }

        public IActionResult Positions()
        {
            return PartialView("GeneralData/_PositionsForm");
        }

        public IActionResult Schedules()
        {
            return PartialView("GeneralData/_SchedulesForm");
        }

        public IActionResult CostCenters()
        {
            return PartialView("GeneralData/_CostCentersForm");
        }

        public IActionResult Projects()
        {
            return PartialView("GeneralData/_ProjectsForm");
        }

        public IActionResult Phases()
        {
            return PartialView("GeneralData/_PhasesForm");
        }

        public IActionResult Division()
        {
            return PartialView("GeneralData/_DivisionForm");
        }
        #endregion

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
    }
}