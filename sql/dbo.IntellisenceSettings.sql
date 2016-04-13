CREATE TABLE [dbo].[IntellisenceSettings] (
    [id]            INT     IDENTITY (1, 1) NOT NULL,
    [Intellisense]  TINYINT NOT NULL,
    [Result_limit]  INT     NOT NULL,
    [Debounce_Time] INT     NOT NULL,
    CONSTRAINT [PK_id] PRIMARY KEY CLUSTERED ([id] ASC)
);

