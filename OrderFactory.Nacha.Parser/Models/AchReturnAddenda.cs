using System;
using System.Globalization;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace OrderFactory.Nacha.Parser.Models
{
    [Table("AchReturnAddenda")]
    public class AchReturnAddenda : AchBase
    {
        private readonly string[] _deceasedReasonCodes = {"R14", "R15"};

        public AchReturnAddenda(Guid id, byte recordType, byte addendaTypeCode, string achReasonCodeId,
            string originalEntryTraceNumber, DateTime? dateOfDeath, string originalReceivingDfiId,
            string? addendaData, string traceNumber, Guid achEntryId)
        {
            Id = id;
            RecordType = recordType;
            AddendaTypeCode = addendaTypeCode;
            AchReasonCodeId = achReasonCodeId;
            OriginalEntryTraceNumber = originalEntryTraceNumber;
            DateOfDeath = dateOfDeath;
            OriginalReceivingDfiId = originalReceivingDfiId;
            AddendaData = addendaData;
            TraceNumber = traceNumber;
            AchEntryId = achEntryId;
            ParsingComplete = true;
        }

        public AchReturnAddenda(Guid id, string nachaString, Guid achEntryId)
        {
            CheckNachaString(nachaString, "ACH return addenda string must be 94 characters long");

            Id = id;
            RecordType = Convert.ToByte(nachaString[..1]);
            AddendaTypeCode = Convert.ToByte(nachaString[1..3]);
            AchReasonCodeId = nachaString[3..6].TrimEnd().ToUpper();
            OriginalEntryTraceNumber = nachaString[6..21].TrimEnd();
            DateOfDeath = _deceasedReasonCodes.Contains(AchReasonCodeId, StringComparer.InvariantCultureIgnoreCase)
                ? DateTime.ParseExact(nachaString[21..27], "yyMMdd", CultureInfo.InvariantCulture)
                : (DateTime?) null;
            OriginalReceivingDfiId = nachaString[27..35].TrimEnd();
            AddendaData = nachaString[35..79].TrimEnd();
            TraceNumber = nachaString[79..94].TrimEnd();
            AchEntryId = achEntryId;
            ParsingComplete = true;
        }

        [ExplicitKey] public Guid Id { get; }
        public byte RecordType { get; }
        public byte AddendaTypeCode { get; }
        public string AchReasonCodeId { get; }
        public string OriginalEntryTraceNumber { get; }
        public DateTime? DateOfDeath { get; }
        public string OriginalReceivingDfiId { get; }
        public string? AddendaData { get; }
        public string TraceNumber { get; }
        public Guid AchEntryId { get; }
    }
}