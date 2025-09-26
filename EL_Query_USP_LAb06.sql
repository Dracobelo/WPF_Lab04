use Neptuno_DBB



CREATE PROC USP_ListaClientes
AS
BEGIN
SELECT idCliente 
	,NombreCompa�ia
	,NombreContacto
	,CargoContacto
	,Direccion
	,Ciudad
	,Region
	,CodPostal
	,Pais
	,Telefono
	,Fax
FROM clientes
WHERE Active = 1
END

--------------------


CREATE PROC USP_InsertarClientes
@id varchar(5),
@n_compa�ia varchar(100),
@n_contacto varchar(100),
@cargo varchar(100),
@direccion varchar(100),
@ciudad varchar(100),
@region varchar(100),
@postal varchar(100),
@pais varchar(100),
@tlf varchar(100),
@fax varchar(100)
AS
BEGIN
INSERT INTO clientes
VALUES (@id,@n_compa�ia	,@n_contacto,@cargo	,@direccion	,@ciudad,@region,@postal ,@pais	,@tlf ,@fax,1)
END

----------------------------------------------------

CREATE PROC USP_ActualizarCliente
	@id varchar(5),
	@n_compa�ia varchar(100),
	@n_contacto varchar(100),
	@cargo varchar(100),
	@direccion varchar(100),
	@ciudad varchar(100),
	@region varchar(100),
	@postal varchar(100),
	@pais varchar(100),
	@tlf varchar(100),
	@fax varchar(100)
AS
BEGIN
    UPDATE Clientes
    SET NombreCompa�ia = @n_compa�ia,
        NombreContacto = @n_contacto,
        CargoContacto = @cargo,
        Direccion = @cargo,
        Ciudad = @ciudad,
        Region = @region,
        CodPostal = @postal,
        Pais = @pais,
        Telefono = @tlf,
        Fax = @fax
    WHERE idCliente = @id
END

------------------------------

CREATE PROC USP_DeleteCliente
	@id varchar(5)
AS
BEGIN
    UPDATE Clientes
    SET Active = 0
    WHERE idCliente = @id
END

-------------------

CREATE PROC USP_ListaClientesPorNombre
@n_compa�ia varchar(100)

AS
BEGIN
SELECT idCliente 
	,NombreCompa�ia
	,NombreContacto
	,CargoContacto
	,Direccion
	,Ciudad
	,Region
	,CodPostal
	,Pais
	,Telefono
	,Fax
FROM clientes
WHERE NombreCompa�ia LIKE '%' + @n_compa�ia + '%' 
END