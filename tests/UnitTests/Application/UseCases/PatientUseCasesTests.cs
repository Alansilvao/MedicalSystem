using Application.UseCases.medical.Patient;
using Domain.Entities.newEntities;
using Moq;
using Application.Interfaces.Repositories;
namespace UnitTests.Application.UseCases;
public class PatientUseCasesTests
{
    private readonly Mock<IPatientRepository> _patientRepositoryMock;

    public PatientUseCasesTests()
    {
        _patientRepositoryMock = new Mock<IPatientRepository>();
    }

    [Fact]
    public async Task CreatePatientUseCase_Should_Create_Patient()
    {
        // Arrange
        var patient = new Patient
        {
            Name = "Jane Doe",
            Email = "janedoe@example.com"
        };

        var useCase = new CreatePatientUseCase(_patientRepositoryMock.Object);

        _patientRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Patient>())).Returns(Task.CompletedTask);

        // Act
        await useCase.ExecuteAsync(patient);

        // Assert
        _patientRepositoryMock.Verify(repo => repo.AddAsync(patient), Times.Once);
    }

    [Fact]
    public async Task DeletePatientUseCase_Should_Delete_Patient()
    {
        // Arrange
        int patientId = 1;
        var useCase = new DeletePatientUseCase(_patientRepositoryMock.Object);

        _patientRepositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

        // Act
        await useCase.ExecuteAsync(patientId);

        // Assert
        _patientRepositoryMock.Verify(repo => repo.DeleteAsync(patientId), Times.Once);
    }

    [Fact]
    public async Task UpdatePatientUseCase_Should_Update_Patient()
    {
        // Arrange
        var patient = new Patient
        {
            Id = 1,
            Name = "Jane Doe",
            Email = "janedoe@example.com"
        };

        var useCase = new UpdatePatientUseCase(_patientRepositoryMock.Object);

        _patientRepositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Patient>())).Returns(Task.CompletedTask);

        // Act
        await useCase.ExecuteAsync(patient);

        // Assert
        _patientRepositoryMock.Verify(repo => repo.UpdateAsync(patient), Times.Once);
    }
}
