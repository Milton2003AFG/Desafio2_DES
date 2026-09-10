CREATE DATABASE Desafio2DB;
GO

USE Desafio2DB;
GO

-- 1. Tabla Instructor
CREATE TABLE Instructor (
    IdInstructor INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Especialidad VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL
);
GO

-- 2. Tabla Curso
CREATE TABLE Curso (
    IdCurso INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(150) NOT NULL,
    Descripcion VARCHAR(300) NOT NULL,
    Nivel VARCHAR(50) NOT NULL, -- Básico, Intermedio, Avanzado
    IdInstructor INT NOT NULL,
    CONSTRAINT FK_Curso_Instructor FOREIGN KEY (IdInstructor) 
        REFERENCES Instructor(IdInstructor) ON DELETE CASCADE
);
GO

-- 3. Tabla Estudiante
CREATE TABLE Estudiante (
    IdEstudiante INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL
);
GO

-- 4. Tabla Inscripcion
CREATE TABLE Inscripcion (
    IdInscripcion INT IDENTITY(1,1) PRIMARY KEY,
    FechaInscripcion DATE NOT NULL,
    IdEstudiante INT NOT NULL,
    IdCurso INT NOT NULL,
    CONSTRAINT FK_Inscripcion_Estudiante FOREIGN KEY (IdEstudiante) 
        REFERENCES Estudiante(IdEstudiante) ON DELETE CASCADE,
    CONSTRAINT FK_Inscripcion_Curso FOREIGN KEY (IdCurso) 
        REFERENCES Curso(IdCurso) ON DELETE CASCADE,
    CONSTRAINT UQ_Estudiante_Curso UNIQUE (IdEstudiante, IdCurso)
);
GO

-- Datos iniciales para pruebas
INSERT INTO Instructor (Nombre, Especialidad, Email) VALUES 
('Carlos Mendoza', 'Arquitectura de Software', 'carlos.mendoza@udb.edu.sv'),
('Ana Rivas', 'Bases de Datos', 'ana.rivas@udb.edu.sv');

INSERT INTO Curso (Titulo, Descripcion, Nivel, IdInstructor) VALUES 
('Desarrollo .NET Core', 'Curso completo de ASP.NET Core', 'Intermedio', 1),
('SQL Server Avanzado', 'Optimización e índices', 'Avanzado', 2);

INSERT INTO Estudiante (Nombre, Email, FechaNacimiento) VALUES 
('Juan Perez', 'juan.perez@correo.com', '2001-05-15'),
('Maria Lopez', 'maria.lopez@correo.com', '2002-10-20');

INSERT INTO Inscripcion (FechaInscripcion, IdEstudiante, IdCurso) VALUES 
('2026-02-10', 1, 1);
GO