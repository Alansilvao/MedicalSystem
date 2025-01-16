USE MedicalSystem

GO

-- Tabela de Pacientes
CREATE TABLE Patients (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    IsDeleted BIT NOT NULL DEFAULT 0
);

-- Tabela de Médicos
CREATE TABLE Doctors (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Specialty NVARCHAR(100) NOT NULL
);

-- Tabela de Consultas
CREATE TABLE Appointments (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PatientId INT NOT NULL,
    DoctorId INT NOT NULL,
    Date DATETIME NOT NULL,
    IsCanceled BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Appointments_Patients FOREIGN KEY (PatientId)
        REFERENCES Patients(Id) ,
    CONSTRAINT FK_Appointments_Doctors FOREIGN KEY (DoctorId)
        REFERENCES Doctors(Id) 
);

-- Índices
CREATE INDEX IDX_Patient_Email ON Patients(Email);
CREATE INDEX IDX_Doctor_Specialty ON Doctors(Specialty);