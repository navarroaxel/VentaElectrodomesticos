PRINT('Schema del grupo.')
IF NOT EXISTS(SELECT * FROM SYS.SCHEMAS WHERE name = 'DOTNETPY')
EXECUTE sp_executesql N'CREATE SCHEMA DOTNETPY'
GO

PRINT('Tabla de Provincias')
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Provincias' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.Provincias (
	Id int IDENTITY(1, 1) NOT NULL,
	Descripcion nvarchar(100) NOT NULL,
	CONSTRAINT [PK_Provincias] PRIMARY KEY CLUSTERED (
		Id ASC
	)
)

IF (SELECT COUNT(*) FROM DOTNETPY.Provincias) = 0
INSERT INTO DOTNETPY.Provincias (Descripcion)
SELECT DISTINCT SUC_PROVINCIA
FROM gd_esquema.Maestra
GO

PRINT('Tabla de Tipo de Sucursales (Sucursal, Sede Central)')
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TipoSucursales' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.TipoSucursales (
	Id int IDENTITY (1, 1) NOT NULL,
	Descripcion nvarchar(15) NOT NULL,
	CONSTRAINT [PK_TipoSucursales] PRIMARY KEY CLUSTERED (
		Id ASC
	)
)

IF (SELECT COUNT(*) FROM DOTNETPY.TipoSucursales) = 0
INSERT INTO DOTNETPY.TipoSucursales (Descripcion)
SELECT DISTINCT SUC_TIPO
FROM gd_esquema.Maestra
ORDER BY SUC_TIPO ASC
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Sucursales' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.Sucursales (
	Id int IDENTITY(1, 1) NOT NULL,
	TipoSucursalId int NOT NULL,
	Direccion nvarchar(100) NOT NULL,
	ProvinciaId int NOT NULL,
	Telefono nvarchar(20) NOT NULL,
	CONSTRAINT [PK_Sucursales] PRIMARY KEY CLUSTERED (
		Id ASC
	),
	CONSTRAINT [FK_Sucursales_TipoSucursales] FOREIGN KEY (TipoSucursalId)
		REFERENCES DOTNETPY.TipoSucursales (Id),
	CONSTRAINT [FK_Sucursales_Pronvincias] FOREIGN KEY (ProvinciaId)
		REFERENCES DOTNETPY.Provincias (Id)
)

IF (SELECT COUNT(*) FROM DOTNETPY.Sucursales) = 0
INSERT INTO DOTNETPY.Sucursales (TipoSucursalId, Direccion, ProvinciaId, Telefono)
SELECT DISTINCT ts.Id, SUC_DIR, p.Id, SUC_TEL
FROM gd_esquema.Maestra m
INNER JOIN DOTNETPY.TipoSucursales ts ON m.SUC_TIPO = ts.Descripcion
INNER JOIN DOTNETPY.Provincias p ON m.SUC_PROVINCIA = p.Descripcion
ORDER BY ts.Id
GO

PRINT('Fin de creacion de normalizacion de sucursales')
PRINT('Inicio de normalizacion de clientes')
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Clientes' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.Clientes (
	Dni int NOT NULL,
	Nombre nvarchar(40) NOT NULL,
	Apellido nvarchar(40)NOT NULL,
	Mail nvarchar(50) NOT NULL,
	Telefono nvarchar(40) NOT NULL,
	Direccion nvarchar(100) NOT NULL,
	ProvinciaId int NOT NULL,
	[Activo] bit DEFAULT(1),
	CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED (
		Dni ASC
	),
	CONSTRAINT [FK_Clientes_Provincias] FOREIGN KEY (ProvinciaId)
		REFERENCES DOTNETPY.Provincias (Id)
)

IF (SELECT COUNT(*) FROM DOTNETPY.Clientes) = 0
INSERT INTO DOTNETPY.Clientes (Dni, Nombre, Apellido, Mail, Telefono, Direccion, ProvinciaId)
SELECT DISTINCT CLI_DNI, CLI_Nombre, CLI_Apellido, CLI_Mail, '', '', 1
FROM gd_esquema.Maestra
WHERE CLI_DNI IS NOT NULL
GO

PRINT('Inicio de normalizacion de empleados')
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TipoEmpleados' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.TipoEmpleados (
	Id int IDENTITY (1, 1) NOT NULL,
	Descripcion nvarchar(15) NOT NULL,
	CONSTRAINT [PK_TipoEmpleados] PRIMARY KEY CLUSTERED (
		Id ASC
	)
)

IF (SELECT COUNT(*) FROM DOTNETPY.TipoEmpleados) = 0
INSERT INTO DOTNETPY.TipoEmpleados
SELECT DISTINCT EMPLEADO_TIPO
FROM gd_esquema.Maestra
ORDER BY EMPLEADO_TIPO ASC
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Empleados' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.Empleados (
	Dni int NOT NULL,
	Nombre nvarchar(40) NOT NULL,
	Apellido nvarchar(40) NOT NULL,
	Mail nvarchar(50) NOT NULL,
	Direccion nvarchar(100) NOT NULL,
	Telefono nvarchar(40) NOT NULL,
	TipoEmpleadoId int NOT NULL,
	ProvinciaId int NOT NULL,
	SucursalId int NOT NULL,
	[Activo] bit NOT NULL DEFAULT(1),
	CONSTRAINT [PK_Empleados] PRIMARY KEY CLUSTERED (
		Dni ASC
	),
	CONSTRAINT [FK_Empleados_TipoEmpleados] FOREIGN KEY (TipoEmpleadoId)
		REFERENCES DOTNETPY.TipoEmpleados (Id),
	CONSTRAINT [FK_Empleados_Provincias] FOREIGN KEY (ProvinciaId)
		REFERENCES DOTNETPY.Provincias (Id),
	CONSTRAINT [FK_Empleados_Sucursales] FOREIGN KEY (SucursalId)
		REFERENCES DOTNETPY.Sucursales (Id)
)

--Si es vendedor busco su sucursal, si es analista le asigno la Sede Central por default
IF (SELECT COUNT(*) FROM DOTNETPY.Empleados) = 0
INSERT INTO DOTNETPY.Empleados (Dni, Nombre, Apellido, Mail, Direccion, Telefono, TipoEmpleadoId, ProvinciaId, SucursalId)
SELECT DISTINCT EMPLEADO_DNI, EMPLEADO_NOMBRE, EMPLEADO_APELLIDO, EMPLEADO_MAIL, EMPLEADO_DIR, '', te.Id, p.Id,
	CASE te.Id
		WHEN 1 THEN 1
		ELSE (SELECT Id FROM DOTNETPY.Sucursales s WHERE SUC_DIR = s.Direccion)
	END
FROM gd_esquema.Maestra
INNER JOIN DOTNETPY.TipoEmpleados te ON EMPLEADO_TIPO = te.Descripcion
INNER JOIN DOTNETPY.Provincias p ON EMPLEADO_PROVINCIA = p.Descripcion
WHERE EMPLEADO_DNI IS NOT NULL
GO

PRINT('Fin de normalizacion de empleados')
PRINT('Inicio Normalizacion Categorias Productos')
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'CategoriasProductos' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.CategoriasProductos(
	Id int IDENTITY(1,1) NOT NULL,
	Nombre nvarchar(100) NOT NULL,
	PadreId int NULL,
 	CONSTRAINT [PK_CategoriasProductos] PRIMARY KEY CLUSTERED 
	(
		Id ASC
	),
	CONSTRAINT [FK_CategoriasProudctoPadre] FOREIGN KEY(PadreId)
		REFERENCES DOTNETPY.CategoriasProductos (Id)
)

PRINT ('Creacion de SP''s Parseo e insercion categorias de productos')
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_NAME = 'ParseoCategorias' AND SPECIFIC_SCHEMA = 'DOTNETPY' )
	DROP PROCEDURE DOTNETPY.ParseoCategorias

go
CREATE PROCEDURE DOTNETPY.ParseoCategorias @cadena  nvarchar(100), @separador varchar(1),@primero int
AS
BEGIN
	DECLARE @ultimo int,@indiceSep1 int, @indiceSep2 int, @idPadre int
	DECLARE @padre  nvarchar(100), @hijo  nvarchar(100)
	set @ultimo=0
	set @indiceSep1 = CHARINDEX(@separador,@cadena)
	set @indiceSep2 = CHARINDEX(@separador,@cadena,@indiceSep1+1)
	set @padre = substring(@cadena,0,@indiceSep1)
	if @indiceSep2 = 0 
	begin
		set @ultimo=1
		set @indiceSep2=len(@cadena)+1
	end;
	set @hijo = substring(@cadena,@indiceSep1+1,@indiceSep2-@indiceSep1-1)
	
	if @primero!=0 and not exists (select 1 from DOTNETPY.CategoriasProductos
									where Nombre=@padre and PadreId is null) 
	begin
		insert into DOTNETPY.CategoriasProductos values (@padre,NULL);
	end
	--A esta altura ya se que el padre esta en la tabla
	select @idPadre = id from DOTNETPY.CategoriasProductos where Nombre=@padre

	if not exists (select 1 from DOTNETPY.CategoriasProductos
					where Nombre=@hijo and PadreId=@idPadre)
	begin
		insert into DOTNETPY.CategoriasProductos values (@hijo,@idPadre);
	end
	if @ultimo = 0
	begin
		set @cadena=substring(@cadena,@indiceSep1+1,len(@cadena))
		exec DOTNETPY.ParseoCategorias @cadena,@separador,0
	end;
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_NAME = 'CargaCategoriasProductos' AND SPECIFIC_SCHEMA = 'DOTNETPY')
	DROP PROCEDURE DOTNETPY.CargaCategoriasProductos
go
CREATE PROCEDURE DOTNETPY.CargaCategoriasProductos
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Categorias nvarchar(100)
	DECLARE CurCategorias CURSOR
	FOR select distinct PRODUCTO_CATE from gd_esquema.Maestra where PRODUCTO_CATE is not null;
	
	Open CurCategorias   
	
	fetch CurCategorias
	into @Categorias

	while @@fetch_Status<>-1
	begin
				
		exec DOTNETPY.parseoCategorias @Categorias, '¦',1

		fetch CurCategorias
		into @Categorias

	end
	close CurCategorias
	Deallocate CurCategorias
