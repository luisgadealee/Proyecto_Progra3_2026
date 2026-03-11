-- =====================================================================
-- SCRIPT : AlquilerVehiculos.sql
-- SISTEMA: Sistema de Alquiler de Vehiculos
-- MOTOR  : SQL Server (localhost)
-- AUTOR  : Ingenieria en Sistemas - Proyecto Final - Luis Fernando Gadea Lee
-- =====================================================================


-- =====================================================================
-- PASO 1: Crear la base de datos
-- =====================================================================

USE master;
GO

-- La idea es buscar la base de datos si existe, y borrarla para volverla a crear
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'AlquilerVehiculos')
BEGIN
    -- Forzar cierre de conexiones activas antes de eliminar
    ALTER DATABASE AlquilerVehiculos SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE AlquilerVehiculos;
END
GO

CREATE DATABASE AlquilerVehiculos;
GO

USE AlquilerVehiculos;
GO


-- =====================================================================
-- PASO 2: Tablas Sub Tablas
-- Se crean primero porque las tablas principales necesitan referencias
-- =====================================================================

-- ---------------------------------------------------------------------
-- Tabla: Roles
-- Almacena los roles disponibles del sistema.
-- Valores iniciales: Administrador, Cliente, SuperUsuario, Vendedor
-- ---------------------------------------------------------------------
CREATE TABLE Roles
(
    RolId      INT          NOT NULL IDENTITY(1,1),
    NombreRol  VARCHAR(50)  NOT NULL,

    CONSTRAINT PK_Roles        PRIMARY KEY (RolId),
    CONSTRAINT UQ_Roles_Nombre UNIQUE      (NombreRol)
);
GO

-- ---------------------------------------------------------------------
-- Tabla: TiposVehiculo
-- Clasifica los vehiculos por categoria.
-- Valores iniciales: Sedan, SUV, Camioneta, Pick-up, Deportivo
-- ---------------------------------------------------------------------
CREATE TABLE TiposVehiculo
(
    TipoId      INT          NOT NULL IDENTITY(1,1),
    NombreTipo  VARCHAR(50)  NOT NULL,

    CONSTRAINT PK_TiposVehiculo        PRIMARY KEY (TipoId),
    CONSTRAINT UQ_TiposVehiculo_Nombre UNIQUE      (NombreTipo)
);
GO

-- ---------------------------------------------------------------------
-- Tabla: EstadosVehiculo
-- Controla la disponibilidad de cada vehiculo.
-- Valores iniciales: Disponible, Alquilado, Mantenimiento
-- ---------------------------------------------------------------------
CREATE TABLE EstadosVehiculo
(
    EstadoId      INT          NOT NULL IDENTITY(1,1),
    NombreEstado  VARCHAR(30)  NOT NULL,

    CONSTRAINT PK_EstadosVehiculo        PRIMARY KEY (EstadoId),
    CONSTRAINT UQ_EstadosVehiculo_Nombre UNIQUE      (NombreEstado)
);
GO

-- ---------------------------------------------------------------------
-- Tabla: TiposTarifa
-- Define los tipos de tarifa que puede tener un vehiculo.
-- Valores iniciales: Por Dia, Semanal, Quince Dias, mes
-- ---------------------------------------------------------------------
CREATE TABLE TiposTarifa
(
    TipoTarifaId  INT          NOT NULL IDENTITY(1,1),
    NombreTarifa  VARCHAR(30)  NOT NULL,

    CONSTRAINT PK_TiposTarifa        PRIMARY KEY (TipoTarifaId),
    CONSTRAINT UQ_TiposTarifa_Nombre UNIQUE      (NombreTarifa)
);
GO

