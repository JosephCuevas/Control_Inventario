create database Control_Inventario;

use Control_Inventario;

create table CAT_TipoProducto
(
	intTipoProductoID int IDENTITY,
	vchNombreTipoProducto varchar(30) null,
	vchDescripcionProducto varchar(50) null,
	constraint PK_CAT_TipoProducto primary key (intTipoProductoID)
)

go

create table CAT_Usuarios
(
	intUsuarioID int IDENTITY,
	vchNombreUsuario varchar(30) null,
	vchApellidoUsuario varchar(50) null,
	datFechaNacimientoUsuario datetime null,
	vchTelefonoUsuario varchar(20) null,
	boolEstatusUsuario bit not null,
	vchUserUsuario varchar(30) null,
	vchPassUsuario varchar(30) null
	constraint PK_CAT_Usuarios primary key (intUsuarioID)
)

go

create table CAT_Productos
(
	intProductoID int IDENTITY,
	intTipoProductoID int null,
	vchNombreProducto varchar(30) null,
	decPrecioProducto decimal(15,4) null,
	datFechaAltaProducto datetime null,
	intUsuarioAltaProducto int null,
	boolEstatusProducto bit not null,
	constraint PK_CAT_Product primary key(intProductoID)
)

alter table CAT_Productos
add constraint FK_CAT_TipoProducto foreign key (intTipoProductoID)
references CAT_TipoProducto (intTipoProductoID)

alter table CAT_Productos
add constraint FK_CAT_Usuarios foreign key (intUsuarioAltaProducto)
references CAT_Usuarios (intUsuarioID)

go

create table Bitacora_Productos
(
	intBitacoraID int IDENTITY,
	intProductoID int null,
	datFechaBitacora datetime null,
	intTipoProducto int null,
	vchNombreProducto varchar(30) null,
	decPrecioProducto decimal(15,4) null,
	datFechaAltaProducto datetime null,
	intUsuarioAltaProducto int null,
	boolEstatusProducto bit not null,
	constraint Bitacora_ModificacionProductos primary key(intBitacoraID)
)

alter table Bitacora_Productos
add constraint FK_CAT_Productos foreign key (intProductoID)
references CAT_Productos (intProductoID)

go

