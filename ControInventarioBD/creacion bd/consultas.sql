insert into CAT_Productos (intTipoProductoID, vchNombreProducto,decPrecioProducto, datFechaAltaProducto, intUsuarioAltaProducto,							boolEstatusProducto)
					values (1,'Aceite 123',	45.5,'20220126',1,1),
						(2,'Bacardi',350.3,'20220126',2,1),
							(3,	'Alcochol en gel',25,'20211223',3,0);
go

update CAT_Productos set vchNombreProducto = 'Aceite 12345', intUsuarioAltaProducto=2 where intProductoID = 1;

delete from CAT_Productos where vchNombreProducto = 'Bacardi';

select * from Bitacora_Productos;

select * from CAT_Productos;
select * from CAT_Usuarios;
select * from CAT_TipoProducto;

create table CAT_Eventos
(
	intEventoID int IDENTITY,
	vchEvento varchar(30) null
	constraint PK_CAT_Eventos primary key (intEventoID)
)

alter table Bitacora_Productos add intEventoID int null;

alter table Bitacora_Productos
add constraint FK_Bitacora_Eventos foreign key (intEventoID)
references CAT_Eventos (intEventoID);

insert into CAT_Eventos (vchEvento) values('Insert'),('Update'),('Delete');

select * from CAT_Eventos;



select * from Bitacora_Productos;

