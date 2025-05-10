using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using PayWeb.Models;

namespace PayWeb.Data
{
    public class PayWebDbContext : DbContext
    {
        public PayWebDbContext(DbContextOptions<PayWebDbContext> options)
            : base(options)
        {
        }

        // Company
        public DbSet<CompanyModel.Company> Companies { get; set; } = null!;

        // GeneralData
        public DbSet<GeneralDataModel.Branch> Branches { get; set; } = null!;
        public DbSet<GeneralDataModel.Department> Departments { get; set; } = null!;
        public DbSet<GeneralDataModel.Position> Positions { get; set; } = null!;
        public DbSet<GeneralDataModel.Schedule> Schedules { get; set; } = null!;
        public DbSet<GeneralDataModel.CostCenter> CostCenters { get; set; } = null!;
        public DbSet<GeneralDataModel.Project> Projects { get; set; } = null!;
        public DbSet<GeneralDataModel.Phase> Phases { get; set; } = null!;
        public DbSet<GeneralDataModel.Division> Divisions { get; set; } = null!;

        // Banks
        public DbSet<BankModel.Bank> Banks { get; set; } = null!;
        public DbSet<BankModel.PaymentMethod> PaymentMethods { get; set; } = null!;
        public DbSet<BankModel.PayFrequency> PayFrequencies { get; set; } = null!;
        public DbSet<BankModel.FileFormat> FileFormats { get; set; } = null!;

        // Employees
        public DbSet<EmployeeModel.Employee> Employees { get; set; } = null!;
        public DbSet<EmployeeModel.EmployeeType> EmployeeTypes { get; set; } = null!;
        public DbSet<EmployeeModel.ContractType> ContractTypes { get; set; } = null!;
        public DbSet<EmployeeModel.SalaryType> SalaryTypes { get; set; } = null!;
        public DbSet<EmployeeModel.Deduction> Deductions { get; set; } = null!;
        public DbSet<EmployeeModel.Bonus> Bonuses { get; set; } = null!;
        public DbSet<EmployeeModel.EmployeeNote> EmployeeNotes { get; set; } = null!;
        public DbSet<EmployeeModel.GeneralEmployeeData> GeneralEmployeeData { get; set; } = null!;
        public DbSet<EmployeeModel.IncomeConfig> IncomeConfigs { get; set; } = null!;
        public DbSet<EmployeeModel.DefaultIncome> DefaultIncomes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones circulares
            modelBuilder.Entity<EmployeeModel.Employee>()
                .HasOne(e => e.Supervisor)
                .WithMany(e => e.Subordinates)
                .HasForeignKey(e => e.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GeneralDataModel.Department>()
                .HasOne(d => d.Manager)
                .WithMany(e => e.ManagedDepartments)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<GeneralDataModel.Division>()
                .HasOne(d => d.Manager)
                .WithMany(e => e.ManagedDivisions)
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}