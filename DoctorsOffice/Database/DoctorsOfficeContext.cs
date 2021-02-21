using Microsoft.EntityFrameworkCore;

namespace DoctorsOffice.Database
{
    public partial class DoctorsOfficeContext : DbContext
    {
        public DoctorsOfficeContext()
        {
        }

        public DoctorsOfficeContext(DbContextOptions<DoctorsOfficeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diagnoses> Diagnoses { get; set; }
        public virtual DbSet<Diseaseareas> Diseaseareas { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Patientsdiagnoses> Patientsdiagnoses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=example;database=DoctorsOffice");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnoses>(entity =>
            {
                entity.HasKey(e => e.DiaId)
                    .HasName("PRIMARY");

                entity.ToTable("diagnoses", "DoctorsOffice");

                entity.HasIndex(e => e.DisId)
                    .HasName("fk_diagnoses_diseaseareas_idx");

                entity.Property(e => e.DiaId).HasColumnName("dia_id");

                entity.Property(e => e.DiaDescription)
                    .IsRequired()
                    .HasColumnName("dia_description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DisId).HasColumnName("dis_id");

                entity.HasOne(d => d.Dis)
                    .WithMany(p => p.Diagnoses)
                    .HasForeignKey(d => d.DisId)
                    .HasConstraintName("fk_diagnoses_diseaseareas");
            });

            modelBuilder.Entity<Diseaseareas>(entity =>
            {
                entity.HasKey(e => e.DisId)
                    .HasName("PRIMARY");

                entity.ToTable("diseaseareas", "DoctorsOffice");

                entity.Property(e => e.DisId).HasColumnName("dis_id");

                entity.Property(e => e.DisName)
                    .IsRequired()
                    .HasColumnName("dis_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.PatId)
                    .HasName("PRIMARY");

                entity.ToTable("patients", "DoctorsOffice");

                entity.Property(e => e.PatId).HasColumnName("pat_id");

                entity.Property(e => e.PatBirthday).HasColumnName("pat_birthday");

                entity.Property(e => e.PatFirstName)
                    .IsRequired()
                    .HasColumnName("pat_firstName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PatLastName)
                    .IsRequired()
                    .HasColumnName("pat_lastName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PatSvnr).HasColumnName("pat_svnr");
            });

            modelBuilder.Entity<Patientsdiagnoses>(entity =>
            {
                entity.HasKey(e => e.PatdiaId)
                    .HasName("PRIMARY");

                entity.ToTable("patientsdiagnoses", "DoctorsOffice");

                entity.HasIndex(e => e.DiaId)
                    .HasName("fk_patients_has_diagnoses_diagnoses1_idx");

                entity.HasIndex(e => e.PatId)
                    .HasName("fk_patients_has_diagnoses_patients1_idx");

                entity.Property(e => e.PatdiaId).HasColumnName("patdia_id");

                entity.Property(e => e.DiaId).HasColumnName("dia_id");

                entity.Property(e => e.PatId).HasColumnName("pat_id");

                entity.Property(e => e.PatdiaVisit).HasColumnName("patdia_visit");

                entity.HasOne(d => d.Dia)
                    .WithMany(p => p.Patientsdiagnoses)
                    .HasForeignKey(d => d.DiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_patients_has_diagnoses_diagnoses1");

                entity.HasOne(d => d.Pat)
                    .WithMany(p => p.Patientsdiagnoses)
                    .HasForeignKey(d => d.PatId)
                    .HasConstraintName("fk_patients_has_diagnoses_patients1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