END
GO
EXEC DOTNETPY.CargaCategoriasProductos
GO

PRINT ('Fin Normalizacion Categorias de Productos')
GO

PRINT ('Inicio de normalizacion de facturas')
GO
IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'FormaPagoFacturas' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.FormaPagoFacturas (
	Id int NOT NULL,
	Descripcion nvarchar(15) NOT NULL,
	CONSTRAINT [PK_FormaPagoFacturas] PRIMARY KEY CLUSTERED (
		Id ASC
	)
)
GO

IF ((SELECT COUNT(*) FROM DOTNETPY.FormaPagoFacturas) = 0)
BEGIN
	INSERT INTO DOTNETPY.FormaPagoFacturas (Id, Descripcion) VALUES (1, 'Efectivo')
	INSERT INTO DOTNETPY.FormaPagoFacturas (Id, Descripcion) VALUES (2, 'Cuotas')
END
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Facturas' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.Facturas (
	Nro int IDENTITY(1, 1) NOT NULL,
	Fecha datetime NOT NULL DEFAULT(GETDATE()),
	DniCliente int NOT NULL,
	DniEmpleado int NOT NULL,
	SucursalId int NOT NULL,
	FormaPagoId int NOT NULL,
	Cuotas int NOT NULL,
	Subtotal float NOT NULL,
	Descuento float NOT NULL,
	Total float NOT NULL,
	CONSTRAINT [PK_Facturas] PRIMARY KEY CLUSTERED (
		[Nro] ASC
	),
	CONSTRAINT [FK_Facturas_Clientes] FOREIGN KEY (DniCliente)
		REFERENCES DOTNETPY.Clientes (Dni),
	CONSTRAINT [FK_Facturas_Empleados] FOREIGN KEY(DniEmpleado)
		REFERENCES DOTNETPY.Empleados (Dni),
	CONSTRAINT [FK_Facturas_Sucursales] FOREIGN KEY (SucursalId)
		REFERENCES DOTNETPY.Sucursales (Id),
	CONSTRAINT [FK_Facturas_FormaPagoFacturas] FOREIGN KEY (FormaPagoId)
		REFERENCES DOTNETPY.FormaPagoFacturas (Id)
)
GO

SET IDENTITY_INSERT DOTNETPY.Facturas ON

IF (SELECT COUNT(*) FROM DOTNETPY.Facturas) = 0
INSERT INTO DOTNETPY.Facturas ([Nro], [Fecha], [DniCliente], [DniEmpleado], [SucursalId], [FormaPagoId], [Cuotas], [Subtotal], [Descuento], [Total])
SELECT DISTINCT
	FACTURA_NRO, FACTURA_FECHA, CLI_DNI, EMPLEADO_DNI, s.Id,
	CASE FACTURA_CANT_COUTAS WHEN 1 THEN 1 ELSE 2 END,
	FACTURA_CANT_COUTAS, FACTURA_TOTAL, FACTURA_DESCUENTO, FACTURA_TOTAL_DESCU
FROM gd_esquema.Maestra
INNER JOIN DOTNETPY.Sucursales s ON SUC_DIR = s.Direccion
WHERE FACTURA_NRO IS NOT NULL AND FACTURA_NRO > 0

SET IDENTITY_INSERT DOTNETPY.Facturas OFF
GO

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[DOTNETPY].[Facturas]') AND name = N'IX_Facturas_SucursalId')
DROP INDEX [IX_Facturas_SucursalId] ON [DOTNETPY].[Facturas] WITH ( ONLINE = OFF )
GO

CREATE NONCLUSTERED INDEX [IX_Facturas_SucursalId] ON [DOTNETPY].[Facturas] 
(
	[SucursalId] ASC
)
INCLUDE ([Nro], [Fecha], [DniCliente], [Total])
GO

PRINT('Inicio de normalizacion de pagos de facturas')
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'FacturaPagos' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.FacturaPagos (
	Id int IDENTITY(1, 1) NOT NULL,
	FacturaNro int NOT NULL,
	DniCliente int NOT NULL,
	DniEmpleado int NOT NULL,
	Fecha datetime NOT NULL DEFAULT (GETDATE()),
	Cuotas int NOT NULL,
	Monto float NOT NULL,
	CONSTRAINT [PK_FacturaPagos] PRIMARY KEY CLUSTERED (
		[Id] ASC
	),
	CONSTRAINT [FK_FacturaPagos_Facturas] FOREIGN KEY (FacturaNro)
		REFERENCES DOTNETPY.Facturas (Nro),
	CONSTRAINT [FK_FacturaPagos_Clientes] FOREIGN KEY (DniCliente)
		REFERENCES DOTNETPY.Clientes (Dni),
	CONSTRAINT [FK_FacturaPagos_Empleados] FOREIGN KEY (DniEmpleado)
		REFERENCES DOTNETPY.Empleados (Dni)
)
GO

IF (SELECT COUNT(*) FROM DOTNETPY.FacturaPagos) = 0
INSERT INTO DOTNETPY.FacturaPagos (FacturaNro, DniCliente, DniEmpleado, Fecha, Cuotas, Monto)
SELECT DISTINCT FACTURA_NRO, CLI_DNI, PAGO_EMPLEADO_DNI, PAGO_FECHA, ROUND(FACTURA_CANT_COUTAS * PAGO_MONTO / FACTURA_TOTAL_DESCU, 0), PAGO_MONTO
FROM gd_esquema.Maestra
INNER JOIN DOTNETPY.Sucursales s ON SUC_DIR = s.Direccion
WHERE PAGO_FECHA IS NOT NULL
GO

PRINT('Fin de normalizacion de Facturas.')
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProductoMarcas' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.ProductoMarcas (
	Id int NOT NULL IDENTITY(1, 1),
	Descripcion nvarchar(100) NOT NULL,
	CONSTRAINT PK_ProductoMarcas PRIMARY KEY CLUSTERED 
	(
		Id ASC
	),
)
GO

IF (SELECT COUNT(*) FROM DOTNETPY.ProductoMarcas) = 0
INSERT INTO DOTNETPY.ProductoMarcas
SELECT DISTINCT PRODUCTO_MARCA
FROM gd_esquema.Maestra
WHERE PRODUCTO_MARCA IS NOT NULL
GO

PRINT('Inicio Normalizacion Productos.')
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Productos' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.Productos(
	Id int IDENTITY(1248681717, 1) NOT NULL,
	Nombre nvarchar(100) NOT NULL,
	Descripcion nvarchar(100) NOT NULL,
	Precio float NOT NULL DEFAULT 0,
	MarcaId int NOT NULL,
	CategoriaId int NOT NULL,
	Activo bit NOT NULL DEFAULT 1,
 	CONSTRAINT PK_Productos PRIMARY KEY CLUSTERED 
	(
		Id ASC
	),
	CONSTRAINT FK_Productos_Marcas FOREIGN KEY(MarcaId)
		REFERENCES DOTNETPY.ProductoMarcas (Id),
	CONSTRAINT FK_Productos_Categorias FOREIGN KEY(CategoriaId)
		REFERENCES DOTNETPY.CategoriasProductos (Id),
)
GO

PRINT('Funciones para carga Productos')
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[StringSplit]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [DOTNETPY].[StringSplit]
GO

CREATE FUNCTION DOTNETPY.StringSplit
(
    @cadena AS VARCHAR(2048), 
    @separador AS CHAR(1)
)
RETURNS TABLE
AS
RETURN
( 
  SELECT 
    SUBSTRING(
        @cadena,
        NUMBER, 
        CHARINDEX(@separador, @cadena + @separador, NUMBER) - NUMBER
        ) AS cadena
  FROM
    master..spt_values
  WHERE 
    [TYPE]='P'
    AND NUMBER BETWEEN 1 AND LEN(@cadena) + 1 
    AND SUBSTRING(@separador + @cadena, NUMBER, 1) = @separador
)
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetCategoryID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [DOTNETPY].[GetCategoryID]
GO

CREATE FUNCTION DOTNETPY.GetCategoryID 
(
	@CadenaCategoria nvarchar(100)
)
RETURNS int
AS
BEGIN
	DECLARE @CategoriasPosibles TABLE (
		Id int,
		Nombre nvarchar(100),
		PadreId int
	);
	DECLARE @ElID int;
	
	Insert into @CategoriasPosibles (Id,Nombre,PadreId)
		Select CatProd.Id,CatProd.Nombre,CatProd.PadreId
			from DOTNETPY.CategoriasProductos CatProd,
				 DOTNETPY.StringSplit(@CadenaCategoria,'¦') SplitCat
			where CatProd.Nombre= SplitCat.cadena;
	
	DELETE FROM @CategoriasPosibles
		where PadreId not in 
			(Select T2.Id from @CategoriasPosibles T2);
			
	
	select @ElID = T2.Id From @CategoriasPosibles T2
				where T2.Id not in
				(select T1.PadreId from @CategoriasPosibles T1 where T1.PadreID is not null);
	
	return isnull(@ElID,'-1');
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[rfindchr]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [DOTNETPY].[rfindchr]
GO
CREATE FUNCTION DOTNETPY.rfindchr
(
	@string nvarchar(100),
	@delim char(1)
)
RETURNS int
AS
BEGIN
	DECLARE @lastOccurrence int;
	SELECT
		@lastOccurrence = MAX(NUMBER)
	FROM
		master..spt_values
  WHERE 
		[TYPE]='P' and
		substring(@string, NUMBER, 1) = @delim
		and NUMBER <= LEN(@string);
	
	return @lastOccurrence;
END
GO

PRINT('Fin Funciones carga Productos')
PRINT('Inicio Carga de Datos de Productos')
GO

SET IDENTITY_INSERT DOTNETPY.Productos ON

IF (SELECT COUNT(*) FROM DOTNETPY.Productos) = 0
INSERT INTO DOTNETPY.Productos(Id,Nombre,Descripcion,MarcaId,CategoriaId) 
	SELECT DISTINCT
		substring(producto_nombre,DOTNETPY.rfindchr(producto_nombre,' '),len(producto_nombre)),
		substring(producto_nombre,1,DOTNETPY.rfindchr(producto_nombre,' ')),
		producto_desc,
		B.Id,
		DOTNETPY.GetCategoryId(producto_cate) 
		FROM gd_esquema.Maestra A,
			 DOTNETPY.ProductoMarcas B
		WHERE
			A.producto_nombre IS NOT NULL
			AND A.PRODUCTO_MARCA = B.Descripcion;

