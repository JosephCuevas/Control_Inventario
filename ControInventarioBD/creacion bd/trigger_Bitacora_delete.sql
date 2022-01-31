use Control_Inventario
go
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER trigger_Bitacora_delete
   ON  CAT_Productos
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	INSERT INTO Bitacora_Productos (intProductoID,
	datFechaBitacora,
	intTipoProducto,
	vchNombreProducto,
	decPrecioProducto,
	datFechaAltaProducto,
	intUsuarioAltaProducto,
	boolEstatusProducto,
	intEventoID)
    select intProductoID,
	GETDATE(),
	intTipoProductoID,
	vchNombreProducto,
	decPrecioProducto,
	datFechaAltaProducto,
	intUsuarioAltaProducto,
	boolEstatusProducto,
	3
	FROM deleted;

END
GO