-- ---------------------------------------------------------------------
-- Tabla: EstadosAlquiler
-- Controla el ciclo de vida de un alquiler.
-- Valores iniciales: Pendiente, Aprobado, Rechazado, Cerrado
-- ---------------------------------------------------------------------
CREATE TABLE EstadosAlquiler
(
    EstadoId      INT          NOT NULL IDENTITY(1,1),
    NombreEstado  VARCHAR(30)  NOT NULL,

    CONSTRAINT PK_EstadosAlquiler        PRIMARY KEY (EstadoId),
    CONSTRAINT UQ_EstadosAlquiler_Nombre UNIQUE      (NombreEstado)
);
GO


-- =====================================================================
-- PASO 3: Tablas principales
-- =====================================================================

-- ---------------------------------------------------------------------
-- Tabla: Usuarios
-- Almacena clientes y administradores del sistema.
-- El campo Contrasenia guarda el hash, nunca texto plano.
-- El campo Activo permite desactivar usuarios sin eliminarlos.
-- ---------------------------------------------------------------------
CREATE TABLE Usuarios
(
    UsuarioId      INT           NOT NULL IDENTITY(1,1),
    Nombre         VARCHAR(100)  NOT NULL,
    Apellido       VARCHAR(100)  NOT NULL,
    Cedula         VARCHAR(20)   NOT NULL,
    Email          VARCHAR(150)  NOT NULL,
    NombreUsuario  VARCHAR(50)   NOT NULL,
    Contrasenia    VARCHAR(255)  NOT NULL,
    RolId          INT           NOT NULL,
    FechaRegistro  DATETIME      NOT NULL DEFAULT GETDATE(),
    Activo         BIT           NOT NULL DEFAULT 1,

    CONSTRAINT PK_Usuarios               PRIMARY KEY (UsuarioId),
    CONSTRAINT UQ_Usuarios_Cedula        UNIQUE      (Cedula),
    CONSTRAINT UQ_Usuarios_Email         UNIQUE      (Email),
    CONSTRAINT UQ_Usuarios_NombreUsuario UNIQUE      (NombreUsuario),
    CONSTRAINT FK_Usuarios_Roles         FOREIGN KEY (RolId)
        REFERENCES Roles(RolId)
);
GO

-- ---------------------------------------------------------------------
-- Tabla: Telefonos
-- Registro los telefonos de los usuarios.
-- ---------------------------------------------------------------------
CREATE TABLE Telefonos
(
    TelefonoId  INT          NOT NULL IDENTITY(1,1),
    UsuarioId   INT          NOT NULL,
    Numero      VARCHAR(20)  NOT NULL,

    CONSTRAINT PK_Telefonos          PRIMARY KEY (TelefonoId),
    CONSTRAINT FK_Telefonos_Usuarios FOREIGN KEY (UsuarioId)
        REFERENCES Usuarios(UsuarioId)
);
GO

-- ---------------------------------------------------------------------
-- Tabla: Vehiculos
-- Registro del inventario de vehiculos de la empresa.
-- El campo Activo permite desactivar vehiculos sin eliminarlos.
-- ---------------------------------------------------------------------
CREATE TABLE Vehiculos
(
    VehiculoId  INT          NOT NULL IDENTITY(1,1),
    Placa       VARCHAR(20)  NOT NULL,
    Marca       VARCHAR(50)  NOT NULL,
    Modelo      VARCHAR(50)  NOT NULL,
    Anio        INT          NOT NULL,
    TipoId      INT          NOT NULL,
    EstadoId    INT          NOT NULL,
    Activo      BIT          NOT NULL DEFAULT 1,

    CONSTRAINT PK_Vehiculos        PRIMARY KEY (VehiculoId),
    CONSTRAINT UQ_Vehiculos_Placa  UNIQUE      (Placa),
    CONSTRAINT FK_Vehiculos_Tipo   FOREIGN KEY (TipoId)
        REFERENCES TiposVehiculo(TipoId),
    CONSTRAINT FK_Vehiculos_Estado FOREIGN KEY (EstadoId)
        REFERENCES EstadosVehiculo(EstadoId)
);
GO