SET IDENTITY_INSERT DOTNETPY.Productos OFF;
GO

PRINT('Fin carga datos')
PRINT('Fin Normalizacion Productos')

PRINT('Inicio Normalizacion Stock')
GO
IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ProductoStocks' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.ProductoStocks(
	ProductoId int NOT NULL,
	SucursalId int NOT NULL,
	Cantidad int NOT NULL,
	 CONSTRAINT PK_ProductoStocks PRIMARY KEY CLUSTERED 
	(
		ProductoId ASC,
		SucursalId ASC
	),
	CONSTRAINT FK_ProductoStocks_Producto FOREIGN KEY(ProductoId)
		REFERENCES DOTNETPY.Productos (Id),
	CONSTRAINT FK_ProductoStocks_Sucursal FOREIGN KEY(SucursalId)
		REFERENCES DOTNETPY.Sucursales (Id)
)
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'IngresoStocks' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.IngresoStocks(
	Id int IDENTITY(1,1) NOT NULL,
	FechaIngreso datetime NOT NULL,
	SucursalId int NOT NULL,
	ProductoId int NOT NULL,
	DniEmpleado int NOT NULL,
	Cantidad int NOT NULL,
	CONSTRAINT PK_LlegadaStock PRIMARY KEY CLUSTERED 
	(
		Id ASC
	),
	CONSTRAINT FK_IngresoStock_Empleado FOREIGN KEY(DniEmpleado)
		REFERENCES DOTNETPY.Empleados (Dni),
	CONSTRAINT FK_IngresoStock_Producto FOREIGN KEY(ProductoId)
		REFERENCES DOTNETPY.Productos (Id),
	CONSTRAINT FK_IngresoStock_Sucursal FOREIGN KEY(SucursalId)
		REFERENCES DOTNETPY.Sucursales (Id)
)

GO
CREATE NONCLUSTERED INDEX IX_IngresoSTock
ON DOTNETPY.IngresoStocks (SucursalId,FechaIngreso)
INCLUDE (ProductoId,Cantidad)
GO

PRINT('Carga Ingreso Cambios de Stock')
GO

insert into DOTNETPY.IngresoStocks(SucursalId,ProductoId,DniEmpleado,Cantidad,FechaIngreso)
select   SUCUR.Id,
		 substring(producto_nombre,DOTNETPY.rfindchr(producto_nombre,' '),len(producto_nombre)),
		 EMPLEADO_DNI,
		 LLEGADA_STOCK_CANT,
		 LLEGADA_STOCK_FECHA
from gd_esquema.Maestra MAESTRA,
	 DOTNETPY.Sucursales SUCUR
where 
	producto_nombre is not null and
	SUC_DIR is not null and
	LLEGADA_STOCK_FECHA is not null and
	CLI_DNI is null and 
	LLEGADA_STOCK_CANT IS NOT NULL and
	LLEGADA_STOCK_CANT != 0 and
	SUCUR.Direccion=SUC_DIR;
GO

PRINT('Fin Carga Historico Cambios de Stock')
PRINT('Inicio normalizacion Facturas Productos')
GO

IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'FacturaProductos' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.FacturaProductos(
	FacturaNro int NOT NULL,
	ProductoId int NOT NULL,
	Cantidad int NOT NULL,
	PrecioUnitario float NOT NULL,
	CONSTRAINT PK_FacturaProductos_1 PRIMARY KEY CLUSTERED 
	(
		FacturaNro ASC,
		ProductoId ASC
	),
	CONSTRAINT FK_FacturaProductos_Factura FOREIGN KEY(FacturaNro)
		REFERENCES DOTNETPY.Facturas (Nro),
	CONSTRAINT FK_FacturaProductos_Productos FOREIGN KEY(ProductoId)
		REFERENCES DOTNETPY.Productos (Id)
)

GO

--carga datos
insert into DOTNETPY.FacturaProductos(FacturaNro,ProductoId,Cantidad,PrecioUnitario)
	select 
		FACTURA_NRO,
		substring(PRODUCTO_NOMBRE,DOTNETPY.rfindchr(PRODUCTO_NOMBRE,' '),len(PRODUCTO_NOMBRE)) producto,
		SUM(PRODUCTO_CANT) cantidad,
		PRODUCTO_PRECIO
	from gd_esquema.Maestra
	where FACTURA_NRO is not null and
		  FACTURA_NRO > 0 and
		  PRODUCTO_NOMBRE is not null
	group by FACTURA_NRO,PRODUCTO_NOMBRE,PRODUCTO_PRECIO
GO
PRINT('Fin Normalizacion Facturas Productos')

-- Calculo Stock Productos
insert into DOTNETPY.ProductoStocks (SucursalId,ProductoId,Cantidad)
select A.SucursalId,A.ProductoId,A.cant-B.cant 
from
(select INGS.ProductoId,INGS.SucursalId,sum(INGS.Cantidad) cant
from
	 DOTNETPY.IngresoStocks INGS
group by INGS.ProductoId,INGS.SucursalId) A,
(select FP.ProductoId,F.SucursalId,sum(FP.Cantidad) cant
from
	 DOTNETPY.FacturaProductos FP,
	 DOTNETPY.Facturas F
where F.Nro=FP.FacturaNro
group by ProductoId,F.SucursalId)B
where A.ProductoId = B.ProductoId
and A.SucursalId=B.SucursalId;
GO

PRINT ('Inicio de Creacion de Triggers para Actualizacion de Stock')
GO

CREATE TRIGGER DOTNETPY.TR_IngresoStocks
   ON  DOTNETPY.IngresoStocks 
   AFTER INSERT
AS 
BEGIN
	DECLARE @tablaInsertados table(
		Id int identity(1,1),
		SucursalId int,
		ProductoId int,
		Cantidad int
	)
	DECLARE @id_counter int, @id_counter_max int
	
	INSERT INTO @tablaInsertados(SucursalId,ProductoId,Cantidad) 
		SELECT SucursalId,ProductoId,Cantidad FROM INSERTED
	
	set @id_counter = 1
	set @id_counter_max = (select isnull(max(id),0)+1 from @tablaInsertados)	
	while( @id_counter < @id_counter_max)
	begin
		DECLARE @producto int, @sucursal int, @cantidad int
		select
			@producto = ProductoId,@sucursal = sucursalId,@cantidad = cantidad
		from
			@tablaInsertados
		where
			Id = @id_counter
			
			
		UPDATE DOTNETPY.ProductoStocks SET ProductoStocks.Cantidad = ProductoStocks.Cantidad + @cantidad
		WHERE ProductoStocks.ProductoId=@Producto
		AND	  ProductoStocks.SucursalId=@Sucursal
		
		IF (@@ROWCOUNT = 0 ) -- Si no updateo nada, significa que el producto no existe en la tabla de stock
		begin
			INSERT INTO DOTNETPY.ProductoStocks (ProductoId,SucursalId,Cantidad) 
			VALUES (@Producto,@Sucursal,@Cantidad)
		end
		set @id_counter = @id_counter+1
	end
END
GO

CREATE TRIGGER DOTNETPY.TR_FacturaProductos
   ON  DOTNETPY.FacturaProductos 
   AFTER INSERT
AS 
BEGIN
	DECLARE @tablaInsertados table(
		Id int identity(1,1),
		SucursalId int,
		ProductoId int,
		Cantidad int
	)
	DECLARE @id_counter int, @id_counter_max int
	
	INSERT INTO @tablaInsertados(SucursalId,ProductoId,Cantidad) 
		SELECT F.SucursalId,A.ProductoId,A.Cantidad 
		FROM INSERTED A,
			 DOTNETPY.Facturas F
		WHERE A.FacturaNro=F.Nro
		
	
	set @id_counter = 1
	set @id_counter_max = (select isnull(max(id),0)+1 from @tablaInsertados)	
	while( @id_counter < @id_counter_max)
	begin
		DECLARE @producto int, @sucursal int, @cantidad int
		select
			@producto = ProductoId,@sucursal = sucursalId,@cantidad = cantidad
		from
			@tablaInsertados
		where
			Id = @id_counter
			
			
		UPDATE DOTNETPY.ProductoStocks SET ProductoStocks.Cantidad = ProductoStocks.Cantidad - @cantidad
		WHERE ProductoStocks.ProductoId=@Producto
		AND	  ProductoStocks.SucursalId=@Sucursal
		
		set @id_counter = @id_counter+1
	end

END
GO

PRINT('Fin de Creacion de Triggers para Actualizacion de Stock')

PRINT('Actualizacion Precios Productos')
GO

update DOTNETPY.Productos set Precio = 
	(select TOP 1 PrecioUnitario 
	from DOTNETPY.FacturaProductos FP,
		 DOTNETPY.Facturas F
	where FP.FacturaNro=F.Nro
	and DOTNETPY.Productos.Id=FP.ProductoId
	Order by F.Fecha DESC)

GO
PRINT (' Creacion Roles')

GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Funcionalidades' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.Funcionalidades (
	Id int IDENTITY(1, 1) NOT NULL,
	Descripcion nvarchar(100) NOT NULL,
	CONSTRAINT [PK_Funcionalidades] PRIMARY KEY CLUSTERED (
		Id ASC
	)
)
go
IF (SELECT COUNT(*) FROM DOTNETPY.Funcionalidades) = 0
begin
INSERT INTO DOTNETPY.Funcionalidades (Descripcion) VALUES('ABM de Empleado')
INSERT INTO DOTNETPY.Funcionalidades (Descripcion) VALUES('ABM de Rol')
INSERT INTO DOTNETPY.Funcionalidades (Descripcion) VALUES('ABM de Usuario')
INSERT INTO DOTNETPY.Funcionalidades (Descripcion) VALUES('ABM de Cliente')
INSERT INTO DOTNETPY.Funcionalidades (Descripcion) VALUES('ABM de Producto')
INSERT INTO DOTNETPY.Funcionalidades (Descripcion) VALUES('Asignación de Stock')
INSERT INTO DOTNETPY.Funcionalidades (Descripcion) VALUES('Facturación')
INSERT INTO DOTNETPY.Funcionalidades (Descripcion) VALUES('Efectuar Pago')
INSERT INTO DOTNETPY.Funcionalidades (Descripcion) VALUES('Tablero de Control')
INSERT INTO DOTNETPY.Funcionalidades (Descripcion) VALUES('Clientes Premium')
INSERT INTO DOTNETPY.Funcionalidades (Descripcion) VALUES('Mejores Categorías')
end
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Roles' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.Roles (
	Id int IDENTITY(1, 1) NOT NULL,
	Nombre nvarchar(100) NOT NULL,
	Activo bit NOT NULL DEFAULT (1),
	CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED (
		Id ASC
	)
)
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'RolFuncionalidades' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.RolFuncionalidades (
	RolId int NOT NULL,
	FuncionalidadId int NOT NULL,
	CONSTRAINT [PK_RolFuncionalidades] PRIMARY KEY CLUSTERED (
		RolId ASC,
		FuncionalidadId ASC
	),
	CONSTRAINT [FK_RolFuncionalidades_Roles] FOREIGN KEY (RolId)
		REFERENCES DOTNETPY.Roles (Id),
	CONSTRAINT [FK_RolFuncionalidades_Funcionalidades] FOREIGN KEY (FuncionalidadId)
		REFERENCES DOTNETPY.Funcionalidades (Id)
)
GO

IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Usuarios' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.Usuarios (
	DniEmpleado int NOT NULL,
	Username nvarchar(50),
	[Password] nvarchar(100),
	Intentos int NOT NULL DEFAULT(0),
	Activo bit NOT NULL DEFAULT(1),
	CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED (
		DniEmpleado ASC
	),
	CONSTRAINT [IX_Usuarios_Username] UNIQUE NONCLUSTERED (
		Username ASC
	),
	CONSTRAINT [FK_Usuarios_Empleados] FOREIGN KEY (DniEmpleado)
		REFERENCES DOTNETPY.Empleados (Dni)
)
GO
IF NOT EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'UsuarioRoles' AND TABLE_SCHEMA = 'DOTNETPY')
CREATE TABLE DOTNETPY.UsuarioRoles (
	DniEmpleado int NOT NULL,
	RolId int NOT NULL,
	CONSTRAINT [PK_UsuarioRoles] PRIMARY KEY CLUSTERED (
		DniEmpleado ASC,
		RolId ASC
	),
	CONSTRAINT [FK_UsuarioRoles_Usuarios] FOREIGN KEY (DniEmpleado)
		REFERENCES DOTNETPY.Usuarios (DniEmpleado),
	CONSTRAINT [FK_UsuarioRoles_Roles] FOREIGN KEY (RolId)
		REFERENCES DOTNETPY.Roles (Id)
)
GO
INSERT INTO DOTNETPY.Roles (Nombre)
VALUES ('Administrador General')

INSERT INTO DOTNETPY.RolFuncionalidades
SELECT 1, Id
FROM DOTNETPY.Funcionalidades
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GenerateUser]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [DOTNETPY].[GenerateUser]
GO

CREATE FUNCTION DOTNETPY.GenerateUser
(
	@nombre nvarchar(40),
	@apellido nvarchar(40)
)
RETURNS nvarchar(41)
AS
BEGIN
	DECLARE @usuario nvarchar(41);
	select @usuario=lower(substring(@nombre,1,1)+@apellido);
	select @usuario=replace(@usuario,'á','a')
	select @usuario=replace(@usuario,'é','e')
	select @usuario=replace(@usuario,'í','i')
	select @usuario=replace(@usuario,'ó','o')
	select @usuario=replace(@usuario,'ú','u')
	select @usuario=replace(@usuario,' ','')
	return @usuario
END

GO

INSERT INTO DOTNETPY.Usuarios (DniEmpleado, Username, [Password]) 
SELECT 
	Dni,
	DOTNETPY.generateUser(nombre,apellido),
	-- sha256(123456)
	'8D-96-9E-EF-6E-CA-D3-C2-9A-3A-62-92-80-E6-86-CF-0C-3F-5D-5A-86-AF-F3-CA-12-02-0C-92-3A-DC-6C-92'
FROM DOTNETPY.empleados

INSERT INTO DOTNETPY.Roles (Nombre)
VALUES ('Vendedor');

INSERT INTO DOTNETPY.RolFuncionalidades (RolId,FuncionalidadId)
SELECT R.Id,F.Id
FROM DOTNETPY.Roles R,
	 DOTNETPY.Funcionalidades F
WHERE R.Nombre='Vendedor' and
	  F.Descripcion in ('Asignación de Stock','Facturación','Efectuar Pago')
	  
	  
INSERT INTO DOTNETPY.Roles (Nombre)
VALUES ('Analista');

insert into DOTNETPY.RolFuncionalidades (RolId,FuncionalidadId)
select R.Id,F.Id
from DOTNETPY.Roles R,
	 DOTNETPY.Funcionalidades F
where R.Nombre='Analista' and
	  F.Descripcion not in ('ABM de Empleado','ABM de Rol','ABM de Usuario')

Insert into DOTNETPY.UsuarioRoles (DniEmpleado,RolId)
select EMP.DNI,ROLES.Id
from DOTNETPY.Empleados EMP,
	 DOTNETPY.TipoEmpleados TEMP,
	 DOTNETPY.Roles ROLES
where EMP.TipoEmpleadoId=TEMP.Id and
	  ((TEMP.descripcion='Analista' and ROLES.Nombre='Analista') or
	  (TEMP.descripcion='Vendedor' and ROLES.Nombre='Vendedor'))
GO

PRINT('Fin de Creacion Roles')
PRINT ('Creacion usuario admin')
GO

INSERT INTO DOTNETPY.Empleados(
					  DNI,
					  Nombre,
					  Apellido,
					  Direccion,
					  Mail,
					  TipoEmpleadoId,
					  ProvinciaID,
					  SucursalId,
					  Telefono)
	VALUES (1,'admin','admin','','',1,21,1,'')

INSERT into DOTNETPY.Usuarios
VALUES(
	1,
	'admin',
	'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7',
	0,
	1)

INSERT INTO DOTNETPY.UsuarioRoles 
SELECT 1, Id 
FROM DOTNETPY.Roles 
WHERE Nombre = 'Administrador General'
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetCategoriaDescripcion]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [DOTNETPY].[GetCategoriaDescripcion]
GO

CREATE FUNCTION DOTNETPY.GetCategoriaDescripcion
(
	@CategoriaId int
)
RETURNS nvarchar(100)
AS
BEGIN
	DECLARE @descripcion nvarchar(100)
	DECLARE @nombre nvarchar(100),@padre int
	while(1 = 1)
	begin
		select @nombre=Nombre, @padre=PadreId from DOTNETPY.CategoriasProductos
		where Id=@CategoriaId
		if (@descripcion is null)
			set @descripcion= @nombre
		else
			set @descripcion=@nombre+'¦'+@descripcion
			
		if(@padre is null)
			return @descripcion
		
		set @CategoriaId = @padre
		
	end
	return ''
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetCategoriaMayor]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [DOTNETPY].[GetCategoriaMayor]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [DOTNETPY].[GetCategoriaMayor]
(
	@CategoriaId int
)
RETURNS int
AS
BEGIN
	DECLARE @Padre int
	
	SELECT @Padre = @CategoriaId
	
	WHILE @Padre IS NOT NULL
		SELECT @CategoriaId = Id, @Padre = PadreId
		FROM [DOTNETPY].[CategoriasProductos]
		WHERE Id = @Padre
	
	RETURN @CategoriaId
END
GO

PRINT ('Inicio de Creacion de Vistas')
GO

IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[DOTNETPY].[VentasProductos]'))
DROP VIEW [DOTNETPY].[VentasProductos]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [DOTNETPY].[VentasProductos]
AS
SELECT
	DOTNETPY.Productos.Id AS ProductoId,
	DOTNETPY.Productos.CategoriaId,
	DOTNETPY.FacturaProductos.PrecioUnitario AS Precio,
	DOTNETPY.FacturaProductos.Cantidad,
	DOTNETPY.Facturas.Fecha,
	DOTNETPY.Facturas.SucursalId,
	DOTNETPY.Facturas.DniEmpleado
FROM
	DOTNETPY.Facturas
	INNER JOIN DOTNETPY.FacturaProductos ON DOTNETPY.FacturaProductos.FacturaNro = DOTNETPY.Facturas.Nro
    INNER JOIN DOTNETPY.Productos ON DOTNETPY.FacturaProductos.ProductoId = DOTNETPY.Productos.Id
GO

PRINT ('Fin de Creacion de Vistas')
GO

PRINT ('Creacion de Stored Procedures')
GO

