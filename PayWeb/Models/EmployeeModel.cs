using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PayWeb.Pages.WizardSteps;

namespace PayWeb.Models
{
    public class EmployeeModel
    {
        // Entidad Employee
        public class Employee
        {
            [Key]
            public int Id { get; set; }

            [StringLength(50)]
            public string? EmployeeId { get; set; }

            [StringLength(20)]
            public string? IdentificationNumber { get; set; }

            [StringLength(20)]
            public string? IdentificationType { get; set; }

            [Required(ErrorMessage = "El nombre es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string FirstName { get; set; } = null!;

            [Required(ErrorMessage = "El apellido es obligatorio")]
            [StringLength(100, ErrorMessage = "El apellido no puede exceder los 100 caracteres")]
            public string LastName { get; set; } = null!;

            [StringLength(100)]
            public string? SecondLastName { get; set; }

            [DataType(DataType.Date)]
            public DateTime? DateOfBirth { get; set; }

            [StringLength(10)]
            public string? Gender { get; set; }

            [StringLength(20)]
            public string? MaritalStatus { get; set; }

            [StringLength(50)]
            public string? Nationality { get; set; }

            [StringLength(100)]
            [EmailAddress(ErrorMessage = "Formato de correo electrónico inválido")]
            public string? Email { get; set; }

            [StringLength(20)]
            public string? PhoneNumber { get; set; }

            [StringLength(200)]
            public string? Address { get; set; }

            [StringLength(100)]
            public string? City { get; set; }

            [StringLength(100)]
            public string? State { get; set; }

            [StringLength(20)]
            public string? PostalCode { get; set; }

            public int? PositionId { get; set; }

            [ForeignKey("PositionId")]
            public GeneralDataModel.Position? Position { get; set; }

            public int? DepartmentId { get; set; }

            [ForeignKey("DepartmentId")]
            public GeneralDataModel.Department? Department { get; set; }

            [DataType(DataType.Date)]
            public DateTime? HireDate { get; set; }

            public int? EmployeeTypeId { get; set; }

            [ForeignKey("EmployeeTypeId")]
            public EmployeeType? EmployeeType { get; set; }

            public int? SupervisorId { get; set; }

            [ForeignKey("SupervisorId")]
            public Employee? Supervisor { get; set; }

            public bool IsActive { get; set; } = true;

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }

            public int? BranchId { get; set; }

            [ForeignKey("BranchId")]
            public GeneralDataModel.Branch? Branch { get; set; }

            public int? ScheduleId { get; set; }

            [ForeignKey("ScheduleId")]
            public GeneralDataModel.Schedule? Schedule { get; set; }

            public int? PaymentMethodId { get; set; }

            [ForeignKey("PaymentMethodId")]
            public BankModel.PaymentMethod? PaymentMethod { get; set; }

            public int? CostCenterId { get; set; }

            [ForeignKey("CostCenterId")]
            public GeneralDataModel.CostCenter? CostCenter { get; set; }

            // Relaciones inversas
            public ICollection<Employee>? Subordinates { get; set; }
            public ICollection<GeneralDataModel.Department>? ManagedDepartments { get; set; }
            public ICollection<GeneralDataModel.Division>? ManagedDivisions { get; set; }
            public ICollection<EmployeeNote>? Notes { get; set; }
        }

        // Entidad EmployeeType
        public class EmployeeType
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre del tipo de empleado es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string TypeName { get; set; } = null!;

            [StringLength(20)]
            public string? TypeCode { get; set; }

            public bool IsActive { get; set; } = true;

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }

            public ICollection<Employee>? Employees { get; set; }
        }

        // Entidad ContractType
        public class ContractType
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre del tipo de contrato es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string ContractName { get; set; } = null!;

            [StringLength(20)]
            public string? ContractCode { get; set; }

