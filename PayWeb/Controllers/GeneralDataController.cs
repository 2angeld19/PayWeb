using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayWeb.Data;
using PayWeb.Models;

namespace PayWeb.Controllers
{
    public class GeneralDataController : Controller
    {
        private readonly ICompositeViewEngine _viewEngine;
        private readonly PayWebDbContext _context;

        public GeneralDataController(ICompositeViewEngine viewEngine, PayWebDbContext context)
        {
            _viewEngine = viewEngine;
            _context = context;
        }

        #region GET Methods - General Data
        public async Task<IActionResult> Branches(int companyId = 1)
        {
            var viewModel = new BranchViewModel
            {
                CompanyId = companyId,
                Branches = await _context.Branches
                    .Where(b => b.CompanyId == companyId)
                    .ToListAsync()
            };
            return PartialView("GeneralData/_BranchesForm", viewModel);
        }

        public async Task<IActionResult> Departments(int companyId = 1)
        {
            var viewModel = new DepartmentViewModel
            {
                CompanyId = companyId,
                Departments = await _context.Departments
                    .Where(d => d.CompanyId == companyId)
                    .ToListAsync()
            };
            return PartialView("GeneralData/_DepartmentsForm", viewModel);
        }

        public async Task<IActionResult> Positions(int companyId = 1)
        {
            var viewModel = new PositionViewModel
            {
                CompanyId = companyId,
                Positions = await _context.Positions
                    .Where(p => p.CompanyId == companyId)
                    .ToListAsync()
            };
            return PartialView("GeneralData/_PositionsForm", viewModel);
        }

        public async Task<IActionResult> Schedules(int companyId = 1)
        {
            var viewModel = new ScheduleViewModel
            {
                CompanyId = companyId,
                Schedules = await _context.Schedules
                    .Where(s => s.CompanyId == companyId)
                    .ToListAsync()
            };
            return PartialView("GeneralData/_SchedulesForm", viewModel);
        }

        public async Task<IActionResult> CostCenters(int companyId = 1)
        {
            var viewModel = new CostCenterViewModel
            {
                CompanyId = companyId,
                CostCenters = await _context.CostCenters
                    .Where(c => c.CompanyId == companyId)
                    .ToListAsync()
            };
            return PartialView("GeneralData/_CostCentersForm", viewModel);
        }

        public async Task<IActionResult> Projects(int companyId = 1)
        {
            var viewModel = new ProjectViewModel
            {
                CompanyId = companyId,
                Projects = await _context.Projects
                    .Where(p => p.CompanyId == companyId)
                    .ToListAsync()
            };
            return PartialView("GeneralData/_ProjectsForm", viewModel);
        }

        public async Task<IActionResult> Phases(int companyId = 1, int? projectId = null)
        {
            var query = _context.Phases
                .Where(p => p.CompanyId == companyId);

            if (projectId.HasValue)
            {
                query = query.Where(p => p.ProjectId == projectId);
            }

            var viewModel = new PhaseViewModel
            {
                CompanyId = companyId,
                ProjectId = projectId,
                Phases = await query.ToListAsync(),
                Projects = await _context.Projects
                    .Where(p => p.CompanyId == companyId)
                    .ToListAsync()
            };
            return PartialView("GeneralData/_PhasesForm", viewModel);
        }

        public async Task<IActionResult> Division(int companyId = 1)
        {
            var viewModel = new DivisionViewModel
            {
                CompanyId = companyId,
                Divisions = await _context.Divisions
                    .Where(d => d.CompanyId == companyId)
                    .ToListAsync()
            };
            return PartialView("GeneralData/_DivisionForm", viewModel);
        }
        #endregion

        #region API Methods - Get Detail
        [HttpGet]
        [Route("Api/Branches/GetDetails")]
        public async Task<IActionResult> GetBranchDetails(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            return Json(branch);
        }

        [HttpGet]
        [Route("Api/Departments/GetDetails")]
        public async Task<IActionResult> GetDepartmentDetails(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Json(department);
        }

        [HttpGet]
        [Route("Api/Positions/GetDetails")]
        public async Task<IActionResult> GetPositionDetails(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null)
            {
                return NotFound();
            }
            return Json(position);
        }

        [HttpGet]
        [Route("Api/Schedules/GetDetails")]
        public async Task<IActionResult> GetScheduleDetails(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Json(schedule);
        }

        [HttpGet]
        [Route("Api/CostCenters/GetDetails")]
        public async Task<IActionResult> GetCostCenterDetails(int id)
        {
            var costCenter = await _context.CostCenters.FindAsync(id);
            if (costCenter == null)
            {
                return NotFound();
            }
            return Json(costCenter);
        }

