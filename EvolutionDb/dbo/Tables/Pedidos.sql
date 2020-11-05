CREATE TABLE [dbo].[Pedidos] (
    [PedID]     INT   IDENTITY (1, 1) NOT NULL,
    [UsuID]     INT   NOT NULL,
    [ProID]     INT   NOT NULL,
    [PedVrUnit] MONEY NOT NULL,
    [PedCant]   REAL  NOT NULL,
    [PedSubTot] MONEY NOT NULL,
    [PedIVA]    REAL  NOT NULL,
    [PedTotal]  MONEY NOT NULL,
    CONSTRAINT [PK_dbo.Pedidoes] PRIMARY KEY CLUSTERED ([PedID] ASC),
    CONSTRAINT [FK_dbo.Pedidoes_dbo.Productoes_ProID] FOREIGN KEY ([ProID]) REFERENCES [dbo].[Productos] ([ProID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.Pedidoes_dbo.Usuarios_UsuID] FOREIGN KEY ([UsuID]) REFERENCES [dbo].[Usuarios] ([UsuID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_ProID]
    ON [dbo].[Pedidos]([ProID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_UsuID]
    ON [dbo].[Pedidos]([UsuID] ASC);

