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

CREATE TABLE producto (
    id INT IDENTITY(1, 1) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(500) NULL,
    precio DECIMAL(10, 2) NOT NULL,
    cantidad INT NOT NULL,
    imagen VARBINARY(MAX) NULL,
    PRIMARY KEY (id)
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
    FOREIGN KEY (producto) REFERENCES producto(id)
);

CREATE TABLE Reservas (
    usuario INT NOT NULL,
    producto INT NOT NULL,
    cantidad INT NOT NULL,
    ptotal VARCHAR(20) NOT NULL,
    fecha VARCHAR(50) NULL,
    PRIMARY KEY (producto,usuario),
    FOREIGN KEY (usuario) REFERENCES usuario(id),
    FOREIGN KEY (producto) REFERENCES producto(id)
);

CREATE TABLE Comentario (
    id_user INT NOT NULL,
    item INT NOT NULL,
    estrellas INT NOT NULL,
    likes INT NULL,
    dislikes INT NULL,
    comentario VARCHAR(200) NOT NULL,
    PRIMARY KEY (id_user, item, estrellas),
    FOREIGN KEY (estrellas, item, id_user) REFERENCES Puntuacion(estrellas, item, id_user)
);

CREATE TABLE Puntuacion (
    id_user INT NOT NULL,
    item INT NOT NULL,
    estrellas INT NOT NULL,
    media INT NOT NULL,
    contador INT NOT NULL,
    PRIMARY KEY (id_user, item, estrellas),
    FOREIGN KEY (id_user) REFERENCES usuario(id),
    FOREIGN KEY (item) REFERENCES producto(id)
);

CREATE TABLE Oferta (
    codigoOferta INT NOT NULL,
    fechaInicio DATE NOT NULL,
    fechaFin DATE NOT NULL,
    porcentajeDescuento FLOAT NOT NULL,
    PRIMARY KEY (codigoOferta)
);
