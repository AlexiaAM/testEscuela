using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace testI.BD
{
    public partial class escuelatestContext : DbContext
    {
        public escuelatestContext()
        {
        }

        public escuelatestContext(DbContextOptions<escuelatestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<Clase> Clases { get; set; } = null!;
        public virtual DbSet<Clasehasalumno> Clasehasalumnos { get; set; } = null!;
        public virtual DbSet<Maestro> Maestros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;password=root;database=escuelatest", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PRIMARY");

                entity.ToTable("alumno");

                entity.Property(e => e.IdAlumno).HasColumnName("idAlumno");

                entity.Property(e => e.NombreAlumno).HasMaxLength(45);
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.HasKey(e => e.IdClase)
                    .HasName("PRIMARY");

                entity.ToTable("clase");

                entity.HasIndex(e => e.IdMaestro, "IdMaestro");

                entity.Property(e => e.NombreClase).HasMaxLength(45);

                entity.HasOne(d => d.IdMaestroNavigation)
                    .WithMany(p => p.Clases)
                    .HasForeignKey(d => d.IdMaestro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clase_ibfk_1");
            });

            modelBuilder.Entity<Clasehasalumno>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("clasehasalumno");

                entity.HasIndex(e => e.IdAlumno, "IdAlumno");

                entity.HasIndex(e => e.IdClase, "IdClase");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdAlumno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clasehasalumno_ibfk_2");

                entity.HasOne(d => d.IdClaseNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdClase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("clasehasalumno_ibfk_1");
            });

            modelBuilder.Entity<Maestro>(entity =>
            {
                entity.HasKey(e => e.IdMaestro)
                    .HasName("PRIMARY");

                entity.ToTable("maestro");

                entity.Property(e => e.NombreMaestro).HasMaxLength(45);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
