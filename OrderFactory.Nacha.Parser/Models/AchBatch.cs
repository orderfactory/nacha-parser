using System;

namespace OrderFactory.Nacha.Parser.Models
{
    public class AchBatch
    {
        public AchBatch(Guid id, byte recordType, short serviceClassCode, string name, string discretionaryData,
            string identification, string entryClassCode, string entryDescription, string descriptiveDate,
            DateTime effectiveEntryDate, short settlementDateJulian, string originatorStatusCode,
            string originatingDfiId, int batchNumber, byte controlRecordType, short controlServiceClassCode,
            int entryAndAddendaCount, decimal entryHash, decimal totalDebitAmount, decimal totalCreditAmount,
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
        }

        public Guid Id { get; }
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
        public byte ControlRecordType { get; }
        public short ControlServiceClassCode { get; }
        public int EntryAndAddendaCount { get; }
        public decimal EntryHash { get; }
        public decimal TotalDebitAmount { get; }
        public decimal TotalCreditAmount { get; }
        public string ControlIdentification { get; }
        public string MessageAuthenticationCode { get; }
        public string Reserved { get; }
        public string ControlOriginatingDfiId { get; }
        public int ControlBatchNumber { get; }
        public Guid AchFileId { get; }
    }
}