using Application.Interfaces.Repositories;
using Application.UseCases.medical.Doctor;
using Domain.Entities.newEntities;
using Moq;

namespace UnitTests.Application.UseCases
{
    public class DoctorUseCasesTests
    {
        private readonly Mock<IDoctorRepository> _doctorRepositoryMock;

        public DoctorUseCasesTests()
        {
            _doctorRepositoryMock = new Mock<IDoctorRepository>();
        }

        [Fact]
        public async Task CreateDoctorUseCase_Should_Create_Doctor()
        {
            // Arrange
            var doctor = new Doctor
            {
                Name = "Dr. Smith"
            };

            var useCase = new CreateDoctorUseCase(_doctorRepositoryMock.Object);

            _doctorRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Doctor>())).Returns(Task.CompletedTask);

            // Act
            await useCase.ExecuteAsync(doctor);

            // Assert
            _doctorRepositoryMock.Verify(repo => repo.AddAsync(doctor), Times.Once);
        }

        [Fact]
        public async Task DeleteDoctorUseCase_Should_Delete_Doctor()
        {
            // Arrange
            int doctorId = 1;
            var useCase = new DeleteDoctorUseCase(_doctorRepositoryMock.Object);

            _doctorRepositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

            // Act
            await useCase.ExecuteAsync(doctorId);

            // Assert
            _doctorRepositoryMock.Verify(repo => repo.DeleteAsync(doctorId), Times.Once);
        }
    }
}