-- ---------------------------------------------------------------------
-- Tabla: Tarifas
-- Cada vehiculo puede tener multiples tarifas segun el tipo.
-- ---------------------------------------------------------------------
CREATE TABLE Tarifas
(
    TarifaId      INT            NOT NULL IDENTITY(1,1),
    VehiculoId    INT            NOT NULL,
    TipoTarifaId  INT            NOT NULL,
    Monto         DECIMAL(10,2)  NOT NULL,

    CONSTRAINT PK_Tarifas              PRIMARY KEY (TarifaId),
    CONSTRAINT UQ_Tarifas_VehiculoTipo UNIQUE      (VehiculoId, TipoTarifaId),
    CONSTRAINT FK_Tarifas_Vehiculos    FOREIGN KEY (VehiculoId)
        REFERENCES Vehiculos(VehiculoId),
    CONSTRAINT FK_Tarifas_TiposTarifa  FOREIGN KEY (TipoTarifaId)
        REFERENCES TiposTarifa(TipoTarifaId)
);
GO

-- ---------------------------------------------------------------------
-- Tabla: Alquileres
-- Registro central del sistema. Vincula usuario, vehiculo y tarifa.
-- FechaDevolucion es NULL hasta que el administrador registre
-- la devolucion del vehiculo.
-- ---------------------------------------------------------------------
CREATE TABLE Alquileres
(
    AlquilerId       INT            NOT NULL IDENTITY(1,1),
    UsuarioId        INT            NOT NULL,
    VehiculoId       INT            NOT NULL,
    TarifaId         INT            NOT NULL,
    EstadoId         INT            NOT NULL,
    FechaInicio      DATETIME       NOT NULL,
    FechaFinPactada  DATETIME       NOT NULL,
    FechaDevolucion  DATETIME           NULL,
    TieneDanios      BIT            NOT NULL DEFAULT 0,
    CostoDanios      DECIMAL(10,2)  NOT NULL DEFAULT 0,
    MultaRetraso     DECIMAL(10,2)  NOT NULL DEFAULT 0,

    CONSTRAINT PK_Alquileres           PRIMARY KEY (AlquilerId),
    CONSTRAINT FK_Alquileres_Usuarios  FOREIGN KEY (UsuarioId)
        REFERENCES Usuarios(UsuarioId),
    CONSTRAINT FK_Alquileres_Vehiculos FOREIGN KEY (VehiculoId)
        REFERENCES Vehiculos(VehiculoId),
    CONSTRAINT FK_Alquileres_Tarifas   FOREIGN KEY (TarifaId)
        REFERENCES Tarifas(TarifaId),
    CONSTRAINT FK_Alquileres_Estados   FOREIGN KEY (EstadoId)
        REFERENCES EstadosAlquiler(EstadoId)
);
GO

-- ---------------------------------------------------------------------
-- Tabla: Pagos
-- Registra el pago generado al cerrar un alquiler.
-- EstadoPago: 'Pendiente' cuando se genera, 'Pagado' al confirmar.
-- ---------------------------------------------------------------------
CREATE TABLE Pagos
(
    PagoId      INT            NOT NULL IDENTITY(1,1),
    AlquilerId  INT            NOT NULL,
    Monto       DECIMAL(10,2)  NOT NULL,
    FechaPago   DATETIME       NOT NULL DEFAULT GETDATE(),
    EstadoPago  VARCHAR(20)    NOT NULL DEFAULT 'Pendiente',

    CONSTRAINT PK_Pagos            PRIMARY KEY (PagoId),
    CONSTRAINT FK_Pagos_Alquileres FOREIGN KEY (AlquilerId)
        REFERENCES Alquileres(AlquilerId)
);
GO


-- =====================================================================
-- PASO 4: Datos de sub Tablas
-- Valores fijos que el sistema necesita para funcionar.
-- Estos NO cambian durante el uso normal del sistema.
-- =====================================================================

