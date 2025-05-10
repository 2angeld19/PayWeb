using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PayWeb.Pages.WizardSteps;

namespace PayWeb.Models
{
    public class GeneralDataModel
    {
        // Entidad Branch
        public class Branch
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre de la sucursal es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string BranchName { get; set; } = null!;

            [StringLength(200)]
            public string? BranchAddress { get; set; }

            [StringLength(20)]
            [RegularExpression(@"^\+?[0-9\s\-\(\)]+$", ErrorMessage = "Formato de teléfono inválido")]
            public string? BranchPhone { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }

            public ICollection<EmployeeModel.Employee>? Employees { get; set; }
        }

        // Entidad Department
        public class Department
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre del departamento es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string DepartmentName { get; set; } = null!;

            [StringLength(20)]
            public string? DepartmentCode { get; set; }

            public int? ManagerId { get; set; }

            [ForeignKey("ManagerId")]
            public EmployeeModel.Employee? Manager { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }

            public ICollection<Position>? Positions { get; set; }
            public ICollection<EmployeeModel.Employee>? Employees { get; set; }
        }

        // Entidad Position
        public class Position
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre del cargo es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string PositionName { get; set; } = null!;

            [StringLength(20)]
            public string? PositionCode { get; set; }

            public int? DepartmentId { get; set; }

            [ForeignKey("DepartmentId")]
            public Department? Department { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }

            public ICollection<EmployeeModel.Employee>? Employees { get; set; }
        }

        // Entidad Schedule
        public class Schedule
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre del horario es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string ScheduleName { get; set; } = null!;

            public TimeSpan? StartTime { get; set; }
            public TimeSpan? EndTime { get; set; }
            public int? LunchBreak { get; set; }
            public bool CalcAbsencesDelays { get; set; }
            public bool StrictSchedule { get; set; }
            public bool AuthorizeOvertime { get; set; }

            [Range(1, 4, ErrorMessage = "El método de captura de horas debe estar entre 1 y 4")]
            public int TimeMethod { get; set; } = 2; // Default: 2. S.T. Entrada/S.T. Salida

            public bool Status { get; set; } = true;

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }

            public ICollection<EmployeeModel.Employee>? Employees { get; set; }
        }

        // Entidad CostCenter
        public class CostCenter
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre del centro de costo es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string CostCenterName { get; set; } = null!;

            [StringLength(20)]
            public string? CostCenterCode { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal? Budget { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }

            public ICollection<EmployeeModel.Employee>? Employees { get; set; }
        }

        // Entidad Project
        public class Project
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre del proyecto es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string ProjectName { get; set; } = null!;

            [StringLength(20)]
            public string? ProjectCode { get; set; }

            [DataType(DataType.Date)]
            public DateTime? StartDate { get; set; }

            [DataType(DataType.Date)]
            public DateTime? EndDate { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }

            public ICollection<Phase>? Phases { get; set; }
        }

        // Entidad Phase
        public class Phase
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre de la fase es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string PhaseName { get; set; } = null!;

            [StringLength(20)]
            public string? PhaseCode { get; set; }

            public int? ProjectId { get; set; }

            [ForeignKey("ProjectId")]
            public Project? Project { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }
        }

        // Entidad Division
        public class Division
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre de la división es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string DivisionName { get; set; } = null!;

            [StringLength(20)]
            public string? DivisionCode { get; set; }

            public int? ManagerId { get; set; }

            [ForeignKey("ManagerId")]
            public EmployeeModel.Employee? Manager { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }
        }
    }
}