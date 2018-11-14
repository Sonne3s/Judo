using Judo.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Judo.Repository.Concrete.Fake
{
    public class FakeSportKing
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FakeTrainingSection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public List<FakeExercise> Exercises { get; set; }
    }

    public class FakeExercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
        public int Quantity { get; set; }
    }

    public class _FakeTrainingSection
    {
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public List<FakeExercise> Exercises { get; set; }
    }

    public class FakeTraining
    {
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public List<FakeTrainingSection> Sections { get; set; }
    }

    public static class Curriculum
    {
        public static List<FakeExercise> Exercises { get; set; }
        public static List<FakeTraining> Trainings { get; set; }
        public static List<FakeTrainingSection> Sections { get; set; }
        public static _FakeTrainingSection _Sections { get; set; }
        public static List<FakeSportKing> SportKinds { get; set; }

        static Curriculum()
        {
            Exercises = new List<FakeExercise>() { new FakeExercise() { Id = 1, Duration = new TimeSpan(0, 10, 0), Name = "Разминка стоя" }, new FakeExercise() { Id = 2, Duration = new TimeSpan(0, 5, 0), Name = "Разминка лежа" } };
            _Sections = new _FakeTrainingSection() {Id = 1, Exercises = Exercises };
            Sections = new List<FakeTrainingSection>() { new FakeTrainingSection() {Id = 1, Duration = new TimeSpan(0, 10, 0), Name = "Разминка стоя", Exercises = Exercises }, new FakeTrainingSection() {Id = 2, Duration = new TimeSpan(0, 5, 0), Name = "Разминка лежа", Exercises = Exercises} };
            Trainings = new List<FakeTraining>() { new FakeTraining() {Id = 1, Sections = Sections }, new FakeTraining() {Id = 2, Sections = Sections } };
            SportKinds = new List<FakeSportKing>() { new FakeSportKing() { Id = 1, Name = "Дзюдо" } };
        }

        public static void AddTraining(FakeTraining _training)
        {
            var training = Trainings.FirstOrDefault(t => t.Id == _training.Id);
            training = _training;
        }

        public static List<FakeSportKing> GetSportKinds()
        {
            return SportKinds;
        }
    }
}