CREATE TABLE [dbo].[Producto] (
    [codigo] INT NOT NULL,
    [nombre] NVARCHAR(100) NOT NULL,
    [descripcion] NVARCHAR(500) NULL,
    [stock] INT NOT NULL,
    [precio] DECIMAL(10, 2) NOT NULL,
    [codigoCategoria] INT NOT NULL,
    PRIMARY KEY (codigo)
);

CREATE TABLE [dbo].[Categoría] (
    [codCategoria] INT NOT NULL,
    [nombre] NVARCHAR(100) NOT NULL,
    PRIMARY KEY (codCategoria)
);