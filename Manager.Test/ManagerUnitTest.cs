using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Interfaces;
using Contracts.Models;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Manager.Test
{
    public class ManagerUnitTest
    {
        private readonly IStudentManager studentManager;
        private readonly Mock<IStudentStorage> storageMock;
        private readonly Mock<ILogger> loggerMock;

        /// <summary>
        /// <see cref="IStudentManager"/>
        /// </summary>
        public ManagerUnitTest()
        {
            storageMock = new Mock<IStudentStorage>();
            loggerMock = new Mock<ILogger>();

            loggerMock.Setup(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()));

            studentManager = new StudentManager(storageMock.Object, Mock.Of<ILogger>());
        }

        /// <summary>
        /// Проверка добавления <see cref="Student"/> в <see cref="IStudentStorage"/>
        /// </summary>
        [Fact]
        public async Task AddAsyncShould()
        {
            // Arrange
            var model = new Student()
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
            storageMock.Setup(x => x.Add(It.IsAny<Student>()))
                .ReturnsAsync(model);

            // Act
            var result = await studentManager.Add(model);

            // Asset
            loggerMock.VerifyNoOtherCalls();
            result.Should().NotBeNull()
                .And.Be(model);
            storageMock.Verify(x => x.Add(It.Is<Student>(y => y.Id == model.Id)),
                Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверка изменения <see cref="Student"/> в <see cref="IStudentStorage"/>
        /// </summary>
        [Fact]
        public async Task EditShould()
        {
            // Arrange
            var model = new Student()
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
            storageMock.Setup(x => x.Edit(It.IsAny<Student>()));

            // Act
            await studentManager.Edit(model);

            // Asset
            loggerMock.VerifyNoOtherCalls();
            storageMock.Verify(x => x.Edit(It.Is<Student>(y => y.Id == model.Id)),
                Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверка удаления <see cref="Student"/> из <see cref="IStudentStorage"/>
        /// </summary>
        [Fact]
        public async Task DeletShould()
        {
            // Arrange
            var model = new Student()
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
            storageMock.Setup(x => x.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            // Act
            var result = await studentManager.Delete(model.Id);

            // Asset

            result.Should().BeTrue();
            loggerMock.VerifyNoOtherCalls();
            storageMock.Verify(x => x.Delete(It.Is<Guid>(y => y == model.Id)),
                Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверка получения списка из <see cref="IStudentStorage"/>
        /// </summary>
        [Fact]
        public async Task GetSomeShould()
        {
            // Arrange
            Task<IReadOnlyCollection<Student>> model = Task.FromResult<IReadOnlyCollection<Student>>(
                new List<Student>
                {
                   new Student(),
                   new Student(),
                   new Student(),
                }
                );

            storageMock.Setup(x => x.GetAll()).Returns(model);

            // Act
            var result = await studentManager.GetAll();

            // Asset

            result.Should().HaveCount(3);
            loggerMock.VerifyNoOtherCalls();
            storageMock.Verify(x => x.GetAll(),
                Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверка получения нулевого списка из <see cref="IStudentStorage"/>
        /// </summary>
        [Fact]
        public async Task GetNullShould()
        {
            // Arrange
            Task<IReadOnlyCollection<Student>> model = Task.FromResult<IReadOnlyCollection<Student>>(
                new List<Student>());

            storageMock.Setup(x => x.GetAll()).Returns(model);

            // Act
            var result = await studentManager.GetAll();

            // Asset

            result.Should().BeEmpty();
            loggerMock.VerifyNoOtherCalls();
            storageMock.Verify(x => x.GetAll(),
                Times.Once);
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Проверка получения статистики из <see cref="IStudentStats"/>
        /// </summary>
        [Fact]
        public async Task GetStatsShould()
        {
            // Arrange
            Task<IReadOnlyCollection<Student>> model = Task.FromResult<IReadOnlyCollection<Student>>(
                new List<Student>
                {
                   new Student() {MathScores = 100, RusScores = 60, ITScores = 0},
                   new Student() {MathScores = 10, RusScores = 20, ITScores = 30},
                }
                );

            storageMock.Setup(x => x.GetAll()).Returns(model);

            // Act
            var result = await studentManager.GetStats();

            // Asset

            result.Should().BeEquivalentTo(new
            {
                AllStudent = 2,
                StudentWithEnoughScores = 1,
            });
            loggerMock.VerifyNoOtherCalls();
            storageMock.Verify(x => x.GetAll(),
                Times.Once);
            storageMock.VerifyNoOtherCalls();
        }
    }
}
