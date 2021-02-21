using Microsoft.EntityFrameworkCore;

namespace MovieManagement.Database
{
    public partial class MovieManagementContext : DbContext
    {
        public MovieManagementContext()
        {
        }

        public MovieManagementContext(DbContextOptions<MovieManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actor { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<MovieActor> MovieActor { get; set; }
        public virtual DbSet<ProductionCompany> ProductionCompany { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=example;database=moviemanagement");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.ActId)
                    .HasName("PRIMARY");

                entity.ToTable("Actor", "MovieManagement");

                entity.Property(e => e.ActId).HasColumnName("act_id");

                entity.Property(e => e.ActFirstName)
                    .IsRequired()
                    .HasColumnName("act_firstName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ActLastName)
                    .IsRequired()
                    .HasColumnName("act_lastName")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ActOriginCountry)
                    .IsRequired()
                    .HasColumnName("act_originCountry")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovId)
                    .HasName("PRIMARY");

                entity.ToTable("Movie", "MovieManagement");

                entity.HasIndex(e => e.PrcId)
                    .HasName("fk_Movie_Studio_idx");

                entity.Property(e => e.MovId).HasColumnName("mov_id");

                entity.Property(e => e.MovReleased).HasColumnName("mov_released");

                entity.Property(e => e.MovTitle)
                    .IsRequired()
                    .HasColumnName("mov_title")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.PrcId).HasColumnName("prc_id");

                entity.HasOne(d => d.Prc)
                    .WithMany(p => p.Movie)
                    .HasForeignKey(d => d.PrcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Movie_Studio");
            });

            modelBuilder.Entity<MovieActor>(entity =>
            {
                entity.HasKey(e => e.MovActId)
                    .HasName("PRIMARY");

                entity.ToTable("MovieActor", "MovieManagement");

                entity.HasIndex(e => e.ActId)
                    .HasName("fk_Movie_has_Actor_Actor1_idx");

                entity.HasIndex(e => e.MovId)
                    .HasName("fk_Movie_has_Actor_Movie1_idx");

                entity.Property(e => e.MovActId).HasColumnName("movAct_id");

                entity.Property(e => e.ActId).HasColumnName("act_id");

                entity.Property(e => e.MovId).HasColumnName("mov_id");

                entity.HasOne(d => d.Act)
                    .WithMany(p => p.MovieActor)
                    .HasForeignKey(d => d.ActId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Movie_has_Actor_Actor1");

                entity.HasOne(d => d.Mov)
                    .WithMany(p => p.MovieActor)
                    .HasForeignKey(d => d.MovId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Movie_has_Actor_Movie1");
            });

            modelBuilder.Entity<ProductionCompany>(entity =>
            {
                entity.HasKey(e => e.PrcId)
                    .HasName("PRIMARY");

                entity.ToTable("ProductionCompany", "MovieManagement");

                entity.Property(e => e.PrcId).HasColumnName("prc_id");

                entity.Property(e => e.PrcName)
                    .IsRequired()
                    .HasColumnName("prc_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
