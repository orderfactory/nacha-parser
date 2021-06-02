using System;

namespace OrderFactory.Nacha.Parser.Models
{
    public class AchFile
    {
        public AchFile(Guid id, byte recordType, byte priorityCode, string immediateDestination, string immediateOrigin,
            DateTime creationDateTime, string fileIdModifier, short recordSize, byte blockingFactor, byte formatCode,
            string immediateDestinationName, string immediateOriginName, string referenceCode, byte controlRecordType,
            int batchCount, int blockCount, int entryAndAddendaCount, decimal entryHash, decimal totalDebitAmount,
            decimal totalCreditAmount, string reserved)
        {
            Id = id;
            RecordType = recordType;
            PriorityCode = priorityCode;
            ImmediateDestination = immediateDestination;
            ImmediateOrigin = immediateOrigin;
            CreationDateTime = creationDateTime;
            FileIdModifier = fileIdModifier;
            RecordSize = recordSize;
            BlockingFactor = blockingFactor;
            FormatCode = formatCode;
            ImmediateDestinationName = immediateDestinationName;
            ImmediateOriginName = immediateOriginName;
            ReferenceCode = referenceCode;
            ControlRecordType = controlRecordType;
            BatchCount = batchCount;
            BlockCount = blockCount;
            EntryAndAddendaCount = entryAndAddendaCount;
            EntryHash = entryHash;
            TotalDebitAmount = totalDebitAmount;
            TotalCreditAmount = totalCreditAmount;
            Reserved = reserved;
        }

        public Guid Id { get; }
        public byte RecordType { get; }
        public byte PriorityCode { get; }
        public string ImmediateDestination { get; }
        public string ImmediateOrigin { get; }
        public DateTime CreationDateTime { get; }
        public string FileIdModifier { get; }
        public short RecordSize { get; }
        public byte BlockingFactor { get; }
        public byte FormatCode { get; }
        public string ImmediateDestinationName { get; }
        public string ImmediateOriginName { get; }
        public string ReferenceCode { get; }
        public byte ControlRecordType { get; }
        public int BatchCount { get; }
        public int BlockCount { get; }
        public int EntryAndAddendaCount { get; }
        public decimal EntryHash { get; }
        public decimal TotalDebitAmount { get; }
        public decimal TotalCreditAmount { get; }
        public string Reserved { get; }
    }
}