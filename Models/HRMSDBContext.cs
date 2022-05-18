using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HRMSCoreWebApp.Models
{
    public partial class HRMSDBContext : DbContext
    {
        public HRMSDBContext()
        {
        }

        public HRMSDBContext(DbContextOptions<HRMSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllowanceGrade> AllowanceGrade { get; set; }
        public virtual DbSet<AllowanceMaster> AllowanceMaster { get; set; }
        public virtual DbSet<AttendanceMaster> AttendanceMaster { get; set; }
        public virtual DbSet<CityMaster> CityMaster { get; set; }
        public virtual DbSet<DeductionGrade> DeductionGrade { get; set; }
        public virtual DbSet<DeductionMaster> DeductionMaster { get; set; }
        public virtual DbSet<DepartmentMaster> DepartmentMaster { get; set; }
        public virtual DbSet<DesignationGrade> DesignationGrade { get; set; }
        public virtual DbSet<DesignationMaster> DesignationMaster { get; set; }
        public virtual DbSet<EmployeeGrade> EmployeeGrade { get; set; }
        public virtual DbSet<EmployeeMaster> EmployeeMaster { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        public virtual DbSet<GradeMaster> GradeMaster { get; set; }
        public virtual DbSet<HolidayMaster> HolidayMaster { get; set; }
        public virtual DbSet<LeaveMaster> LeaveMaster { get; set; }
        public virtual DbSet<PromotionMaster> PromotionMaster { get; set; }
        public virtual DbSet<SalaryPayment> SalaryPayment { get; set; }
        public virtual DbSet<ShiftMaster> ShiftMaster { get; set; }
        public virtual DbSet<StateMaster> StateMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-LDFGQV5\\SQLEXPRESS;Initial Catalog=HRMSDB;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllowanceGrade>(entity =>
            {
                entity.HasOne(d => d.Allowance)
                    .WithMany(p => p.AllowanceGrade)
                    .HasForeignKey(d => d.AllowanceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllowanceGrade_AllowanceMaster");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.AllowanceGrade)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllowanceGrade_GradeMaster");
            });

            modelBuilder.Entity<AllowanceMaster>(entity =>
            {
                entity.HasKey(e => e.AllowanceId);

                entity.Property(e => e.AllowanceName).HasColumnType("text");

                entity.Property(e => e.IsTaxable).HasColumnType("text");
            });

            modelBuilder.Entity<AttendanceMaster>(entity =>
            {
                entity.HasKey(e => e.AttendanceId);

                entity.Property(e => e.AttendanceDate).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AttendanceMaster)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AttendanceMaster_EmployeeMaster");
            });

            modelBuilder.Entity<CityMaster>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.Property(e => e.CityName).HasColumnType("text");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.CityMaster)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CityMaster_StateMaster");
            });

            modelBuilder.Entity<DeductionGrade>(entity =>
            {
                entity.HasOne(d => d.Deduction)
                    .WithMany(p => p.DeductionGrade)
                    .HasForeignKey(d => d.DeductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeductionGrade_DeductionMaster");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.DeductionGrade)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeductionGrade_GradeMaster");
            });

            modelBuilder.Entity<DeductionMaster>(entity =>
            {
                entity.HasKey(e => e.DeductionId);

                entity.Property(e => e.DeductionName)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.DeductionType)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<DepartmentMaster>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.Property(e => e.DepartmentAddress).HasColumnType("text");

                entity.Property(e => e.DepartmentName).HasColumnType("text");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.DepartmentMaster)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentMaster_CityMaster");
            });

            modelBuilder.Entity<DesignationGrade>(entity =>
            {
                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.DesignationGrade)
                    .HasForeignKey(d => d.DesignationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DesignationGrade_DesignationMaster");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.DesignationGrade)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DesignationGrade_GradeMaster");
            });

            modelBuilder.Entity<DesignationMaster>(entity =>
            {
                entity.HasKey(e => e.DesignationId);

                entity.Property(e => e.DesignationName).HasColumnType("text");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DesignationMaster)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DesignationMaster_DepartmentMaster");
            });

            modelBuilder.Entity<EmployeeGrade>(entity =>
            {
                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnType("text");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeGrade)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeGrade_EmployeeMaster");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.EmployeeGrade)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeGrade_GradeMaster");
            });

            modelBuilder.Entity<EmployeeMaster>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.BankAcNo).HasColumnType("text");

                entity.Property(e => e.BankHolderName).HasColumnType("text");

                entity.Property(e => e.BankIfsccode)
                    .HasColumnName("BankIFSCCode")
                    .HasColumnType("text");

                entity.Property(e => e.EmployeeAddress).HasColumnType("text");

                entity.Property(e => e.EmployeeContact).HasColumnType("text");

                entity.Property(e => e.EmployeeDoj)
                    .HasColumnName("EmployeeDOJ")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeEmail).IsUnicode(false);

                entity.Property(e => e.EmployeeFname).HasColumnType("text");

                entity.Property(e => e.EmployeeLname).HasColumnType("text");

                entity.Property(e => e.EmployeeMname).HasColumnType("text");

                entity.Property(e => e.PanCopy).HasColumnType("text");

                entity.Property(e => e.PanNo).HasColumnType("text");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Qualifications).HasColumnType("text");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.EmployeeMaster)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_EmployeeMaster_CityMaster");
            });

            modelBuilder.Entity<EmployeeSalary>(entity =>
            {
                entity.HasKey(e => e.SalaryId);

                entity.Property(e => e.EmbursementDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSalary)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeeSalary_EmployeeMaster");
            });

            modelBuilder.Entity<GradeMaster>(entity =>
            {
                entity.HasKey(e => e.GradeId);

                entity.Property(e => e.GradeName).HasColumnType("text");

                entity.Property(e => e.ModeOfSalary).HasColumnType("text");
            });

            modelBuilder.Entity<HolidayMaster>(entity =>
            {
                entity.HasKey(e => e.HolidayId);

                entity.Property(e => e.HolidayDate).HasColumnType("date");

                entity.Property(e => e.HolidayTitle).HasColumnType("text");
            });

            modelBuilder.Entity<LeaveMaster>(entity =>
            {
                entity.HasKey(e => e.LeaveId);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Reason).HasColumnType("text");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.LeaveMaster)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeaveMaster_EmployeeMaster");
            });

            modelBuilder.Entity<PromotionMaster>(entity =>
            {
                entity.HasKey(e => e.PromotionId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.PromotionMaster)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionMaster_EmployeeMaster");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.PromotionMaster)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionMaster_GradeMaster");
            });

            modelBuilder.Entity<SalaryPayment>(entity =>
            {
                entity.HasKey(e => e.TransactionId);

                entity.Property(e => e.PaymentId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Salary)
                    .WithMany(p => p.SalaryPayment)
                    .HasForeignKey(d => d.SalaryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SalaryPayment_EmployeeSalary");
            });

            modelBuilder.Entity<ShiftMaster>(entity =>
            {
                entity.HasKey(e => e.ShiftId);

                entity.Property(e => e.ShiftName).HasColumnType("text");
            });

            modelBuilder.Entity<StateMaster>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.Property(e => e.StateName).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