INSERT INTO Roles (NombreRol) VALUES
    ('Cliente'),
    ('Vendedor'),
    ('Administrador'),
    ('SuperUsuario');

INSERT INTO TiposVehiculo (NombreTipo) VALUES
    ('Sedan'),
    ('SUV'),
    ('Camioneta'),
    ('Pick-up'),
    ('Deportivo');

INSERT INTO EstadosVehiculo (NombreEstado) VALUES
    ('Disponible'),
    ('Alquilado'),
    ('Mantenimiento');

INSERT INTO TiposTarifa (NombreTarifa) VALUES
    ('Diaria'),
    ('Semanal'),
    ('FinDeSemana'),
    ('Quince Dias'),
    ('Mes');

INSERT INTO EstadosAlquiler (NombreEstado) VALUES
    ('Pendiente'),
    ('Aprobado'),
    ('Rechazado'),
    ('Cerrado');
GO


-- =====================================================================
-- PASO 5: Datos de prueba
-- =====================================================================

INSERT INTO Usuarios (Nombre, Apellido, Cedula, Email, NombreUsuario, Contrasenia, RolId) VALUES
    ('Carlos',  'Mendoza',   '101110111', 'carlos.admin@alquiler.com',   'carlos.admin',   'Admin123!',    3),
    ('Ana',     'Rodriguez', '202220222', 'ana.cliente@gmail.com',       'ana.rodriguez',  'Cliente123!',  1),
    ('Luis',    'Perez',     '303330333', 'luis.cliente@gmail.com',      'luis.perez',     'Cliente123!',  1),
    ('Maria',   'Gonzalez',  '404440444', 'maria.cliente@gmail.com',     'maria.gonzalez', 'Cliente123!',  1),
    ('Pedro',   'Vargas',    '505550555', 'pedro.vendedor@alquiler.com', 'pedro.vendedor', 'Vendedor123!', 2),
    ('Roberto', 'Super',     '606660666', 'roberto.super@alquiler.com',  'roberto.super',  'Super123!',    4),
    ('Luis', 'Gadea',     '117260789', 'lgadea@gmail.com',  'luis.super',  'Luis123!',    4);
GO

INSERT INTO Telefonos (UsuarioId, Numero) VALUES
    (1, '8888-1111'),
    (2, '8888-2222'),
    (2, '7777-2222'),
    (3, '8888-3333'),
    (5, '8888-5555');
GO

INSERT INTO Vehiculos (Placa, Marca, Modelo, Anio, TipoId, EstadoId) VALUES
    ('ABC-123', 'Toyota',    'Corolla', 2022, 1, 1),
    ('DEF-456', 'Honda',     'CR-V',    2023, 2, 1),
    ('GHI-789', 'Ford',      'F-150',   2021, 4, 1),
    ('JKL-012', 'Chevrolet', 'Tahoe',   2022, 2, 2),
    ('MNO-345', 'Toyota',    'Hilux',   2023, 3, 1),
    ('PQR-678', 'Mazda',     'MX-5',    2023, 5, 3);
GO

INSERT INTO Tarifas (VehiculoId, TipoTarifaId, Monto) VALUES
    -- Toyota Corolla
    (1, 1,   45.00),   -- Diaria
    (1, 2,  280.00),   -- Semanal
    (1, 3,   90.00),   -- FinDeSemana
    (1, 4,  500.00),   -- Quince Dias
    (1, 5,  900.00),   -- Mes
    -- Honda CR-V
    (2, 1,   65.00),
    (2, 2,  400.00),
    (2, 3,  130.00),
    (2, 4,  750.00),
    (2, 5, 1300.00),
    -- Ford F-150
    (3, 1,   80.00),
    (3, 2,  500.00),
    (3, 4,  900.00),
    (3, 5, 1600.00),
    -- Chevrolet Tahoe
    (4, 1,   90.00),
    (4, 2,  560.00),
    (4, 3,  180.00),
    (4, 4, 1000.00),
    (4, 5, 1800.00),
    -- Toyota Hilux
    (5, 1,   75.00),
    (5, 2,  460.00),
    (5, 4,  850.00),
    (5, 5, 1500.00),
    -- Mazda MX-5
    (6, 1,   95.00),
    (6, 3,  190.00),
    (6, 5, 2000.00);
