-- =====================================================================
-- SCRIPT : AlquilerVehiculos.sql
-- SISTEMA: Sistema de Alquiler de Vehiculos
-- MOTOR  : SQL Server (localhost)
-- AUTOR  : Ingenieria en Sistemas - Proyecto Final - Luis Fernando Gadea Lee
-- =====================================================================

-- =====================================================================
-- PASO 1: Crear la base de datos
-- =====================================================================

use master;
go

-- la idea es buscar la base de datos si existe, y borrarla para volverla a crear
if exists (select name from sys.databases where name = 'AlquilerVehiculos')
begin
    -- forzar cierre de conexiones activas antes de eliminar
    alter database AlquilerVehiculos set single_user with rollback immediate;
    drop database AlquilerVehiculos;
end
go

create database AlquilerVehiculos;
go

use AlquilerVehiculos;
go

-- =====================================================================
-- PASO 2: Tablas Sub Tablas
-- se crean primero porque las tablas principales necesitan referencias
-- =====================================================================

-- ---------------------------------------------------------------------
-- tabla: Roles
-- ---------------------------------------------------------------------
create table Roles
(
    RolId       int         not null identity(1,1),
    NombreRol   varchar(50) not null,

    constraint pk_Roles        primary key (RolId),
    constraint uq_Roles_Nombre unique      (NombreRol)
);
go

-- ---------------------------------------------------------------------
-- tabla: TiposVehiculo
-- ---------------------------------------------------------------------
create table TiposVehiculo
(
    TipoId      int         not null identity(1,1),
    NombreTipo  varchar(50) not null,

    constraint pk_TiposVehiculo        primary key (TipoId),
    constraint uq_TiposVehiculo_Nombre unique      (NombreTipo)
);
go

-- ---------------------------------------------------------------------
-- tabla: EstadosVehiculo
-- ---------------------------------------------------------------------
create table EstadosVehiculo
(
    EstadoId      int         not null identity(1,1),
    NombreEstado  varchar(30) not null,

    constraint pk_EstadosVehiculo        primary key (EstadoId),
    constraint uq_EstadosVehiculo_Nombre unique      (NombreEstado)
);
go

-- ---------------------------------------------------------------------
-- tabla: TiposTarifa
-- ---------------------------------------------------------------------
create table TiposTarifa
(
    TipoTarifaId  int         not null identity(1,1),
    NombreTarifa  varchar(30) not null,

    constraint pk_TiposTarifa        primary key (TipoTarifaId),
    constraint uq_TiposTarifa_Nombre unique      (NombreTarifa)
);
go

-- ---------------------------------------------------------------------
-- tabla: EstadosAlquiler
-- ---------------------------------------------------------------------
create table EstadosAlquiler
(
    EstadoId      int         not null identity(1,1),
    NombreEstado  varchar(30) not null,

    constraint pk_EstadosAlquiler        primary key (EstadoId),
    constraint uq_EstadosAlquiler_Nombre unique      (NombreEstado)
);
go

-- =====================================================================
-- PASO 3: Tablas principales
-- =====================================================================

-- ---------------------------------------------------------------------
-- tabla: Usuarios
-- ---------------------------------------------------------------------
create table Usuarios
(
    UsuarioId      int           not null identity(1,1),
    Nombre         varchar(100)  not null,
    Apellido       varchar(100)  not null,
    Cedula         varchar(20)   not null,
    Email          varchar(150)  not null,
    NombreUsuario  varchar(50)   not null,
    Contrasenia    varchar(255)  not null,
    RolId          int           not null,
    FechaRegistro  datetime      not null default getdate(),
    Activo         bit           not null default 1,

    constraint pk_Usuarios                primary key (UsuarioId),
    constraint uq_Usuarios_Cedula         unique      (Cedula),
    constraint uq_Usuarios_Email          unique      (Email),
    constraint uq_Usuarios_NombreUsuario  unique      (NombreUsuario),
    constraint fk_Usuarios_Roles          foreign key (RolId) 
        references Roles(RolId)
);
go

-- ---------------------------------------------------------------------
-- tabla: Telefonos
-- ---------------------------------------------------------------------
create table Telefonos
(
    TelefonoId  int         not null identity(1,1),
    UsuarioId   int         not null,
    Numero      varchar(20) not null,

    constraint pk_Telefonos          primary key (TelefonoId),
    constraint fk_Telefonos_Usuarios foreign key (UsuarioId) 
        references Usuarios(UsuarioId)
);
go

