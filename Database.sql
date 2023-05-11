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
