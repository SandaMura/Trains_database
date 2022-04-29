CREATE TABLE [dbo].[Passengers booking] (
    [Number]         INT          NOT NULL,
    [ID Ride]        INT          NOT NULL,
    [Passenger name] VARCHAR (50) NULL,
    [Seat]           VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Number] ASC),
	CONSTRAINT [ID Ride] FOREIGN KEY ([ID Ride]) REFERENCES [dbo].[Train rides] ([ID Ride]) ON DELETE CASCADE
);