            public int? DurationMonths { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }
        }

        // Entidad SalaryType
        public class SalaryType
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre del tipo de salario es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string SalaryName { get; set; } = null!;

            [StringLength(20)]
            public string? SalaryCode { get; set; }

            [StringLength(50)]
            public string? CalculationMethod { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }
        }

        // Entidad Deduction
        public class Deduction
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre de la deducción es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string DeductionName { get; set; } = null!;

            [StringLength(20)]
            public string? DeductionCode { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal? Amount { get; set; }

            public bool IsPercentage { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }
        }

        // Entidad Bonus
        public class Bonus
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre del bono es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string BonusName { get; set; } = null!;

            [StringLength(20)]
            public string? BonusCode { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal? Amount { get; set; }

            public bool IsPercentage { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }
        }

        // Entidad EmployeeNote
        public class EmployeeNote
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public int EmployeeId { get; set; }

            [ForeignKey("EmployeeId")]
            public Employee? Employee { get; set; }

            [DataType(DataType.DateTime)]
            public DateTime NoteDate { get; set; } = DateTime.Now;

            [StringLength(1000)]
            public string? NoteContent { get; set; }

            [StringLength(50)]
            public string? NoteCategory { get; set; }

            [StringLength(20)]
            public string? NotePriority { get; set; }

            [StringLength(255)]
            public string? AttachmentPath { get; set; }
        }

        // Entidad GeneralEmployeeData
        public class GeneralEmployeeData
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }

            public bool UseDefaultWorkSchedule { get; set; } = true;
            public TimeSpan DefaultStartTime { get; set; } = new TimeSpan(8, 0, 0);
            public TimeSpan DefaultEndTime { get; set; } = new TimeSpan(17, 0, 0);
            public int DefaultBreakMinutes { get; set; } = 60;

            [Column(TypeName = "decimal(18,2)")]
            public decimal DefaultBaseSalary { get; set; } = 0;

            [StringLength(50)]
            public string DefaultTaxCalculationMethod { get; set; } = "average";

            public bool AutomaticallyCalculateOvertime { get; set; } = true;
            public bool TrackAttendance { get; set; } = true;

            [StringLength(50)]
            public string DefaultEmploymentType { get; set; } = "permanent";

            public int DefaultProbationPeriodDays { get; set; } = 90;
            public bool AllowBackdatedTransactions { get; set; } = false;
            public bool RequireDocumentationForLeave { get; set; } = true;

            [Column(TypeName = "decimal(18,2)")]
            public decimal DefaultVacationDaysPerYear { get; set; } = 15;

            [Column(TypeName = "decimal(18,2)")]
            public decimal DefaultSickDaysPerYear { get; set; } = 10;
        }

        // Entidad IncomeConfig
        public class IncomeConfig
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal RegularOvertimeRate { get; set; } = 1.25m;

            [Column(TypeName = "decimal(18,2)")]
            public decimal HolidayOvertimeRate { get; set; } = 2.0m;

            [Column(TypeName = "decimal(18,2)")]
            public decimal NightShiftPremium { get; set; } = 0.15m;

            public bool IncludeBonusInSocialSecurity { get; set; } = true;
            public bool IncludeOvertimeInThirteenthMonth { get; set; } = true;
            public bool AutoCalculateIncomeWithholding { get; set; } = true;

            [StringLength(50)]
            public string IncomeTaxCalculationType { get; set; } = "monthly";

            public bool EnableOvertimeTracking { get; set; } = true;
            public bool RequireOvertimeApproval { get; set; } = true;
            public int MaxRegularOvertimeHours { get; set; } = 20;
            public bool TrackCommissions { get; set; } = false;

            [Column(TypeName = "decimal(18,2)")]
            public decimal DefaultCommissionRate { get; set; } = 0;
        }

        // Entidad DefaultIncome
        public class DefaultIncome
        {
            [Key]
            public int Id { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }

            [Required(ErrorMessage = "El tipo de ingreso es obligatorio")]
            [StringLength(50)]
            public string IncomeType { get; set; } = null!;

            [StringLength(20)]
            public string? IncomeCode { get; set; }

            [Required(ErrorMessage = "El nombre del ingreso es obligatorio")]
            [StringLength(100)]
            public string IncomeName { get; set; } = null!;

            [Column(TypeName = "decimal(18,2)")]
            public decimal DefaultAmount { get; set; } = 0;

            public bool ApplyToAllEmployees { get; set; } = false;

            [StringLength(50)]
            public string CalculationType { get; set; } = "fixed";

            [StringLength(50)]
            public string FrequencyType { get; set; } = "monthly";

            public bool TaxExempt { get; set; } = false;
            public bool IncludeInSocialSecurity { get; set; } = true;
            public bool IncludeInThirteenthMonth { get; set; } = true;
            public bool IsActive { get; set; } = true;

            [StringLength(50)]
            public string ApplicableToEmployeeTypes { get; set; } = "all";

            [StringLength(50)]
            public string? AccountingCode { get; set; }

            [StringLength(200)]
            public string? Description { get; set; }
        }
    }
}