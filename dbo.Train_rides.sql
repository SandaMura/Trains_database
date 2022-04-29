CREATE TABLE [dbo].[Train rides] (
    [ID Ride]            INT      NOT NULL,
    [ID Train]           INT      NOT NULL,
    [ID arrival station] INT      NOT NULL,
    [Leaving time]       TIME (7) NULL,
    [Arrival time]       TIME (7) NULL,
    [Ticket price]       MONEY    NULL,
    PRIMARY KEY CLUSTERED ([ID Ride] ASC),
	CONSTRAINT [ID Train] FOREIGN KEY ([ID Train]) REFERENCES [dbo].[Trains] ([ID Train]) ON DELETE CASCADE,
    CONSTRAINT [ID arrival station] FOREIGN KEY ([ID arrival station]) REFERENCES [dbo].[Station] ([ID Station]) ON DELETE CASCADE
);

