use Control_Inventario;

insert into CAT_TipoProducto (vchNombreTipoProducto, vchDescripcionProducto) 
values ('abarrotes','todos los producto del departamento de abarrotes'),
('vinos','todos los producto del departamento de vinos'), 
('farmacia','todos los productos del departamento farmacia')

go

insert into CAT_Usuarios (vchNombreUsuario,
vchApellidoUsuario,
datFechaNacimientoUsuario,
vchTelefonoUsuario,
boolEstatusUsuario,
vchUserUsuario,
vchPassUsuario) values ('admin','admin','19941018','5566778899',1,'admin','admin'),
						('Maria','Perez Ramirez','19920201','5618996644',1,'mari1','m1234'),
						('Sergio','Ortiz Vela','20001019','5584962515',0,'sergio','serch321');

select * from CAT_TipoProducto;

select * from CAT_Usuarios;

select * from CAT_Productos;
