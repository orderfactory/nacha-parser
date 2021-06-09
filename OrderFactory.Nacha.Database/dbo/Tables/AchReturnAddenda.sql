CREATE TABLE [dbo].AchReturnAddenda
(
    [Id]                       UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [RecordType]               TINYINT          NOT NULL DEFAULT 7,
    [AddendaTypeCode]          TINYINT          NOT NULL DEFAULT 98,
    [ReturnReasonCode]         NCHAR(3)         NOT NULL,
    [OriginalEntryTraceNumber] NVARCHAR(15)     NOT NULL,
    [OriginalReceivingDfiId]   NCHAR(8)         NOT NULL,
    [CorrectedData]            NVARCHAR(29)     NULL,
    [TraceNumber]              NVARCHAR(15)     NOT NULL,
    [AchEntryId]             UNIQUEIDENTIFIER NOT NULL,
	[DateCreated] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[DateUpdated] DATETIME2 NOT NULL DEFAULT GETDATE(),
	[CreatedBy] SYSNAME NOT NULL DEFAULT SUSER_NAME(),
	[UpdatedBy] SYSNAME NOT NULL DEFAULT SUSER_NAME()
    CONSTRAINT [FK_AchReturnAddenda_ToAchEntry] FOREIGN KEY ([AchEntryId]) REFERENCES [dbo].[AchEntry]([Id]) ON DELETE CASCADE
)

GO

CREATE INDEX [IX_AchReturnAddenda_ReturnReasonCode] ON [dbo].[AchReturnAddenda] ([ReturnReasonCode])
