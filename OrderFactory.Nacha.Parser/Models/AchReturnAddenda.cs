using System;

namespace OrderFactory.Nacha.Parser.Models
{
    public class AchReturnAddenda : AchBase
    {
        public AchReturnAddenda(Guid id, byte recordType, byte addendaTypeCode, string returnReasonCode,
            string originalEntryTraceNumber, string originalReceivingDfiId, string? correctedData, string traceNumber,
            Guid achEntryId)
        {
            Id = id;
            RecordType = recordType;
            AddendaTypeCode = addendaTypeCode;
            ReturnReasonCode = returnReasonCode;
            OriginalEntryTraceNumber = originalEntryTraceNumber;
            OriginalReceivingDfiId = originalReceivingDfiId;
            CorrectedData = correctedData;
            TraceNumber = traceNumber;
            AchEntryId = achEntryId;
        }

        public AchReturnAddenda(Guid id, string nachaString, Guid achEntryId)
        {
            CheckNachaString(nachaString, "ACH return addenda string must be 94 characters long");

            Id = id;
            RecordType = Convert.ToByte(nachaString[..1]);
            AddendaTypeCode = Convert.ToByte(nachaString[1..3]);
            ReturnReasonCode = nachaString[3..6].TrimEnd();
            OriginalEntryTraceNumber = nachaString[6..21].TrimEnd();
            OriginalReceivingDfiId = nachaString[27..35].TrimEnd();
            CorrectedData = nachaString[35..64].TrimEnd();
            TraceNumber = nachaString[79..94].TrimEnd();
            AchEntryId = achEntryId;
        }

        public Guid Id { get; }
        public byte RecordType { get; }
        public byte AddendaTypeCode { get; }
        public string ReturnReasonCode { get; }
        public string OriginalEntryTraceNumber { get; }
        public string OriginalReceivingDfiId { get; }
        public string? CorrectedData { get; }
        public string TraceNumber { get; }
        public Guid AchEntryId { get; }
    }
}