        [HttpGet]
        [Route("Api/Projects/GetDetails")]
        public async Task<IActionResult> GetProjectDetails(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Json(project);
        }

        [HttpGet]
        [Route("Api/Phases/GetDetails")]
        public async Task<IActionResult> GetPhaseDetails(int id)
        {
            var phase = await _context.Phases.FindAsync(id);
            if (phase == null)
            {
                return NotFound();
            }
            return Json(phase);
        }

        [HttpGet]
        [Route("Api/Divisions/GetDetails")]
        public async Task<IActionResult> GetDivisionDetails(int id)
        {
            var division = await _context.Divisions.FindAsync(id);
            if (division == null)
            {
                return NotFound();
            }
            return Json(division);
        }
        #endregion

        #region API Methods - Save
        [HttpPost]
        [Route("Api/Branches/Save")]
        public async Task<IActionResult> SaveBranch([FromForm] GeneralDataModel.Branch branch)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos inválidos" });
            }

            try
            {
                if (branch.Id == 0)
                {
                    // Nuevo registro
                    _context.Branches.Add(branch);
                }
                else
                {
                    // Actualizar registro existente
                    _context.Entry(branch).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al guardar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/Departments/Save")]
        public async Task<IActionResult> SaveDepartment([FromForm] GeneralDataModel.Department department)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos inválidos" });
            }

            try
            {
                if (department.Id == 0)
                {
                    // Nuevo registro
                    _context.Departments.Add(department);
                }
                else
                {
                    // Actualizar registro existente
                    _context.Entry(department).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al guardar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/Positions/Save")]
        public async Task<IActionResult> SavePosition([FromForm] GeneralDataModel.Position position)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos inválidos" });
            }

            try
            {
                if (position.Id == 0)
                {
                    // Nuevo registro
                    _context.Positions.Add(position);
                }
                else
                {
                    // Actualizar registro existente
                    _context.Entry(position).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al guardar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/Schedules/Save")]
        public async Task<IActionResult> SaveSchedule([FromForm] GeneralDataModel.Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos inválidos" });
            }

            try
            {
                if (schedule.Id == 0)
                {
                    // Nuevo registro
                    _context.Schedules.Add(schedule);
                }
                else
                {
                    // Actualizar registro existente
                    _context.Entry(schedule).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al guardar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/CostCenters/Save")]
        public async Task<IActionResult> SaveCostCenter([FromForm] GeneralDataModel.CostCenter costCenter)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos inválidos" });
            }

            try
            {
                if (costCenter.Id == 0)
                {
                    // Nuevo registro
                    _context.CostCenters.Add(costCenter);
                }
                else
                {
                    // Actualizar registro existente
                    _context.Entry(costCenter).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al guardar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/Projects/Save")]
        public async Task<IActionResult> SaveProject([FromForm] GeneralDataModel.Project project)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos inválidos" });
            }

            try
            {
                if (project.Id == 0)
                {
                    // Nuevo registro
                    _context.Projects.Add(project);
                }
                else
                {
                    // Actualizar registro existente
                    _context.Entry(project).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al guardar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/Phases/Save")]
        public async Task<IActionResult> SavePhase([FromForm] GeneralDataModel.Phase phase)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos inválidos" });
            }

            try
            {
                if (phase.Id == 0)
                {
                    // Nuevo registro
                    _context.Phases.Add(phase);
                }
                else
                {
                    // Actualizar registro existente
                    _context.Entry(phase).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al guardar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/Divisions/Save")]
        public async Task<IActionResult> SaveDivision([FromForm] GeneralDataModel.Division division)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos inválidos" });
            }

            try
            {
                if (division.Id == 0)
                {
                    // Nuevo registro
                    _context.Divisions.Add(division);
                }
                else
                {
                    // Actualizar registro existente
                    _context.Entry(division).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al guardar: {ex.Message}" });
            }
        }
        #endregion

        #region API Methods - Delete
        [HttpPost]
        [Route("Api/Branches/Delete")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return Json(new { success = false, message = "Sucursal no encontrada" });
            }

            try
            {
                _context.Branches.Remove(branch);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al eliminar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/Departments/Delete")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return Json(new { success = false, message = "Departamento no encontrado" });
            }

            try
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al eliminar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/Positions/Delete")]
        public async Task<IActionResult> DeletePosition(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null)
            {
                return Json(new { success = false, message = "Cargo no encontrado" });
            }

            try
            {
                _context.Positions.Remove(position);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al eliminar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/Schedules/Delete")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return Json(new { success = false, message = "Horario no encontrado" });
            }

            try
            {
                _context.Schedules.Remove(schedule);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al eliminar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/CostCenters/Delete")]
        public async Task<IActionResult> DeleteCostCenter(int id)
        {
            var costCenter = await _context.CostCenters.FindAsync(id);
            if (costCenter == null)
            {
                return Json(new { success = false, message = "Centro de costo no encontrado" });
            }

            try
            {
                _context.CostCenters.Remove(costCenter);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al eliminar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/Projects/Delete")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return Json(new { success = false, message = "Proyecto no encontrado" });
            }

            try
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al eliminar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/Phases/Delete")]
        public async Task<IActionResult> DeletePhase(int id)
        {
            var phase = await _context.Phases.FindAsync(id);
            if (phase == null)
            {
                return Json(new { success = false, message = "Fase no encontrada" });
            }

            try
            {
                _context.Phases.Remove(phase);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al eliminar: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("Api/Divisions/Delete")]
        public async Task<IActionResult> DeleteDivision(int id)
        {
            var division = await _context.Divisions.FindAsync(id);
            if (division == null)
            {
                return Json(new { success = false, message = "División no encontrada" });
            }

            try
            {
                _context.Divisions.Remove(division);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Error al eliminar: {ex.Message}" });
            }
        }
        #endregion

        #region View Models - General Data
        public class BranchViewModel
        {
            public int CompanyId { get; set; }
            public List<GeneralDataModel.Branch>? Branches { get; set; }
            public GeneralDataModel.Branch? CurrentBranch { get; set; }
            // Propiedades originales mantenidas por compatibilidad
            public string? BranchName { get; set; }
            public string? BranchAddress { get; set; }
            public string? BranchPhone { get; set; }
        }

        public class DepartmentViewModel
        {
            public int CompanyId { get; set; }
            public List<GeneralDataModel.Department>? Departments { get; set; }
            public GeneralDataModel.Department? CurrentDepartment { get; set; }
            // Propiedades originales mantenidas por compatibilidad
            public string? DepartmentName { get; set; }
            public string? DepartmentCode { get; set; }
            public string? ManagerId { get; set; }
        }

        public class PositionViewModel
        {
            public int CompanyId { get; set; }
            public List<GeneralDataModel.Position>? Positions { get; set; }
            public GeneralDataModel.Position? CurrentPosition { get; set; }
            public List<GeneralDataModel.Department>? Departments { get; set; }
            // Propiedades originales mantenidas por compatibilidad
            public string? PositionName { get; set; }
            public string? PositionCode { get; set; }
            public string? DepartmentId { get; set; }
        }

        public class ScheduleViewModel
        {
            public int CompanyId { get; set; }
            public List<GeneralDataModel.Schedule>? Schedules { get; set; }
            public GeneralDataModel.Schedule? CurrentSchedule { get; set; }
            // Propiedades originales mantenidas por compatibilidad
            public string? ScheduleName { get; set; }
            public TimeSpan? StartTime { get; set; }
            public TimeSpan? EndTime { get; set; }
            public int? LunchBreak { get; set; }
        }

        public class CostCenterViewModel
        {
            public int CompanyId { get; set; }
            public List<GeneralDataModel.CostCenter>? CostCenters { get; set; }
            public GeneralDataModel.CostCenter? CurrentCostCenter { get; set; }
            // Propiedades originales mantenidas por compatibilidad
            public string? CostCenterName { get; set; }
            public string? CostCenterCode { get; set; }
            public decimal? Budget { get; set; }
        }

        public class ProjectViewModel
        {
            public int CompanyId { get; set; }
            public List<GeneralDataModel.Project>? Projects { get; set; }
            public GeneralDataModel.Project? CurrentProject { get; set; }
            // Propiedades originales mantenidas por compatibilidad
            public string? ProjectName { get; set; }
            public string? ProjectCode { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
        }

        public class PhaseViewModel
        {
            public int CompanyId { get; set; }
            public int? ProjectId { get; set; }
            public List<GeneralDataModel.Phase>? Phases { get; set; }
            public GeneralDataModel.Phase? CurrentPhase { get; set; }
            public List<GeneralDataModel.Project>? Projects { get; set; }
            // Propiedades originales mantenidas por compatibilidad
            public string? PhaseName { get; set; }
            public string? PhaseCode { get; set; }
            public string? ProjectIdString { get; set; }
        }

        public class DivisionViewModel
        {
            public int CompanyId { get; set; }
            public List<GeneralDataModel.Division>? Divisions { get; set; }
            public GeneralDataModel.Division? CurrentDivision { get; set; }
            // Propiedades originales mantenidas por compatibilidad
            public string? DivisionName { get; set; }
            public string? DivisionCode { get; set; }
            public string? ManagerId { get; set; }
        }
        #endregion
    }
}