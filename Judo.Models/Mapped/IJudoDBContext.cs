using Microsoft.EntityFrameworkCore;

namespace Judo.Models.Mapped
{
    public interface IJudoDBContext
    {
        DbSet<Characteristics> Characteristics { get; set; }
        DbSet<CharacteristicToStudent> CharacteristicToStudent { get; set; }
        DbSet<CharacteristicType> CharacteristicType { get; set; }
        DbSet<Disciplines> Disciplines { get; set; }
        DbSet<Exercises> Exercises { get; set; }
        DbSet<ExerciseSections> ExerciseSections { get; set; }
        DbSet<Groups> Groups { get; set; }
        DbSet<GroupsToExercise> GroupsToExercise { get; set; }
        DbSet<People> People { get; set; }
        DbSet<Ranks> Ranks { get; set; }
        DbSet<Students> Students { get; set; }
        DbSet<StudentsToGroup> StudentsToGroup { get; set; }
        DbSet<Units> Units { get; set; }
        DbSet<Users> Users { get; set; }

        int SaveChanges();
    }
}