-- ---------------------------------------------------------------------
-- tabla: Vehiculos
-- ---------------------------------------------------------------------
create table Vehiculos
(
    VehiculoId  int         not null identity(1,1),
    Placa       varchar(20) not null,
    Marca       varchar(50) not null,
    Modelo      varchar(50) not null,
    Anio        int         not null,
    TipoId      int         not null,
    EstadoId    int         not null,
    Activo      bit         not null default 1,

    constraint pk_Vehiculos        primary key (VehiculoId),
    constraint uq_Vehiculos_Placa  unique      (Placa),
    constraint fk_Vehiculos_Tipo   foreign key (TipoId) 
        references TiposVehiculo(TipoId),
    constraint fk_Vehiculos_Estado foreign key (EstadoId) 
        references EstadosVehiculo(EstadoId)
);
go

-- ---------------------------------------------------------------------
-- tabla: Tarifas
-- ---------------------------------------------------------------------
create table Tarifas
(
    TarifaId      int            not null identity(1,1),
    VehiculoId    int            not null,
    TipoTarifaId  int            not null,
    Monto         decimal(10,2)  not null,

    constraint pk_Tarifas                  primary key (TarifaId),
    constraint uq_Tarifas_VehiculoTipo     unique      (VehiculoId, TipoTarifaId),
    constraint fk_Tarifas_Vehiculos        foreign key (VehiculoId) 
        references Vehiculos(VehiculoId),
    constraint fk_Tarifas_TiposTarifa      foreign key (TipoTarifaId) 
        references TiposTarifa(TipoTarifaId)
);
go

-- ---------------------------------------------------------------------
-- tabla: Alquileres
-- ---------------------------------------------------------------------
create table Alquileres
(
    AlquilerId       int            not null identity(1,1),
    UsuarioId        int            not null,
    VehiculoId       int            not null,
    TarifaId         int            not null,
    EstadoId         int            not null,
    UsuarioAdminId   int                null,
    FechaInicio      datetime       not null,
    FechaFinPactada  datetime       not null,
    FechaDevolucion  datetime           null,
    TieneDanios      bit            not null default 0,
    CostoDanios      decimal(10,2)  not null default 0,
    MultaRetraso     decimal(10,2)  not null default 0,

    constraint pk_Alquileres          primary key (AlquilerId),
    constraint fk_Alquileres_Usuarios foreign key (UsuarioId) 
        references Usuarios(UsuarioId),
    constraint fk_Alquileres_Admin    foreign key (UsuarioAdminId) 
        references Usuarios(UsuarioId),
    constraint fk_Alquileres_Vehiculos foreign key (VehiculoId) 
        references Vehiculos(VehiculoId),
    constraint fk_Alquileres_Tarifas   foreign key (TarifaId) 
        references Tarifas(TarifaId),
    constraint fk_Alquileres_Estados   foreign key (EstadoId) 
        references EstadosAlquiler(EstadoId)
);
go

-- ---------------------------------------------------------------------
-- tabla: Pagos
-- ---------------------------------------------------------------------
create table Pagos
(
    PagoId      int            not null identity(1,1),
    AlquilerId  int            not null,
    Monto       decimal(10,2)  not null,
    FechaPago   datetime       not null default getdate(),
    EstadoPago  varchar(20)    not null default 'Pendiente',

    constraint pk_Pagos             primary key (PagoId),
    constraint fk_Pagos_Alquileres  foreign key (AlquilerId) 
        references Alquileres(AlquilerId)
);
go

-- =====================================================================
-- PASO 4: Datos de sub Tablas
-- =====================================================================

insert into Roles (NombreRol) values
    ('Cliente'),
    ('Vendedor'),
    ('Administrador'),
    ('SuperUsuario');

insert into TiposVehiculo (NombreTipo) values
    ('Sedan'),
    ('SUV'),
    ('Camioneta'),
    ('Pick-up'),
    ('Deportivo');

insert into EstadosVehiculo (NombreEstado) values
    ('Disponible'),
    ('Alquilado'),
    ('Mantenimiento');

insert into TiposTarifa (NombreTarifa) values
    ('Diaria'),
    ('Semanal'),
    ('FinDeSemana'),
    ('Quince Dias'),
    ('Mes');

insert into EstadosAlquiler (NombreEstado) values
    ('Pendiente'),
    ('Aprobado'),
    ('Rechazado'),
    ('Cerrado');
go

-- =====================================================================
-- PASO 5: Datos de prueba
-- =====================================================================

