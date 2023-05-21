CREATE TABLE [dbo].[usuario] (
    [id]           INT             IDENTITY (1, 1) NOT NULL,
    [nombre]       VARCHAR (50)    NOT NULL,
    [contraseña]   VARCHAR (50)    NOT NULL,
    [email]        VARCHAR (50)    NOT NULL,
    [apellidos]    VARCHAR (50)    NULL,
    [ImagenPerfil] VARBINARY (MAX) NULL,
    [esAdmin]      BIT             DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

CREATE TABLE [dbo].[Producto] (
    [codigo] INT NOT NULL,
    [nombre] NVARCHAR(100) NOT NULL,
    [descripcion] NVARCHAR(500) NULL,
    [precio] DECIMAL(10, 2) NOT NULL,
    [stock] INT NOT NULL,
    [codCategoria] INT NOT NULL,
    PRIMARY KEY (codigo)
);

CREATE TABLE carrito (
    id INT IDENTITY(1, 1) NOT NULL,
    usuario_id INT NOT NULL,
    producto_id INT NOT NULL,
    cantidad INT NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (usuario_id) REFERENCES usuario(id),
    FOREIGN KEY (producto_id) REFERENCES producto(id)
);

CREATE TABLE pedido (
    id INT IDENTITY(1, 1) NOT NULL,
    usuario_id INT NOT NULL,
    fecha_pedido DATETIME NOT NULL,
    PRIMARY KEY (id),
    FOREIGN KEY (usuario_id) REFERENCES usuario(id)
);

CREATE TABLE Favoritos (
    usuario INT NOT NULL,
    producto INT NOT NULL,
    PRIMARY KEY (producto,usuario),
    FOREIGN KEY (usuario) REFERENCES usuario(id),
    FOREIGN KEY (producto) REFERENCES producto(codigo)
);

CREATE TABLE Reservas (
    usuario INT NOT NULL,
    producto INT NOT NULL,
    cantidad INT NOT NULL,
    ptotal VARCHAR(20) NOT NULL,
    fecha VARCHAR(50) NULL,
    PRIMARY KEY (producto,usuario),
    FOREIGN KEY (usuario) REFERENCES usuario(id),
    FOREIGN KEY (producto) REFERENCES producto(codigo)
);

CREATE TABLE [dbo].[Comentario] (
    [id_user]    INT NOT NULL,
    [item]       INT NOT NULL,
    [estrellas]  INT NOT NULL,
    [likes]      INT NULL,
    [dislikes]   INT NULL,
    [comentario] VARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_user] ASC, [item] ASC, [estrellas] ASC),
    FOREIGN KEY ([id_user], [item], [estrellas]) REFERENCES [dbo].[Puntuacion] ([id_user], [item], [estrellas])
);

CREATE TABLE [dbo].[Puntuacion] (
    [id_user]   INT NOT NULL,
    [item]      INT NOT NULL,
    [estrellas] INT NOT NULL,
    [media]     INT NOT NULL,
    [contador]  INT NOT NULL,
    PRIMARY KEY CLUSTERED ([id_user] ASC, [item] ASC, [estrellas] ASC),
    FOREIGN KEY ([id_user]) REFERENCES [dbo].[usuario] ([id]),
    FOREIGN KEY ([item]) REFERENCES [dbo].[producto] ([codigo])
);

CREATE TABLE Oferta (
    codigoOferta INT NOT NULL,
    porcentajeDescuento INT NOT NULL,
    descripcion VARCHAR(500) NOT NULL,
    img VARCHAR(500) NOT NULL,
    PRIMARY KEY (codigoOferta)
);

CREATE TABLE Servicio (
    idServicio INT NOT NULL,
    titulo VARCHAR(100) NOT NULL,
    descripcion VARCHAR(500) NOT NULL,
    img VARCHAR(500) NOT NULL,
    PRIMARY KEY (idServicio)
);

CREATE TABLE curriculum (
    id INT IDENTITY(1, 1) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    telefono VARCHAR(20) NOT NULL,
    email VARCHAR(100) NOT NULL,
    experiencia VARCHAR(MAX) NOT NULL,
    educacion VARCHAR(MAX) NOT NULL,
    PRIMARY KEY (id),
);
