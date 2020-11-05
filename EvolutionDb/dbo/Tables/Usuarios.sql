CREATE TABLE [dbo].[Usuarios] (
    [UsuID]     INT           IDENTITY (1, 1) NOT NULL,
    [UsuNombre] NVARCHAR (50) NOT NULL,
    [UsuPass]   NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_dbo.Usuarios] PRIMARY KEY CLUSTERED ([UsuID] ASC)
);