/****** Object:  StoredProcedure [DOTNETPY].[AddCliente]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[AddCliente]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[AddCliente]
GO

/****** Object:  StoredProcedure [DOTNETPY].[AddEmpleado]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[AddEmpleado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[AddEmpleado]
GO

/****** Object:  StoredProcedure [DOTNETPY].[AddFactura]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[AddFactura]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[AddFactura]
GO

/****** Object:  StoredProcedure [DOTNETPY].[AddFacturaPago]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[AddFacturaPago]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[AddFacturaPago]
GO

/****** Object:  StoredProcedure [DOTNETPY].[AddFacturaProducto]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[AddFacturaProducto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[AddFacturaProducto]
GO

/****** Object:  StoredProcedure [DOTNETPY].[AddProducto]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[AddProducto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[AddProducto]
GO

/****** Object:  StoredProcedure [DOTNETPY].[AddRol]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[AddRol]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[AddRol]
GO

/****** Object:  StoredProcedure [DOTNETPY].[AddStock]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[AddStock]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[AddStock]
GO

/****** Object:  StoredProcedure [DOTNETPY].[AddUsuario]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[AddUsuario]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[AddUsuario]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetCategorias]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetCategorias]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetCategorias]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetCliente]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetCliente]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetCliente]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetClientes]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetClientes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetClientes]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetClientesByFiltros]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetClientesByFiltros]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetClientesByFiltros]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetClientesPremium]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetClientesPremium]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetClientesPremium]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetEmpleado]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetEmpleado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetEmpleado]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetEmpleadoFiltros]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetEmpleadoFiltros]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetEmpleadoFiltros]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetEmpleados]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetEmpleados]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetEmpleados]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetEmpleadosByFiltros]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetEmpleadosByFiltros]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetEmpleadosByFiltros]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetEmpleadosWithoutUsuarios]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetEmpleadosWithoutUsuarios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetEmpleadosWithoutUsuarios]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetFactura]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetFactura]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetFactura]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetFacturasImpagas]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetFacturasImpagas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetFacturasImpagas]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetFuncionalidades]    Script Date: 06/09/2011 08:30:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetFuncionalidades]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetFuncionalidades]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetMarcas]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetMarcas]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetMarcas]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetMejoresCategorias]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetMejoresCategorias]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetMejoresCategorias]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetPermisosByUsuario]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetPermisosByUsuario]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetPermisosByUsuario]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetProducto]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetProducto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetProducto]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetProductos]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetProductos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetProductos]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetProductosByFiltros]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetProductosByFiltros]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetProductosByFiltros]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetProductoStocks]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetProductoStocks]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetProductoStocks]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetProductoStocksBySucursal]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetProductoStocksBySucursal]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetProductoStocksBySucursal]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetProvincias]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetProvincias]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetProvincias]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetRol]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetRol]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetRol]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetRoles]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetRoles]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetRoles]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetRolesByFiltros]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetRolesByFiltros]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetRolesByFiltros]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetRolesByUsuario]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetRolesByUsuario]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetRolesByUsuario]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetSucuralFiltros]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetSucuralFiltros]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetSucuralFiltros]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetSucursales]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetSucursales]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetSucursales]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetTableroControl]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetTableroControl]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetTableroControl]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetTipoEmpleados]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetTipoEmpleados]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetTipoEmpleados]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetUsuario]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetUsuario]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetUsuario]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetUsuarioByUsername]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetUsuarioByUsername]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetUsuarioByUsername]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetUsuarios]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetUsuarios]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetUsuarios]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetUsuariosByFiltros]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[GetUsuariosByFiltros]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[GetUsuariosByFiltros]
GO

/****** Object:  StoredProcedure [DOTNETPY].[MayorStockFaltante]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[MayorStockFaltante]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[MayorStockFaltante]
GO

/****** Object:  StoredProcedure [DOTNETPY].[SetEnableCliente]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[SetEnableCliente]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[SetEnableCliente]
GO

/****** Object:  StoredProcedure [DOTNETPY].[SetEnableEmpleado]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[SetEnableEmpleado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[SetEnableEmpleado]
GO

/****** Object:  StoredProcedure [DOTNETPY].[SetEnableProducto]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[SetEnableProducto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[SetEnableProducto]
GO

/****** Object:  StoredProcedure [DOTNETPY].[SetEnableRol]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[SetEnableRol]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[SetEnableRol]
GO

/****** Object:  StoredProcedure [DOTNETPY].[SetEnableUsuario]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[SetEnableUsuario]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[SetEnableUsuario]
GO

/****** Object:  StoredProcedure [DOTNETPY].[SetUsuarioIntentos]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[SetUsuarioIntentos]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[SetUsuarioIntentos]
GO

/****** Object:  StoredProcedure [DOTNETPY].[UpdateCliente]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[UpdateCliente]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[UpdateCliente]
GO

/****** Object:  StoredProcedure [DOTNETPY].[UpdateEmpleado]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[UpdateEmpleado]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[UpdateEmpleado]
GO

/****** Object:  StoredProcedure [DOTNETPY].[UpdateProducto]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[UpdateProducto]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[UpdateProducto]
GO

/****** Object:  StoredProcedure [DOTNETPY].[UpdateRol]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[UpdateRol]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[UpdateRol]
GO

/****** Object:  StoredProcedure [DOTNETPY].[UpdateUsuario]    Script Date: 06/09/2011 08:30:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DOTNETPY].[UpdateUsuario]') AND type in (N'P', N'PC'))
DROP PROCEDURE [DOTNETPY].[UpdateUsuario]
GO

/****** Object:  StoredProcedure [DOTNETPY].[GetProvincias]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetProvincias]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Descripcion
	FROM DOTNETPY.Provincias
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetTipoEmpleados]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetTipoEmpleados]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Descripcion
	FROM DOTNETPY.TipoEmpleados
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetSucursales]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetSucursales]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, TipoSucursalId, Direccion, ProvinciaId, Telefono
	FROM DOTNETPY.Sucursales
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[AddCliente]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[AddCliente] 
	@Dni int,
	@Nombre nvarchar(40),
	@Apellido nvarchar(40),
	@Mail nvarchar(50),
	@Telefono nvarchar(40),
	@Direccion nvarchar(100),
	@ProvinciaId int
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [DOTNETPY].[Clientes] (
		Dni,
		Nombre,
		Apellido,
		Mail,
		Telefono,
		Direccion,
		ProvinciaId)
	VALUES (
		@Dni,
		@Nombre,
		@Apellido,
		@Mail,
		@Telefono,
		@Direccion,
		@ProvinciaId)
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[AddEmpleado]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[AddEmpleado] 
	@Dni int,
	@Nombre nvarchar(40),
	@Apellido nvarchar(40),
	@Mail nvarchar(50),
	@Direccion nvarchar(100),
	@Telefono nvarchar(40),
	@TipoEmpleadoId int,
	@ProvinciaId int,
	@SucursalId int
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [DOTNETPY].[Empleados] (
		Dni,
		Nombre,
		Apellido,
		Mail,
		Direccion,
		Telefono,
		TipoEmpleadoId,
		ProvinciaId,
		SucursalId)
	VALUES (
		@Dni,
		@Nombre,
		@Apellido,
		@Mail,
		@Direccion,
		@Telefono,
		@TipoEmpleadoId,
		@ProvinciaId,
		@SucursalId)
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[AddFactura]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[AddFactura]
	@Fecha datetime,
	@DniCliente int,
	@DniEmpleado int,
	@SucursalId int,
	@FormaPagoId int,
	@Cuotas int,
	@Subtotal float,
	@Descuento float,
	@Total float
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [DOTNETPY].[Facturas] (
		Fecha,
		DniCliente,
		DniEmpleado,
		SucursalId,
		FormaPagoId,
		Cuotas,
		Subtotal,
		Descuento,
		Total)
	VALUES (
		@Fecha,
		@DniCliente,
		@DniEmpleado,
		@SucursalId,
		@FormaPagoId,
		@Cuotas,
		@Subtotal,
		@Descuento,
		@Total)

	SELECT SCOPE_IDENTITY()
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[AddFacturaPago]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[AddFacturaPago]
	 @FacturaNro int,
     @DniCliente int,
     @DniEmpleado int,
     @Fecha datetime,
     @Cuotas int,
     @Monto float
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [DOTNETPY].[FacturaPagos] (
		FacturaNro,
		DniCliente,
		DniEmpleado,
		Fecha,
		Cuotas,
		Monto)
	VALUES (
		@FacturaNro,
		@DniCliente,
		@DniEmpleado,
		@Fecha,
		@Cuotas,
		@Monto)
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[AddFacturaProducto]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[AddFacturaProducto]
	@FacturaNro int,
	@ProductoId int,
	@Cantidad int,
	@PrecioUnitario float
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [DOTNETPY].[FacturaProductos] (
		FacturaNro,
		ProductoId,
		Cantidad,
		PrecioUnitario)
	VALUES (
		@FacturaNro,
		@ProductoId,
		@Cantidad,
		@PrecioUnitario)
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[AddProducto]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [DOTNETPY].[AddProducto]
	@MarcaId int,
	@Nombre nvarchar(100),
	@Descripcion nvarchar(100),
	@CategoriaId int,
	@Precio float
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [DOTNETPY].[Productos] (
		MarcaId,
		Nombre,
		Descripcion,
		CategoriaId,
		Precio)
	VALUES (
		@MarcaId,
		@Nombre,
		@Descripcion,
		@CategoriaId,
		@Precio)
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[AddRol]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [DOTNETPY].[AddRol]
	@Nombre nvarchar(100),
	@FuncionalidadesIds nvarchar(30)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @RolId int

    INSERT INTO [DOTNETPY].[Roles] (Nombre)
	VALUES (@Nombre)
	
	SET @RolId = SCOPE_IDENTITY()
	
	INSERT INTO [DOTNETPY].[RolFuncionalidades] (RolId, FuncionalidadId)
	SELECT @RolId, cadena
	FROM DOTNETPY.StringSplit(@FuncionalidadesIds, ',')
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[AddStock]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[AddStock]
	@Fecha datetime,
	@SucursalId int,
	@ProductoId int,
	@DniEmpleado int,
	@Cantidad int
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [DOTNETPY].[IngresoStocks](
		[FechaIngreso],
		[SucursalId],
		[ProductoId],
		[DniEmpleado],
		[Cantidad])
	VALUES (
		@Fecha,
		@SucursalId,
		@ProductoId,
		@DniEmpleado,
		@Cantidad)
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[AddUsuario]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[AddUsuario]
	@Dni int,
	@Username nvarchar(50),
	@Password nvarchar(100),
	@RolesIds nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [DOTNETPY].[Usuarios] (
		DniEmpleado,
		Username,
		[Password])
	VALUES (
		@Dni,
		@Username,
		@Password)
	
	INSERT INTO [DOTNETPY].[UsuarioRoles]
	SELECT @Dni, cadena
	FROM [DOTNETPY].[StringSplit](@RolesIds, ',')
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetCategorias]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetCategorias]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Nombre, PadreId
	FROM [DOTNETPY].[CategoriasProductos]
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetCliente]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [DOTNETPY].[GetCliente]
	@Dni int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Dni, Nombre, Apellido, Mail, Telefono, Direccion, ProvinciaId, Activo
	FROM DOTNETPY.Clientes
	WHERE Dni = @Dni
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetClientes]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetClientes]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Dni, Nombre, Apellido, Mail, Telefono, Direccion, ProvinciaId, Activo
	FROM DOTNETPY.Clientes
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetClientesByFiltros]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetClientesByFiltros]
	@Dni int = NULL,
	@Nombre nvarchar(40) = NULL,
	@Apellido nvarchar(40) = NULL,
	@ProvinciaId int = NULL,
	@Activo bit = NULL
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @sql nvarchar(MAX)
	
	SET @sql =
'	SELECT Dni, Nombre, Apellido, Mail, Telefono, Direccion, ProvinciaId, Activo
	FROM [DOTNETPY].[Clientes]
	WHERE 1 = 1'
	
	IF @Dni IS NOT NULL AND @Dni > 0
		SET @sql = @sql + ' AND Dni = @Dni'
	
	IF @Nombre IS NOT NULL
	BEGIN
		SET @Nombre = @Nombre + '%'
		SET @sql = @sql + ' AND Nombre LIKE @Nombre'
	END
	
	IF @Apellido IS NOT NULL
	BEGIN
		SET @Apellido = @Apellido + '%'
		SET @sql = @sql + ' AND Apellido LIKE @Apellido'
	END
	
	IF @ProvinciaId IS NOT NULL AND @ProvinciaId > 0
		SET @sql = @sql + ' AND ProvinciaId = @ProvinciaId'
	
	IF @Activo IS NOT NULL
		SET @sql = @sql + ' AND Activo = @Activo'
	
	EXEC sp_executesql @sql,
		N'@Dni int, @Nombre nvarchar(40), @Apellido nvarchar(40), @ProvinciaId int, @Activo bit',
		@Dni,
		@Nombre,
		@Apellido,
		@ProvinciaId,
		@Activo
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetClientesPremium]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetClientesPremium]
	@SucursalId int,
	@Anio int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT
		t.Nombre,
		t.Apellido,
		t.DNI,
		ROUND(t.[Monto Total Acumulado], 2) AS [Monto Total Acumulado],
		(SELECT SUM(fp.Cantidad)
		 FROM DOTNETPY.Facturas f
		 INNER JOIN [DOTNETPY].[FacturaProductos] fp ON f.Nro = fp.FacturaNro
		 WHERE
			f.DniCliente = t.DNI
			AND f.SucursalId = @SucursalId
			AND YEAR(f.Fecha) = @Anio) AS [Total Productos Adquiridos],
		DATEADD(dd,0, DATEDIFF(dd, 0, ultimaF.Fecha)) AS [Fecha Ultima Factura],
		ultimaF.DniEmpleado AS [Ultimo Vendedor]
	FROM (
		SELECT TOP 30
			Nombre,
			Apellido,
			Dni AS DNI,
			SUM(f.Total) AS [Monto Total Acumulado],
			MAX(f.Nro) AS [UltimaFactura]
		FROM [DOTNETPY].[Clientes] c
		INNER JOIN [DOTNETPY].[Facturas] f ON c.Dni = f.DniCliente
		WHERE
			f.SucursalId = @SucursalId
			AND YEAR(f.Fecha) = @Anio
		GROUP BY
			Dni,
			Nombre,
			Apellido
		ORDER BY [Monto Total Acumulado] DESC) AS t
	INNER JOIN [DOTNETPY].[Facturas] ultimaF ON t.[UltimaFactura] = ultimaF.Nro
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetEmpleado]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [DOTNETPY].[GetEmpleado]
	@Dni int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Dni, Nombre, Apellido, Mail, Direccion, Telefono, TipoEmpleadoId, ProvinciaId, SucursalId, Activo
	FROM DOTNETPY.Empleados
	WHERE Dni = @Dni
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetEmpleadoFiltros]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetEmpleadoFiltros]
AS
BEGIN
	SET NOCOUNT ON;

	EXEC DOTNETPY.GetProvincias
	EXEC DOTNETPY.GetTipoEmpleados
	EXEC DOTNETPY.GetSucursales
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetEmpleados]    Script Date: 06/09/2011 08:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetEmpleados]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Dni, Nombre, Apellido, Mail, Direccion, Telefono, TipoEmpleadoId, ProvinciaId, SucursalId, Activo
	FROM DOTNETPY.Empleados
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetEmpleadosByFiltros]    Script Date: 06/09/2011 08:30:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetEmpleadosByFiltros]
	@Dni int = NULL,
	@Nombre varchar(40) = NULL,
	@Apellido varchar(40) = NULL,
	@TipoEmpleadoId int = NULL,
	@ProvinciaId int = NULL,
	@SucursalId int = NULL,
	@Activo int = NULL
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @sql nvarchar(MAX)
	
	SET @sql =
'	SELECT Dni, Nombre, Apellido, Mail, Direccion, Telefono, TipoEmpleadoId, ProvinciaId, SucursalId, Activo
	FROM DOTNETPY.Empleados
	WHERE 1 = 1'
	
	IF @Dni IS NOT NULL AND @Dni > 0
		SET @sql = @sql + ' AND Dni = @Dni'
	
	IF @Nombre IS NOT NULL
	BEGIN
		SET @Nombre = @Nombre + '%'
		SET @sql = @sql + ' AND Nombre LIKE @Nombre'
	END
	
	IF @Apellido IS NOT NULL
	BEGIN
		SET @Apellido = @Apellido + '%'
		SET @sql = @sql + ' AND Apellido LIKE @Apellido'
	END
	
	IF @TipoEmpleadoId IS NOT NULL AND @TipoEmpleadoId > 0
		SET @sql = @sql + ' AND TipoEmpleadoId = @TipoEmpleadoId'
	
	IF @ProvinciaId IS NOT NULL AND @ProvinciaId > 0
		SET @sql = @sql + ' AND ProvinciaId = @ProvinciaId'
	
	IF @SucursalId IS NOT NULL AND @SucursalId > 0
		SET @sql = @sql + ' AND SucursalId = @SucursalId'
	
	IF @Activo IS NOT NULL
		SET @sql = @sql + ' AND Activo = @Activo'
	
	EXEC sp_executesql @sql,
		N'@Dni int, @Nombre nvarchar(40), @Apellido nvarchar(40), @TipoEmpleadoId int, @ProvinciaId int, @SucursalId int, @Activo bit',
		@Dni,
		@Nombre,
		@Apellido,
		@TipoEmpleadoId,
		@ProvinciaId,
		@SucursalId,
		@Activo
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetEmpleadosWithoutUsuarios]    Script Date: 06/09/2011 08:30:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [DOTNETPY].[GetEmpleadosWithoutUsuarios]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		e.Dni, e.Nombre, e.Apellido, e.Mail, e.Direccion,
		e.Telefono, e.TipoEmpleadoId, e.ProvinciaId, e.SucursalId, e.Activo
	FROM [DOTNETPY].[Empleados] e
	LEFT OUTER JOIN [DOTNETPY].[Usuarios] u ON e.Dni = u.DniEmpleado
	WHERE u.DniEmpleado IS NULL
END


GO

/****** Object:  StoredProcedure [DOTNETPY].[GetFactura]    Script Date: 06/09/2011 08:30:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetFactura]
	@FacturaNro int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT Nro, Fecha, DniCliente, DniEmpleado, SucursalId, FormaPagoId, Cuotas, Subtotal, Descuento, Total,
		Cuotas - (SELECT SUM(Cuotas)
					FROM [DOTNETPY].[FacturaPagos]
					WHERE FacturaNro = Nro) AS CuotasRestantes
	FROM [DOTNETPY].[Facturas]
	WHERE Nro = @FacturaNro
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetFacturasImpagas]    Script Date: 06/09/2011 08:30:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetFacturasImpagas]
	@SucursalId int,
	@DniCliente int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT Nro, Fecha, DniCliente, DniCliente, SucursalId, FormaPagoId, Cuotas, Subtotal, Descuento, Total,
		Cuotas - (SELECT ISNULL(SUM(Cuotas), 0)
					FROM [DOTNETPY].[FacturaPagos]
					WHERE FacturaNro = Nro) AS CuotasRestantes
	FROM [DOTNETPY].[Facturas]
	WHERE SucursalId = @SucursalId
		AND DniCliente = @DniCliente
		AND Cuotas - (SELECT ISNULL(SUM(Cuotas), 0)
						FROM [DOTNETPY].[FacturaPagos]
						WHERE FacturaNro = Nro) > 0
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetFuncionalidades]    Script Date: 06/09/2011 08:30:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetFuncionalidades]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT Id, Descripcion
    FROM [DOTNETPY].[Funcionalidades]
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetMarcas]    Script Date: 06/09/2011 08:30:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetMarcas]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Id, Descripcion
	FROM [DOTNETPY].[ProductoMarcas]
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetMejoresCategorias]    Script Date: 06/09/2011 08:30:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetMejoresCategorias]
	@SucursalId int,
	@Anio int
AS
BEGIN
	SET NOCOUNT ON;

	WITH Ventas AS
	(
		SELECT ProductoId, CategoriaId, Precio, Cantidad, DniEmpleado
		FROM DOTNETPY.VentasProductos
		WHERE SucursalId = @SucursalId
			AND YEAR(Fecha) = @Anio
	)
	SELECT
		(SELECT Nombre FROM [DOTNETPY].[CategoriasProductos] WHERE Id = CategoriaMayorId) AS [Categoría],
		[Sub-categorías],
		(SELECT SUM(Precio * Cantidad)
			FROM Ventas
			WHERE [DOTNETPY].[GetCategoriaMayor](CategoriaId) = CategoriaMayorId) AS [Total Facturado],
		(SELECT TOP 1 (SELECT CONVERT(nvarchar, Id) + ' ' + Nombre FROM DOTNETPY.Productos WHERE Id = ProductoId)
			FROM Ventas v
			WHERE [DOTNETPY].[GetCategoriaMayor](CategoriaId) = CategoriaMayorId
			GROUP BY ProductoId) AS [Producto más Vendido],
		(SELECT TOP 1 (SELECT CONVERT(nvarchar, Id) + ' ' + Nombre + ' $ ' + CONVERT(nvarchar, SUM(v.Precio * Cantidad)) FROM DOTNETPY.Productos WHERE Id = ProductoId)
			FROM Ventas v
			WHERE [DOTNETPY].[GetCategoriaMayor](CategoriaId) = CategoriaMayorId
			GROUP BY ProductoId
			ORDER BY SUM(Precio * Cantidad) DESC) AS [Producto que más facturó],
		(SELECT TOP 1 (SELECT CONVERT(nvarchar, Id) + ' ' + Nombre + ' $ ' + CONVERT(nvarchar, MAX(v.Precio)) FROM DOTNETPY.Productos WHERE Id = ProductoId)
			FROM Ventas v
			WHERE [DOTNETPY].[GetCategoriaMayor](CategoriaId) = CategoriaMayorId
			GROUP BY ProductoId
			ORDER BY MAX(Precio) DESC) AS [Producto vendido más caro],
		(SELECT TOP 1 (SELECT Nombre + ' ' + Apellido FROM DOTNETPY.Empleados WHERE Dni = DniEmpleado)
			FROM Ventas v
			WHERE [DOTNETPY].[GetCategoriaMayor](CategoriaId) = CategoriaMayorId
			GROUP BY DniEmpleado
			ORDER BY SUM(Cantidad) DESC) AS [MayorVendedor]
	FROM (SELECT DISTINCT [DOTNETPY].[GetCategoriaMayor](Id) AS [CategoriaMayorId], COUNT(*) - 1 AS [Sub-categorías]
			FROM [DOTNETPY].[CategoriasProductos]
			GROUP BY [DOTNETPY].[GetCategoriaMayor](Id)) AS c
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetPermisosByUsuario]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetPermisosByUsuario]
	@DniUsuario int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT DISTINCT FuncionalidadId
    FROM DOTNETPY.UsuarioRoles ur
    INNER JOIN DOTNETPY.RolFuncionalidades rf ON ur.RolId = rf.RolId
    WHERE ur.DniEmpleado = @DniUsuario
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetProducto]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetProducto]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT p.Id, p.MarcaId, m.Descripcion AS Marca, p.Nombre, p.Descripcion, p.CategoriaId, p.Precio, p.Activo
    FROM [DOTNETPY].[Productos] p
    INNER JOIN [DOTNETPY].[ProductoMarcas] m ON p.MarcaId = m.Id
    WHERE p.Id = @Id
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetProductos]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetProductos]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT p.Id, p.MarcaId, m.Descripcion AS Marca, Nombre, p.Descripcion, p.CategoriaId, p.Precio, p.Activo
    FROM [DOTNETPY].[Productos] p
    INNER JOIN [DOTNETPY].[ProductoMarcas] m ON p.MarcaId = m.Id
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetProductosByFiltros]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetProductosByFiltros]
	@Id int = NULL,
	@NombreMarca nvarchar(100) = NULL,
	@CategoriaId int = NULL,
	@PrecioFrom float = NULL,
	@PrecioTo float = NULL,
	@Activo bit = NULL
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @sql nvarchar(MAX)
	
	SET @sql =
'	SELECT p.Id, p.MarcaId, m.Descripcion AS Marca, p.Nombre, p.Descripcion, p.CategoriaId, p.Precio, p.Activo
    FROM [DOTNETPY].[Productos] p
	INNER JOIN [DOTNETPY].[ProductoMarcas] m ON p.MarcaId = m.Id
    WHERE 1 = 1'
    
    IF @Id IS NOT NULL AND @Id > 0
		SET @sql = @sql + ' AND p.Id = @Id'
	
	IF @NombreMarca IS NOT NULL
	BEGIN
		SET @NombreMarca = @NombreMarca + '%'
		SET @sql = @sql + ' AND (m.Descripcion LIKE @NombreMarca OR p.Nombre LIKE @NombreMarca)'
	END
	
	IF @CategoriaId IS NOT NULL AND @CategoriaId > 0
		SET @sql = @sql + ' AND p.CategoriaId = @CategoriaId'
	
	IF @PrecioFrom IS NOT NULL AND @PrecioFrom > 0
		SET @sql = @sql + ' AND p.Precio >= @PrecioFrom'
		
	IF @PrecioTo IS NOT NULL AND @PrecioTo > 0
		SET @sql = @sql + ' AND p.Precio <= @PrecioTo'
		
	IF @Activo IS NOT NULL
		SET @sql = @sql + ' AND p.Activo = @Activo'

	EXEC sp_executesql @sql,
		N'@Id int, @NombreMarca nvarchar(100), @CategoriaId int, @PrecioFrom float, @PrecioTo float, @Activo bit',
		@Id,
		@NombreMarca,
		@CategoriaId,
		@PrecioFrom,
		@PrecioTo,
		@Activo
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetProductoStocks]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetProductoStocks]
	@ProductoId int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT ProductoId, SucursalId, Cantidad
    FROM DOTNETPY.ProductoStocks
    WHERE ProductoId = @ProductoId
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetProductoStocksBySucursal]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetProductoStocksBySucursal]
	@SucursalId int,
	@ProductosIds nvarchar(2048)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
		ps.ProductoId,
		ps.SucursalId,
		ps.Cantidad
	FROM [DOTNETPY].[ProductoStocks] ps
	INNER JOIN [DOTNETPY].[StringSplit](@ProductosIds, ',') p ON ps.ProductoId = cadena
	WHERE SucursalId = @SucursalId 
END

GO


/****** Object:  StoredProcedure [DOTNETPY].[GetRol]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [DOTNETPY].[GetRol]
	@Id int
AS
BEGIN
	SET NOCOUNT ON;

    SELECT Id, Nombre, rf.FuncionalidadId, Activo
    FROM [DOTNETPY].[Roles] r
    INNER JOIN [DOTNETPY].[RolFuncionalidades] rf ON r.Id = rf.RolId
    WHERE Id = @Id
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetRoles]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetRoles]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT Id, Nombre, rf.FuncionalidadId, Activo
    FROM [DOTNETPY].[Roles] r
    INNER JOIN [DOTNETPY].[RolFuncionalidades] rf ON r.Id = rf.RolId 
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetRolesByFiltros]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetRolesByFiltros]
	@Id int = NULL,
	@Nombre nvarchar(100) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SET @Nombre = @Nombre + '%'

	DECLARE @sql nvarchar(MAX)
	
	SET @sql =
N'	SELECT Id, Nombre, rf.FuncionalidadId, Activo
    FROM [DOTNETPY].[Roles] r
    INNER JOIN [DOTNETPY].[RolFuncionalidades] rf ON r.Id = rf.RolId
    WHERE 1 = 1'
    
    IF @Id IS NOT NULL AND @Id > 0
		SET @sql = @sql + ' AND r.Id = @Id'
	
	IF @Nombre IS NOT NULL
	BEGIN
		SET @Nombre = @Nombre + '%'
		
		SET @sql = @sql + ' AND r.Nombre LIKE @Nombre'
	END
	
	EXEC sp_executesql @sql,
		N'@Id int, @Nombre nvarchar(100)',
		@Id,
		@Nombre
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetRolesByUsuario]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetRolesByUsuario]
	@DniEmpleado int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT r.Id, r.Nombre, r.Activo
	FROM [DOTNETPY].[Roles] r
	INNER JOIN [DOTNETPY].[UsuarioRoles] ur ON r.Id = ur.RolId
	WHERE ur.DniEmpleado = @DniEmpleado
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetSucuralFiltros]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetSucuralFiltros]
AS
BEGIN
	SET NOCOUNT ON;

	EXEC DOTNETPY.GetProvincias
	EXEC DOTNETPY.GetSucursales
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetTableroControl]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetTableroControl]
	@SucursalId int,
	@Anio int
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @faltanteStock TABLE (
		ProductoFaltanteStock int,
		DiasFaltanteStock int
	)
	
	insert into @faltanteStock EXEC DOTNETPY.MayorStockFaltante @SucursalId, @Anio
	
	SELECT
		COUNT(*) AS [TotalVentas],
		SUM(Total) AS [TotalFacturacion],
		SUM(CASE FormaPagoId WHEN 1 THEN 1 ELSE 0 END) AS [FacturasEfectivo],
		MAX(Total) AS [MayorFactura],
		(SELECT TOP 1 ISNULL((SELECT Nombre + ' ' + Apellido + ' DNI ' + CONVERT(nvarchar, Dni)
								FROM [DOTNETPY].[Clientes]
								WHERE Dni = t.DniCliente), '(ninguno)')
		FROM (
			SELECT
				f.DniCliente, f.Total, SUM(fp.Monto) AS Pagos
			FROM [DOTNETPY].[Facturas] f
			LEFT JOIN [DOTNETPY].[FacturaPagos] fp ON f.Nro = fp.FacturaNro
			WHERE SucursalId = @SucursalId
				AND YEAR(f.Fecha) = @Anio
				AND YEAR(fp.Fecha) = @Anio
			GROUP BY f.DniCliente, f.Nro, f.Total) AS t
		GROUP BY t.DniCliente
		ORDER BY SUM(t.Total) - ISNULL(SUM(t.Pagos), 0) DESC) AS [MayorDeudor],
		(SELECT Nombre + ' ' + Apellido + ' DNI ' + CONVERT(nvarchar, Dni)
			FROM [DOTNETPY].[Empleados]
			WHERE Dni = (SELECT TOP 1 DniEmpleado
						FROM [DOTNETPY].[Facturas]
						WHERE SucursalId = @SucursalId
							AND YEAR(Fecha) = @Anio
						GROUP BY DniEmpleado
						ORDER BY SUM(Total) DESC)) AS [VendedorAnio],
		(SELECT CONVERT(nvarchar, Id) + ' ' + Nombre + ' ' + [DOTNETPY].[GetCategoriaDescripcion](CategoriaId)
			FROM [DOTNETPY].[Productos]
			WHERE Id = (SELECT TOP 1 ProductoId
						FROM [DOTNETPY].[FacturaProductos] fp
						INNER JOIN [DOTNETPY].[Facturas] f ON fp.FacturaNro = f.Nro
						WHERE SucursalId = @SucursalId
							AND YEAR(Fecha) = @Anio
						GROUP BY ProductoId
						ORDER BY SUM(Cantidad) DESC)) AS [ProductoAnio],
		(SELECT CONVERT(nvarchar,ProductoFaltanteStock)+' '+ CONVERT(nvarchar,DiasFaltanteStock) 
			FROM @faltanteStock) AS FaltanteStock
	FROM [DOTNETPY].[Facturas]
	WHERE SucursalId = @SucursalId
		AND YEAR(Fecha) = @Anio
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetUsuario]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetUsuario]
	@Dni int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT u.DniEmpleado, u.Username, u.Password, u.Intentos, u.Activo, e.Dni, e.Nombre, e.Apellido, e.Mail, e.Direccion, e.TipoEmpleadoId, e.ProvinciaId, e.SucursalId, e.Activo
	FROM DOTNETPY.Usuarios u
	INNER JOIN DOTNETPY.Empleados e ON e.Dni = u.DniEmpleado
	WHERE u.DniEmpleado = @Dni
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetUsuarioByUsername]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[GetUsuarioByUsername]
	@Username varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT u.DniEmpleado, u.Username, u.Password, u.Intentos, u.Activo, e.Dni, e.Nombre, e.Apellido, e.Mail, e.Direccion, e.TipoEmpleadoId, e.ProvinciaId, e.SucursalId, e.Activo
	FROM DOTNETPY.Usuarios u
	INNER JOIN DOTNETPY.Empleados e ON e.Dni = u.DniEmpleado
	WHERE u.Username = @Username
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetUsuarios]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [DOTNETPY].[GetUsuarios]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT u.DniEmpleado, u.Username, u.Password, u.Intentos, u.Activo, e.Dni, e.Nombre, e.Apellido, e.Mail, e.Direccion, e.TipoEmpleadoId, e.ProvinciaId, e.SucursalId, e.Activo
	FROM DOTNETPY.Usuarios u
	INNER JOIN DOTNETPY.Empleados e ON e.Dni = u.DniEmpleado
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[GetUsuariosByFiltros]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [DOTNETPY].[GetUsuariosByFiltros]
	@Dni int = NULL,
	@Nombre varchar(40) = NULL,
	@Apellido varchar(40) = NULL,
	@TipoEmpleadoId int = NULL,
	@ProvinciaId int = NULL,
	@SucursalId int = NULL
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @sql nvarchar(MAX)
	
	SET @sql =
'	SELECT u.DniEmpleado, u.Username, u.Password, u.Intentos, u.Activo, e.Dni, e.Nombre, e.Apellido, e.Mail, e.Direccion, e.TipoEmpleadoId, e.ProvinciaId, e.SucursalId, e.Activo
	FROM DOTNETPY.Usuarios u
	INNER JOIN DOTNETPY.Empleados e ON e.Dni = u.DniEmpleado
	WHERE 1 = 1'
	
	IF @Dni IS NOT NULL AND @Dni > 0
		SET @sql = @sql + ' AND u.DniEmpleado = @Dni'
	
	IF @Nombre IS NOT NULL
	BEGIN
		SET @Nombre = @Nombre + '%'
		SET @sql = @sql + ' AND e.Nombre LIKE @Nombre'
	END
	
	IF @Apellido IS NOT NULL
	BEGIN
		SET @Apellido = @Apellido + '%'
		SET @sql = @sql + ' AND e.Apellido LIKE @Apellido'
	END
	
	IF @TipoEmpleadoId IS NOT NULL AND @TipoEmpleadoId > 0
		SET @sql = @sql + ' AND e.TipoEmpleadoId = @TipoEmpleadoId'
	
	IF @ProvinciaId IS NOT NULL AND @ProvinciaId > 0
		SET @sql = @sql + ' AND e.ProvinciaId = @ProvinciaId'
	
	IF @SucursalId IS NOT NULL AND @SucursalId > 0
		SET @sql = @sql + ' AND e.SucursalId = @SucursalId'
		
	EXEC sp_executesql @sql,
		N'@Dni int, @Nombre nvarchar(40), @Apellido nvarchar(40), @TipoEmpleadoId int, @ProvinciaId int, @SucursalId int',
		@Dni,
		@Nombre,
		@Apellido,
		@TipoEmpleadoId,
		@ProvinciaId,
		@SucursalId
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[MayorStockFaltante]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[MayorStockFaltante]
	@Sucursal int,
	@Anio int
AS
BEGIN
	CREATE TABLE #TMP_StockFaltante (
		ProductoId int,
		Fecha datetime,
		Cantidad int,
		Acumulado int
	)
	insert into #TMP_StockFaltante  (ProductoId,Fecha,Cantidad)
	SELECT ProductoId,fechaIngreso, Cantidad
	from DOTNETPY.IngresoStocks INS
	where INS.SucursalId=@Sucursal
	and Year(INS.FechaIngreso) <= @anio
	UNION
	SELECT ProductoId, Fecha,-Cantidad
	from DOTNETPY.Facturas F,
		 DOTNETPY.FacturaProductos FP
	where F.SucursalId=@Sucursal
	and Year(Fecha)<=@anio
	and F.Nro = FP.FacturaNro

	-- Valores de test, para que devuelva algo
	INSERT INTO #TMP_StockFaltante (ProductoId,Fecha,Cantidad)
	VALUES(1248681618,'2005-01-08',-15)
	INSERT INTO #TMP_StockFaltante (ProductoId,Fecha,Cantidad)
	VALUES(1248681618,'2005-01-15',-22)
	INSERT INTO #TMP_StockFaltante (ProductoId,Fecha,Cantidad)
	VALUES(1248681619,'2005-01-18',-16)
	

	UPDATE #TMP_StockFaltante  set Acumulado = (select sum(Cantidad)
	from #TMP_StockFaltante  A
	where A.ProductoId=#TMP_StockFaltante.ProductoId
	and A.fecha<= #TMP_StockFaltante.Fecha)
	


	select TOP 1 ProductoId,sum(dias) as DiasTotal
	from
		(select ProductoId,datediff(day,
			A.Fecha,
			(select top 1 B.Fecha
			from #TMP_StockFaltante  B
			where B.Fecha>A.Fecha
			and B.ProductoId=A.ProductoId
			order by B.Fecha ASC) 
			)dias
		from #TMP_StockFaltante  A
		where A.Acumulado=0
		and Year(A.Fecha) = @anio) Z
	group by ProductoId
	ORDER BY DiasTotal DESC
	
	DROP TABLE #TMP_StockFaltante
END

GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[SetEnableCliente]
	@Dni int,
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [DOTNETPY].[Clientes]
    SET Activo = @Activo
    WHERE Dni = @Dni
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[SetEnableEmpleado]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[SetEnableEmpleado]
	@Dni int,
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [DOTNETPY].[Empleados]
    SET Activo = @Activo
    WHERE Dni = @Dni
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[SetEnableProducto]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [DOTNETPY].[SetEnableProducto]
	@Id int,
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [DOTNETPY].[Productos]
    SET Activo = @Activo
    WHERE Id = @Id
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[SetEnableRol]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[SetEnableRol]
	@Id int,
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [DOTNETPY].[Roles]
	SET Activo = @Activo
	WHERE Id = @Id
	
	IF @Activo = 0
		DELETE FROM [DOTNETPY].[UsuarioRoles]
		WHERE RolId = @Id
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[SetEnableUsuario]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[SetEnableUsuario]
	@Dni int,
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [DOTNETPY].[Usuarios]
    SET Activo = @Activo
    WHERE DniEmpleado = @Dni
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[SetUsuarioIntentos]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[SetUsuarioIntentos]
	@DniEmpleado int,
	@Intentos int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE DOTNETPY.Usuarios
	SET Intentos = @Intentos
	WHERE DniEmpleado = @DniEmpleado
END
GO

/****** Object:  StoredProcedure [DOTNETPY].[UpdateCliente]    Script Date: 06/09/2011 08:30:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[UpdateCliente] 
	@Dni int,
	@Nombre nvarchar(40),
	@Apellido nvarchar(40),
	@Mail nvarchar(50),
	@Telefono nvarchar(40),
	@Direccion nvarchar(100),
	@ProvinciaId int
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [DOTNETPY].[Clientes]
	SET Nombre = @Nombre,
		Apellido = @Apellido,
		Mail = @Mail,
		Telefono = @Telefono,
		Direccion = @Direccion,
		ProvinciaId = @ProvinciaId
	WHERE Dni = @Dni
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[UpdateEmpleado]    Script Date: 06/09/2011 08:30:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[UpdateEmpleado] 
	@Dni int,
	@Nombre nvarchar(40),
	@Apellido nvarchar(40),
	@Mail nvarchar(50),
	@Direccion nvarchar(100),
	@Telefono nvarchar(40)
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE DOTNETPY.Empleados
    SET Nombre = @Nombre,
		Apellido = @Apellido,
		Mail = @Mail,
		Direccion = @Direccion,
		Telefono = @Telefono
	WHERE Dni = @Dni
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[UpdateProducto]    Script Date: 06/09/2011 08:30:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [DOTNETPY].[UpdateProducto]
	@Id int,
	@MarcaId int,
	@Nombre nvarchar(100),
	@Descripcion nvarchar(100),
	@Precio float
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [DOTNETPY].[Productos]
	SET MarcaId = @MarcaId,
		Nombre = @Nombre,
		Descripcion = @Descripcion,
		Precio = @Precio
	WHERE Id = @Id
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[UpdateRol]    Script Date: 06/09/2011 08:30:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [DOTNETPY].[UpdateRol]
	@Id int,
	@Nombre nvarchar(100),
	@FuncionalidadesIds nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [DOTNETPY].[Roles]
	SET Nombre = @Nombre
	WHERE Id = @Id
	
	DELETE [DOTNETPY].[RolFuncionalidades]
	WHERE RolId = @Id
	
	INSERT INTO [DOTNETPY].[RolFuncionalidades] (RolId, FuncionalidadId)
	SELECT @Id, cadena
	FROM [DOTNETPY].[StringSplit](@FuncionalidadesIds, ',')
END

GO

/****** Object:  StoredProcedure [DOTNETPY].[UpdateUsuario]    Script Date: 06/09/2011 08:30:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [DOTNETPY].[UpdateUsuario] 
	@Dni int,
	@Password nvarchar(100),
	@RolesIds nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE [DOTNETPY].[Usuarios]
	SET [Password] = @Password
	WHERE DniEmpleado = @Dni

	DELETE [DOTNETPY].[UsuarioRoles]
	WHERE DniEmpleado = @Dni
	
	INSERT INTO [DOTNETPY].[UsuarioRoles]
	SELECT @Dni, cadena
	FROM [DOTNETPY].[StringSplit](@RolesIds, ',')
END

GO

PRINT ('Fin de Creacion de Stored Procedures')
