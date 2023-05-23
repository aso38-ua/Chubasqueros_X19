

drop table [dbo].[Producto];
drop table [dbo].[Categoría];

CREATE TABLE [dbo].[Producto] (
    [codigo] INT IDENTITY(1, 1) NOT NULL,
    [nombre] NVARCHAR(100) NOT NULL,
    [descripcion] NVARCHAR(500) NULL,
    [stock] INT NOT NULL,
    [precio] DECIMAL(10, 2) NOT NULL,
    [codCategoria] INT NOT NULL,
    PRIMARY KEY (codigo)
);

CREATE TABLE [dbo].[Categoría] (
    [codCategoria] INT IDENTITY(1, 1) NOT NULL,
    [nombre] NVARCHAR(100) NOT NULL,
    PRIMARY KEY CLUSTERED (codCategoria)
);


