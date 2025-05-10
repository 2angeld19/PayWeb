using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayWeb.Models
{
    public class BankModel
    {
        // Entidad Bank
        public class Bank
        {
            [Key]
            public int Id { get; set; }

            public int BankNumber { get; set; }

            [StringLength(100)]
            public string? BankName { get; set; }

            [StringLength(50)]
            public string? AssignedNumber { get; set; }

            [StringLength(50)]
            public string? InterfaceCode { get; set; }

            public int LastCheckUsed { get; set; }

            [StringLength(50)]
            public string? BankAccountNumber { get; set; }

            [StringLength(20)]
            public string? AccountType { get; set; } // "current" o "savings"

            [StringLength(50)]
            public string? BankRoute { get; set; }

            [StringLength(50)]
            public string? RouteNumber { get; set; }

            [StringLength(50)]
            public string? AchFormat { get; set; }

            [StringLength(50)]
            public string? GeneralLedgerAccount { get; set; }

            public bool ControlAchSequence { get; set; }

            [StringLength(500)]
            public string? LetterAddress { get; set; }

            [StringLength(100)]
            public string? Signature { get; set; }

            [StringLength(100)]
            public string? OurContact { get; set; }

            [StringLength(50)]
            public string? CopyCheckConfig { get; set; }

            public int EmployeeAchSequence { get; set; }
            public int SupplierAchSequence { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }
        }

        // Entidad PaymentMethod
        public class PaymentMethod
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre del método de pago es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string MethodName { get; set; } = null!;

            [StringLength(20)]
            public string? MethodCode { get; set; }

            public bool IsElectronic { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }

            public ICollection<EmployeeModel.Employee>? Employees { get; set; }
        }

        // Entidad PayFrequency
        public class PayFrequency
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre de la frecuencia de pago es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string FrequencyName { get; set; } = null!;

            [StringLength(20)]
            public string? FrequencyCode { get; set; }

            public int? DaysInterval { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }
        }

        // Entidad FileFormat
        public class FileFormat
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "El nombre del formato de archivo es obligatorio")]
            [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
            public string FormatName { get; set; } = null!;

            [StringLength(20)]
            public string? FormatCode { get; set; }

            [StringLength(20)]
            public string? FileExtension { get; set; }

            [Required]
            public int CompanyId { get; set; }

            [ForeignKey("CompanyId")]
            public CompanyModel.Company? Company { get; set; }
        }
    }
}