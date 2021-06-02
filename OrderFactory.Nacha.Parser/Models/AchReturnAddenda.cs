using System;

namespace OrderFactory.Nacha.Parser.Models
{
    public class AchReturnAddenda
    {
        public AchReturnAddenda(Guid id, byte recordType, byte addendaTypeCode, string returnReasonCode,
            string originalEntryTraceNumber, DateTime dateOfDeath, string originalReceivingDfiId,
            string? addendaInformation, string? correctedData, string? reserved, string traceNumber, Guid achEntryId)
        {
            Id = id;
            RecordType = recordType;
            AddendaTypeCode = addendaTypeCode;
            ReturnReasonCode = returnReasonCode;
            OriginalEntryTraceNumber = originalEntryTraceNumber;
            DateOfDeath = dateOfDeath;
            OriginalReceivingDfiId = originalReceivingDfiId;
            AddendaInformation = addendaInformation;
            CorrectedData = correctedData;
            Reserved = reserved;
            TraceNumber = traceNumber;
            AchEntryId = achEntryId;
        }

        public Guid Id { get; }
        public byte RecordType { get; }
        public byte AddendaTypeCode { get; }
        public string ReturnReasonCode { get; }
        public string OriginalEntryTraceNumber { get; }
        public DateTime DateOfDeath { get; }
        public string OriginalReceivingDfiId { get; }
        public string? AddendaInformation { get; }
        public string? CorrectedData { get; }
        public string? Reserved { get; }
        public string TraceNumber { get; }
        public Guid AchEntryId { get; }
    }
}