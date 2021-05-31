CREATE TABLE [dbo].[AchFile]
(
    [Id]                       UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
    [RecordType]               TINYINT          NOT NULL DEFAULT 1,
    [PriorityCode]             TINYINT          NOT NULL,
    [ImmediateDestination]     NCHAR(9)         NOT NULL,
    [ImmediateOrigin]          NCHAR(9)         NOT NULL,
    [CreationDateTime]         DATETIME2        NOT NULL,
    [FileIdModifier]           NCHAR(1)         NOT NULL,
    [RecordSize]               SMALLINT         NOT NULL DEFAULT 094,
    [BlockingFactor]           TINYINT          NOT NULL DEFAULT 10,
    [FormatCode]               TINYINT          NOT NULL DEFAULT 1,
    [ImmediateDestinationName] NVARCHAR(23)     NOT NULL,
    [ImmediateOriginName]      NVARCHAR(23)     NOT NULL,
    [ReferenceCode]            NVARCHAR(8)      NOT NULL,
    [ControlRecordType]        TINYINT          NOT NULL DEFAULT 9,
    [BatchCount]               INT              NOT NULL,
    [BlockCount]               INT              NOT NULL,
    [EntryAndAddendaCount]     INT              NOT NULL,
    [EntryHash]                NUMERIC(10, 0)   NOT NULL,
    [TotalDebitAmount]         DECIMAL(20, 2)   NOT NULL,
    [TotalCreditAmount]        DECIMAL(20, 2)   NOT NULL,
    [Reserved]                 NVARCHAR(39)     NOT NULL
)
