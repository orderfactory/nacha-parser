CREATE TABLE [dbo].[AchEntry]
(
    [Id]                     UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [RecordType]             TINYINT          NOT NULL DEFAULT 6,
    [TransactionCode]        TINYINT          NOT NULL,
    [ReceivingDfiId]         NCHAR(8)         NOT NULL,
    [CheckDigit]             TINYINT          NOT NULL,
    [DfiAccountNumber]       NVARCHAR(17)     NOT NULL,
    [Amount]                 DECIMAL(12, 2)   NOT NULL,
    [Identification]         NVARCHAR(15)     NOT NULL,
    [AchOperator]            NCHAR(1)         NULL,
    [Name]                   NVARCHAR(22)     NOT NULL,
    [DiscretionaryData]      NVARCHAR(2)      NOT NULL,
    [AddendaRecordIndicator] TINYINT          NOT NULL,
    [TraceNumber]            NVARCHAR(15)     NULL,
    [OperatorRoutingNumber]  NCHAR(8)         NULL,
    [DateJulian]             SMALLINT         NULL,
    [SequenceNumber]         SMALLINT         NULL,
    [AchBatchId]             UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [FK_AchEntry_ToAchBatch] FOREIGN KEY ([AchBatchId]) REFERENCES [dbo].[AchBatch]([Id]) ON DELETE CASCADE
)