GO

INSERT INTO Alquileres
    (UsuarioId, VehiculoId, TarifaId, EstadoId, FechaInicio, FechaFinPactada, FechaDevolucion, TieneDanios, CostoDanios, MultaRetraso)
VALUES
    (2, 1, 1, 4, '2026-01-10', '2026-01-15', '2026-01-15', 0, 0.00,  0.00),
    (3, 4, 9, 2, '2026-02-20', '2026-03-01',  NULL,         0, 0.00,  0.00),
    (4, 2, 4, 1, '2026-03-05', '2026-03-10',  NULL,         0, 0.00,  0.00),
    (2, 3, 7, 4, '2026-01-20', '2026-01-25', '2026-01-28', 0, 0.00, 75.00);
GO

INSERT INTO Pagos (AlquilerId, Monto, FechaPago, EstadoPago) VALUES
    (1, 225.00, '2026-01-15', 'Pagado'),
    (4, 475.00, '2026-01-28', 'Pagado');
GO


-- =====================================================================
-- PASO 6: Verificacion
-- =====================================================================

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;

SELECT u.NombreUsuario, u.Nombre, u.Apellido, u.Cedula, r.NombreRol
FROM Usuarios u
INNER JOIN Roles r ON u.RolId = r.RolId;

SELECT u.Nombre, u.Apellido, t.Numero
FROM Telefonos t
INNER JOIN Usuarios u ON t.UsuarioId = u.UsuarioId;

SELECT v.Placa, v.Marca, v.Modelo, v.Anio,
       tp.NombreTipo   AS Tipo,
       ev.NombreEstado AS Estado
FROM Vehiculos v
INNER JOIN TiposVehiculo   tp ON v.TipoId   = tp.TipoId
INNER JOIN EstadosVehiculo ev ON v.EstadoId = ev.EstadoId;

SELECT a.AlquilerId,
       u.NombreUsuario,
       v.Placa,
       ea.NombreEstado AS EstadoAlquiler,
       a.FechaInicio,
       a.FechaFinPactada,
       a.FechaDevolucion
FROM Alquileres a
INNER JOIN Usuarios        u  ON a.UsuarioId  = u.UsuarioId
INNER JOIN Vehiculos       v  ON a.VehiculoId = v.VehiculoId
INNER JOIN EstadosAlquiler ea ON a.EstadoId   = ea.EstadoId;
GO


-- =====================================================================
-- PASO 7: Crear usuario de SQL Server para la aplicacion
-- =====================================================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.server_principals WHERE name = 'usuario12')
    DROP LOGIN usuario12;
GO

CREATE LOGIN usuario12
    WITH PASSWORD    = 'Alquiler2026!',
         CHECK_POLICY = OFF;
GO

USE AlquilerVehiculos;
GO

IF EXISTS (SELECT name FROM sys.database_principals WHERE name = 'usuario12')
    DROP USER usuario12;
GO

CREATE USER usuario12 FOR LOGIN usuario12;
GO

ALTER ROLE db_datareader ADD MEMBER usuario12;
ALTER ROLE db_datawriter ADD MEMBER usuario12;
GO

SELECT
    dp.name       AS Usuario,
    dp.type_desc  AS TipoUsuario,
    r.name        AS Rol
FROM sys.database_role_members rm
INNER JOIN sys.database_principals dp ON rm.member_principal_id = dp.principal_id
INNER JOIN sys.database_principals r  ON rm.role_principal_id   = r.principal_id
WHERE dp.name = 'usuario12';
GO
