CREATE TABLE [dbo].[Productos] (
    [ProID]    INT           IDENTITY (1, 1) NOT NULL,
    [ProDesc]  NVARCHAR (50) NOT NULL,
    [ProValor] MONEY         NOT NULL,
    CONSTRAINT [PK_dbo.Productoes] PRIMARY KEY CLUSTERED ([ProID] ASC)
);

