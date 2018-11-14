using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Judo.Models.Mapped
{
    public partial class JudoDBContext : DbContext, IJudoDBContext
    {
        public virtual DbSet<Characteristics> Characteristics { get; set; }
        public virtual DbSet<CharacteristicToStudent> CharacteristicToStudent { get; set; }
        public virtual DbSet<CharacteristicType> CharacteristicType { get; set; }
        public virtual DbSet<Disciplines> Disciplines { get; set; }
        public virtual DbSet<Exercises> Exercises { get; set; }
        public virtual DbSet<ExerciseSections> ExerciseSections { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<GroupsToExercise> GroupsToExercise { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<Ranks> Ranks { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudentsToGroup> StudentsToGroup { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=JudoDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Characteristics>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Characteristics)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Characteristics_CharacteristicType");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Characteristics)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_Characteristics_Units");
            });

            modelBuilder.Entity<CharacteristicToStudent>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.CharacteristicId });

                entity.HasOne(d => d.Characteristic)
                    .WithMany(p => p.CharacteristicToStudent)
                    .HasForeignKey(d => d.CharacteristicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacteristicToStudent_Characteristics");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.CharacteristicToStudent)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacteristicToStudent_Students");
            });

            modelBuilder.Entity<CharacteristicType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InverseIdNavigation)
                    .HasForeignKey<CharacteristicType>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacteristicType_CharacteristicType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CharacteristicType)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacteristicType_Users");
            });

            modelBuilder.Entity<Disciplines>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Exercises>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Start).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExerciseSections>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Discipline)
                    .WithMany(p => p.Groups)
                    .HasForeignKey(d => d.DisciplineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Groups_Disciplines");
            });

            modelBuilder.Entity<GroupsToExercise>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.ExerciseId });

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.GroupsToExercise)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupsToExercise_Exercises");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupsToExercise)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GroupsToExercise_Groups");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.First)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Last)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Middle).HasMaxLength(50);
            });

            modelBuilder.Entity<Ranks>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasOne(d => d.People)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_People");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Students_Ranks");
            });

            modelBuilder.Entity<StudentsToGroup>(entity =>
            {
                entity.HasKey(e => new { e.StudentId, e.GroupId });

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.StudentsToGroup)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsToGroup_Groups");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentsToGroup)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentsToGroup_Students");
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
