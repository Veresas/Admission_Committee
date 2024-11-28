using Contracts.Interfaces;
using Contracts.Models;
using FluentAssertions;
using Storege;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Storage.Test
{
    public class StorageUnitTest
    {
        private readonly IStudentStorage studentStorage;
        public StorageUnitTest()
        {
            studentStorage = new StudentStorage();

        }

        /// <summary>
        /// Проверка добавления <see cref="Student"/> в <see cref="StudentStorage"/>
        /// </summary>
        [Fact]
        public async Task addShould()
        {
            // Arrange
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
                Gender = Gender.Male,
                BirthDay = DateTime.Now,
                Education = EducationFrom.fullTime,
                MathScores = 100,
                ITScores = 10,
                RusScores = 60,
            };

            // Act
            var result = await studentStorage.Add(student);

            // Asset
            result.Should().Be(student);
        }

        /// <summary>
        /// Проверка получения пустого списка из <see cref="StudentStorage"/>
        /// </summary>
        [Fact]
        public async Task GetAllEmptiShould()
        {
            // Act
            var result = await studentStorage.GetAll();

            // Assert
            result.Should().NotBeNull().And.BeEmpty();
        }

        /// <summary>
        /// Проверка получения непустого списка из <see cref="StudentStorage"/>
        /// </summary>
        [Fact]
        public async Task GetSomeShould()
        {
            // Arrange
            await studentStorage.Add(new Student());

            await studentStorage.Add(new Student());

            // Act
            var result = await studentStorage.GetAll();

            // Asset
            result.Should().NotBeNull().And.HaveCount(2);
        }

        /// <summary>
        /// Проверка изменения <see cref="Student"/> в <see cref="StudentStorage"/>
        /// </summary>
        [Fact]
        public async Task EditShould()
        {
            // Arrange
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
                Gender = Gender.Male,
                BirthDay = DateTime.Now,
                Education = EducationFrom.fullTime,
                MathScores = 100,
                ITScores = 10,
                RusScores = 60,
            };

            await studentStorage.Add(student);

            var updateStudent = new Student()
            {
                Id = student.Id,
                Name = student.Name,
                Gender = Gender.Female,
                BirthDay = student.BirthDay,
                Education = student.Education,
                MathScores = student.MathScores,
                ITScores = student.ITScores,
                RusScores = student.RusScores,
            };


            // Act
            await studentStorage.Edit(updateStudent);

            // Asset
            var retrievedStudent = await studentStorage.GetAll();
            var result = retrievedStudent.FirstOrDefault(x => x.Id == updateStudent.Id);
            result.Should().NotBeNull();
            result.Gender.Should().Be(updateStudent.Gender);

        }

        /// <summary>
        /// Проверка удаления <see cref="Student"/> из <see cref="StudentStorage"/>
        /// </summary>
        [Fact]
        public async Task DeletShould()
        {
            // Arrange
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
                Gender = Gender.Male,
                BirthDay = DateTime.Now,
                Education = EducationFrom.fullTime,
                MathScores = 100,
                ITScores = 10,
                RusScores = 60,
            };

            await studentStorage.Add(student);

            // Act
            await studentStorage.Delete(student.Id);

            // Asset
            var retrievedStudent = await studentStorage.GetAll();
            var result = retrievedStudent.FirstOrDefault(x => x.Id == student.Id);
            result.Should().BeNull();
        }
    }

}


