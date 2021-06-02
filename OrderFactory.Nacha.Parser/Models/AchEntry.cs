using System;

namespace OrderFactory.Nacha.Parser.Models
{
    public class AchEntry
    {
        public AchEntry(Guid id, byte recordType, byte transactionCode, string receivingDfiId, byte checkDigit,
            string dfiAccountNumber, decimal amount, string identification, string? achOperator, string name,
            string discretionaryData, byte addendaRecordIndicator, string? traceNumber, string? operatorRoutingNumber,
            short? dateJulian, short? sequenceNumber, Guid achBatchId)
        {
            Id = id;
            RecordType = recordType;
            TransactionCode = transactionCode;
            ReceivingDfiId = receivingDfiId;
            CheckDigit = checkDigit;
            DfiAccountNumber = dfiAccountNumber;
            Amount = amount;
            Identification = identification;
            AchOperator = achOperator;
            Name = name;
            DiscretionaryData = discretionaryData;
            AddendaRecordIndicator = addendaRecordIndicator;
            TraceNumber = traceNumber;
            OperatorRoutingNumber = operatorRoutingNumber;
            DateJulian = dateJulian;
            SequenceNumber = sequenceNumber;
            AchBatchId = achBatchId;
        }

        public Guid Id { get; }
        public byte RecordType { get; }
        public byte TransactionCode { get; }
        public string ReceivingDfiId { get; }
        public byte CheckDigit { get; }
        public string DfiAccountNumber { get; }
        public decimal Amount { get; }
        public string Identification { get; }
        public string? AchOperator { get; }
        public string Name { get; }
        public string DiscretionaryData { get; }
        public byte AddendaRecordIndicator { get; }
        public string? TraceNumber { get; }
        public string? OperatorRoutingNumber { get; }
        public short? DateJulian { get; }
        public short? SequenceNumber { get; }
        public Guid AchBatchId { get; }
    }
}