using System;
using System.Collections.Generic;
using System.Globalization;
using Dapper.Contrib.Extensions;

namespace OrderFactory.Nacha.Parser.Models
{
    [Table("AchBatch")]
    public class AchBatch : AchBase
    {
        private readonly ICollection<AchEntry> _achEntries = new List<AchEntry>();

        public AchBatch(Guid id, byte recordType, short serviceClassCode, string name, string discretionaryData,
            string identification, string entryClassCode, string entryDescription, string descriptiveDate,
            DateTime effectiveEntryDate, short settlementDateJulian, string originatorStatusCode,
            string originatingDfiId, int batchNumber, byte controlRecordType, short controlServiceClassCode,
            int entryAndAddendaCount, long entryHash, decimal totalDebitAmount, decimal totalCreditAmount,
            string controlIdentification, string messageAuthenticationCode, string reserved,
            string controlOriginatingDfiId, int controlBatchNumber, Guid achFileId)
        {
            Id = id;
            RecordType = recordType;
            ServiceClassCode = serviceClassCode;
            Name = name;
            DiscretionaryData = discretionaryData;
            Identification = identification;
            EntryClassCode = entryClassCode;
            EntryDescription = entryDescription;
            DescriptiveDate = descriptiveDate;
            EffectiveEntryDate = effectiveEntryDate;
            SettlementDateJulian = settlementDateJulian;
            OriginatorStatusCode = originatorStatusCode;
            OriginatingDfiId = originatingDfiId;
            BatchNumber = batchNumber;
            ControlRecordType = controlRecordType;
            ControlServiceClassCode = controlServiceClassCode;
            EntryAndAddendaCount = entryAndAddendaCount;
            EntryHash = entryHash;
            TotalDebitAmount = totalDebitAmount;
            TotalCreditAmount = totalCreditAmount;
            ControlIdentification = controlIdentification;
            MessageAuthenticationCode = messageAuthenticationCode;
            Reserved = reserved;
            ControlOriginatingDfiId = controlOriginatingDfiId;
            ControlBatchNumber = controlBatchNumber;
            AchFileId = achFileId;
            ParsingComplete = true;
        }

        public AchBatch(Guid id, string nachaStartString, Guid achFileId)
        {
            CheckNachaString(nachaStartString, "ACH batch start string must be 94 characters long");

            Id = id;
            RecordType = Convert.ToByte(nachaStartString[..1]);
            ServiceClassCode = Convert.ToInt16(nachaStartString[1..4]);
            Name = nachaStartString[4..20].TrimEnd();
            DiscretionaryData = nachaStartString[20..40].TrimEnd();
            Identification = nachaStartString[40..50].TrimEnd();
            EntryClassCode = nachaStartString[50..53].TrimEnd();
            EntryDescription = nachaStartString[53..63].TrimEnd();
            DescriptiveDate = nachaStartString[63..69].TrimEnd();
            EffectiveEntryDate = DateTime.ParseExact(nachaStartString[69..75], "yyMMdd", CultureInfo.InvariantCulture);
            SettlementDateJulian = Convert.ToInt16(nachaStartString[75..78]);
            OriginatorStatusCode = nachaStartString[78..79].TrimEnd();
            OriginatingDfiId = nachaStartString[79..87];
            BatchNumber = Convert.ToInt32(nachaStartString[87..94]);
            AchFileId = achFileId;
        }

        [ExplicitKey] public Guid Id { get; }
        public byte RecordType { get; }
        public short ServiceClassCode { get; }
        public string Name { get; }
        public string DiscretionaryData { get; }
        public string Identification { get; }
        public string EntryClassCode { get; }
        public string EntryDescription { get; }
        public string DescriptiveDate { get; }
        public DateTime EffectiveEntryDate { get; }
        public short SettlementDateJulian { get; }
        public string OriginatorStatusCode { get; }
        public string OriginatingDfiId { get; }
        public int BatchNumber { get; }
        public byte? ControlRecordType { get; private set; }
        public short? ControlServiceClassCode { get; private set; }
        public int? EntryAndAddendaCount { get; private set; }
        public long? EntryHash { get; private set; }
        public decimal? TotalDebitAmount { get; private set; }
        public decimal? TotalCreditAmount { get; private set; }
        public string? ControlIdentification { get; private set; }
        public string? MessageAuthenticationCode { get; private set; }
        public string? Reserved { get; private set; }
        public string? ControlOriginatingDfiId { get; private set; }
        public int? ControlBatchNumber { get; private set; }
        public Guid AchFileId { get; }
        [Write(false)] public IEnumerable<AchEntry> AchEntries => _achEntries;

        public void CompleteParsing(string nachaEndString)
        {
            CheckNachaString(nachaEndString, "ACH batch end string must be 94 characters long");

            ControlRecordType = Convert.ToByte(nachaEndString[..1]);
            ControlServiceClassCode = Convert.ToInt16(nachaEndString[1..4]);
            EntryAndAddendaCount = Convert.ToInt32(nachaEndString[4..10]);
            EntryHash = Convert.ToInt64(nachaEndString[10..20]);
            TotalDebitAmount = decimal.Parse($"{nachaEndString[20..30]}.{nachaEndString[30..32]}",
                CultureInfo.InvariantCulture);
            TotalCreditAmount = decimal.Parse($"{nachaEndString[32..42]}.{nachaEndString[42..44]}",
                CultureInfo.InvariantCulture);
            ControlIdentification = nachaEndString[44..54].TrimEnd();
            MessageAuthenticationCode = nachaEndString[54..73].TrimEnd();
            Reserved = nachaEndString[73..79].TrimEnd();
            ControlOriginatingDfiId = nachaEndString[79..87];
            ControlBatchNumber = Convert.ToInt32(nachaEndString[87..94]);
            ParsingComplete = true;
        }

        public void AddEntry(AchEntry achEntry)
        {
            _achEntries.Add(achEntry);
        }
    }
}