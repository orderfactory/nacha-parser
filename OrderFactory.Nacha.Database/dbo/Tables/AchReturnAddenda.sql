CREATE TABLE [dbo].AchReturnAddenda
(
    [Id]                       UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [RecordType]               TINYINT          NOT NULL DEFAULT 7,
    [AddendaTypeCode]          TINYINT          NOT NULL DEFAULT 99,
    [AchReasonCodeId]          NCHAR(3)         NOT NULL,
    [OriginalEntryTraceNumber] NVARCHAR(15)     NOT NULL,
    [DateOfDeath]              DATETIME2        NULL,
    [OriginalReceivingDfiId]   NCHAR(8)         NOT NULL,
    [AddendaData]              NVARCHAR(44)     NULL,
    [TraceNumber]              NVARCHAR(15)     NOT NULL,
    [AchEntryId]             UNIQUEIDENTIFIER NOT NULL,
	[DateCreated] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[DateUpdated] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[CreatedBy] SYSNAME NOT NULL DEFAULT SUSER_NAME(),
	[UpdatedBy] SYSNAME NOT NULL DEFAULT SUSER_NAME()
    CONSTRAINT [FK_AchReturnAddenda_ToAchEntry] FOREIGN KEY ([AchEntryId]) REFERENCES [dbo].[AchEntry]([Id]) ON DELETE CASCADE, 
    CONSTRAINT [FK_AchReturnAddenda_ToAchReasonCode] FOREIGN KEY ([AchReasonCodeId]) REFERENCES [dbo].[AchReasonCode]([Id])
)
