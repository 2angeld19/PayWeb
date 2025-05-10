using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayWeb.Models
{
    public class CompanyModel
    {
        // Entidad Company
        public class Company
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El número de compañía es obligatorio")]
            public int CompanyNumber { get; set; }

            [Required(ErrorMessage = "El nombre corto es obligatorio")]
            [StringLength(15, ErrorMessage = "El nombre corto no puede exceder los 15 caracteres")]
            public string ShortName { get; set; } = null!;

            [StringLength(50)]
            public string? BankNumber { get; set; }

            [StringLength(50)]
            public string? InterfaceCode { get; set; }

            [Required(ErrorMessage = "El nombre del patrono es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string EmployerName { get; set; } = null!;

            [StringLength(100)]
            public string? WorkplaceName { get; set; }

            [StringLength(100)]
            public string? LegalRepresentative { get; set; }

            [StringLength(200)]
            public string? FiscalAddress { get; set; }

            [StringLength(255)]
            public string? LogoPath { get; set; }

            [StringLength(100)]
            public string? EconomicActivity { get; set; }

            [StringLength(50)]
            public string? License { get; set; }

            public int? CorrelationNumber { get; set; }

            [StringLength(50)]
            public string? EmployerNumber { get; set; }

            [StringLength(50)]
            public string? LegalId { get; set; }

            [StringLength(10)]
            public string? Dv { get; set; }

            [StringLength(50)]
            public string? NaturalId { get; set; }

            [StringLength(20)]
            [RegularExpression(@"^\+?[0-9\s\-\(\)]+$", ErrorMessage = "Formato de teléfono inválido")]
            public string? Phone { get; set; }

            [StringLength(20)]
            public string? Fax { get; set; }

            public int? LastThirteenthMonthPaid { get; set; }

            [DataType(DataType.Date)]
            public DateTime? LastPeriodPaid { get; set; }

            [Range(2000, 2100)]
            public int? LastClosedYear { get; set; }

            [DataType(DataType.Date)]
            public DateTime? LastPaymentToCreditors { get; set; }

            [StringLength(255)]
            public string? DataPath { get; set; }

            public bool IsConstructionCompany { get; set; }
            public bool IsAgricultureCompany { get; set; }
            public bool CostBreakdownByActivities { get; set; }
            public bool IsSemVisa { get; set; }

            // Relaciones
            public ICollection<GeneralDataModel.Branch>? Branches { get; set; }
            public ICollection<GeneralDataModel.Department>? Departments { get; set; }
            public ICollection<GeneralDataModel.Position>? Positions { get; set; }
            public ICollection<GeneralDataModel.Schedule>? Schedules { get; set; }
            public ICollection<GeneralDataModel.CostCenter>? CostCenters { get; set; }
            public ICollection<GeneralDataModel.Project>? Projects { get; set; }
            public ICollection<GeneralDataModel.Phase>? Phases { get; set; }
            public ICollection<GeneralDataModel.Division>? Divisions { get; set; }
            public ICollection<BankModel.Bank>? Banks { get; set; }
            public ICollection<BankModel.PaymentMethod>? PaymentMethods { get; set; }
            public ICollection<BankModel.PayFrequency>? PayFrequencies { get; set; }
            public ICollection<BankModel.FileFormat>? FileFormats { get; set; }
            public ICollection<EmployeeModel.Employee>? Employees { get; set; }
            public ICollection<EmployeeModel.EmployeeType>? EmployeeTypes { get; set; }
            public ICollection<EmployeeModel.ContractType>? ContractTypes { get; set; }
            public ICollection<EmployeeModel.SalaryType>? SalaryTypes { get; set; }
            public ICollection<EmployeeModel.Deduction>? Deductions { get; set; }
            public ICollection<EmployeeModel.Bonus>? Bonuses { get; set; }
        }
    }
}