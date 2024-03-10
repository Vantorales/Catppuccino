use CatpuccinoDB;

drop table if exists Usuarios;

create table Usuarios (
    Id int identity(1,1) primary key,
    Nombre varchar(40),
    Apellido varchar(40),
    Nickname varchar(40),
    Password varchar(40),
    Mail varchar(40),
    InfusionFavorita varchar(60)
	);

drop table if exists Venta;

create table Venta (
    Id int identity(1,1) primary key,
    Comentarios varchar(100),
    IdUsuario int,
    Total int,
    Descuento int
	);

drop table if exists ProductoVendido;

create table ProductoVendido (
    Id int identity(1,1) primary key,
    IdProducto int,
    Stock int,
    IdVenta int
	);

drop table if exists Producto;

create table Producto (
    Id int identity(1,1) primary key,
    TipoInfusion varchar(40),
    Descripcion varchar(40),
    Precio int,
    Stock int,
    IdUsuario int
);


insert into Usuarios (Nombre, Apellido, Nickname, Password, Mail, InfusionFavorita)
values ('Cesar', 'Romulo', 'cesarito', 'argentina2023', 'romulo_cesi@gmail.com', 'macchiato');

select * from Usuarios;

delete Usuarios
where Nombre = 'Amalia';
