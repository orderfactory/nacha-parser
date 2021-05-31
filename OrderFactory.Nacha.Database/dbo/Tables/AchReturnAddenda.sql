CREATE TABLE [dbo].AchReturnAddenda
(
    [Id]                       UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [RecordType]               TINYINT          NOT NULL DEFAULT 7,
    [AddendaTypeCode]          TINYINT          NOT NULL DEFAULT 99,
    [ReturnReasonCode]         NCHAR(3)         NOT NULL,
    [OriginalEntryTraceNumber] NVARCHAR(15)     NOT NULL,
    [DateOfDeath]              DATETIME2        NOT NULL,
    [OriginalReceivingDfiId]   NCHAR(8)         NOT NULL,
    [AddendaInformation]       NVARCHAR(44)     NULL,
    [CorrectedData]            NVARCHAR(29)     NULL,
    [Reserved]                 NVARCHAR(15)     NULL,
    [TraceNumber]              NVARCHAR(15)     NOT NULL,
    [AchEntryId]             UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_AchReturnAddenda_ToAchEntry] FOREIGN KEY ([AchEntryId]) REFERENCES [dbo].[AchEntry]([Id]) ON DELETE CASCADE
)
