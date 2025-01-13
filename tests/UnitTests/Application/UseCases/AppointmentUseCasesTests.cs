using Application.UseCases.medical.Appointment;
using Domain.Entities.newEntities;
using Moq;
using Application.Interfaces.Repositories;
using Application.Interfaces.Service;
namespace UnitTests.Application.UseCases;
public class AppointmentUseCasesTests
{
    private readonly Mock<IAppointmentRepository> _appointmentRepositoryMock;
    private readonly Mock<IEmailService> _emailServiceMock;

    public AppointmentUseCasesTests()
    {
        _appointmentRepositoryMock = new Mock<IAppointmentRepository>();
        _emailServiceMock = new Mock<IEmailService>();
    }


    [Fact]
    public async Task CreateAppointmentUseCase_Should_Create_Appointment_And_Send_Email()
    {
        // Arrange
        var appointment = new Appointment
        {
            Patient = new Patient { Name = "John Doe", Email = "johndoe@example.com" },
            Doctor = new Doctor { Name = "Dr. Smith" },
            Date = DateTime.Now.AddDays(1)
        };

        var useCase = new CreateAppointmentUseCase(_appointmentRepositoryMock.Object, _emailServiceMock.Object);

        _appointmentRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Appointment>())).Returns(Task.CompletedTask);
        _emailServiceMock.Setup(service => service.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);

        // Act
        await useCase.ExecuteAsync(appointment);

        // Assert
        _appointmentRepositoryMock.Verify(repo => repo.AddAsync(appointment), Times.Once);
        _emailServiceMock.Verify(service => service.SendEmailAsync(
            appointment.Patient.Email,
            "Lembrete de Consulta Médica",
            $"Olá {appointment.Patient.Name}, você tem uma consulta agendada com o Dr(a). {appointment.Doctor.Name} no dia {appointment.Date}."
        ), Times.Once);
    }

    [Fact]
    public async Task DeleteAppointmentUseCase_Should_Delete_Appointment()
    {
        // Arrange
        int appointmentId = 1;
        var useCase = new DeleteAppointmentUseCase(_appointmentRepositoryMock.Object);

        _appointmentRepositoryMock.Setup(repo => repo.DeleteAsync(It.IsAny<int>())).Returns(Task.CompletedTask);

        // Act
        await useCase.ExecuteAsync(appointmentId);

        // Assert
        _appointmentRepositoryMock.Verify(repo => repo.DeleteAsync(appointmentId), Times.Once);
    }
}