insert into Usuarios (Nombre, Apellido, Cedula, Email, NombreUsuario, Contrasenia, RolId) values
    ('Carlos',  'Mendoza',   '101110111', 'carlos.admin@alquiler.com',   'carlos.admin',   'Admin123!',    3),
    ('Ana',     'Rodriguez', '202220222', 'ana.cliente@gmail.com',       'ana.rodriguez',  'Cliente123!',  1),
    ('Luis',    'Perez',     '303330333', 'luis.cliente@gmail.com',      'luis.perez',     'Cliente123!',  1),
    ('Maria',   'Gonzalez',  '404440444', 'maria.cliente@gmail.com',     'maria.gonzalez', 'Cliente123!',  1),
    ('Pedro',   'Vargas',    '505550555', 'pedro.vendedor@alquiler.com', 'pedro.vendedor', 'Vendedor123!', 2),
    ('Roberto', 'Super',     '606660666', 'roberto.super@alquiler.com',  'roberto.super',  'Super123!',    4),
    ('Luis',    'Gadea',     '117260789', 'lgadea@gmail.com',            'luis.super',     'Luis123!',     4);
go

insert into Telefonos (UsuarioId, Numero) values
    (1, '8888-1111'),
    (2, '8888-2222'),
    (2, '7777-2222'),
    (3, '8888-3333'),
    (5, '8888-5555');
go

insert into Vehiculos (Placa, Marca, Modelo, Anio, TipoId, EstadoId) values
    ('ABC-123', 'Toyota',    'Corolla', 2022, 1, 1),
    ('DEF-456', 'Honda',     'CR-V',    2023, 2, 1),
    ('GHI-789', 'Ford',      'F-150',   2021, 4, 1),
    ('JKL-012', 'Chevrolet', 'Tahoe',   2022, 2, 2),
    ('MNO-345', 'Toyota',    'Hilux',   2023, 3, 1),
    ('PQR-678', 'Mazda',     'MX-5',    2023, 5, 3);
go

insert into Tarifas (VehiculoId, TipoTarifaId, Monto) values
    (1, 1,  45.00), (1, 2, 280.00), (1, 3,  90.00), (1, 4, 500.00), (1, 5, 900.00),
    (2, 1,  65.00), (2, 2, 400.00), (2, 3, 130.00), (2, 4, 750.00), (2, 5, 1300.00),
    (3, 1,  80.00), (3, 2, 500.00), (3, 4, 900.00), (3, 5, 1600.00),
    (4, 1,  90.00), (4, 2, 560.00), (4, 3, 180.00), (4, 4, 1000.00), (4, 5, 1800.00),
    (5, 1,  75.00), (5, 2, 460.00), (5, 4, 850.00), (5, 5, 1500.00),
    (6, 1,  95.00), (6, 3, 190.00), (6, 5, 2000.00);
go

-- Insertamos con UsuarioAdminId en null para el pendiente, y con valor 1 (Carlos Admin) para los procesados
insert into Alquileres
    (UsuarioId, VehiculoId, TarifaId, EstadoId, UsuarioAdminId, FechaInicio, FechaFinPactada, FechaDevolucion, TieneDanios, CostoDanios, MultaRetraso)
values
    (2, 1, 1, 4, 1,    '2026-01-10', '2026-01-15', '2026-01-15', 0, 0.00,  0.00),
    (3, 4, 9, 2, 1,    '2026-02-20', '2026-03-01',  null,        0, 0.00,  0.00),
    (4, 2, 4, 1, null, '2026-03-05', '2026-03-10',  null,        0, 0.00,  0.00),
    (2, 3, 7, 4, 1,    '2026-01-20', '2026-01-25', '2026-01-28', 0, 0.00, 75.00);
go

insert into Pagos (AlquilerId, Monto, FechaPago, EstadoPago) values
    (1, 225.00, '2026-01-15', 'Pagado'),
    (4, 475.00, '2026-01-28', 'Pagado');
go

-- =====================================================================
-- PASO 6: Verificacion
-- =====================================================================

select table_name
from information_schema.tables
where table_type = 'BASE TABLE'
order by table_name;
go

-- =====================================================================
-- PASO 7: Crear usuario de SQL Server para la aplicacion
-- =====================================================================

use master;
go

if exists (select name from sys.server_principals where name = 'usuario12')
    drop login usuario12;
go

create login usuario12
    with password     = 'Alquiler2026!',
         check_policy = off;
go

use AlquilerVehiculos;
go

if exists (select name from sys.database_principals where name = 'usuario12')
    drop user usuario12;
go

create user usuario12 for login usuario12;
go

alter role db_datareader add member usuario12;
alter role db_datawriter add member usuario12;
go