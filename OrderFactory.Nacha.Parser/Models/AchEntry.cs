using System;
using System.Globalization;

namespace OrderFactory.Nacha.Parser.Models
{
    public class AchEntry : AchBase
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
            ParsingComplete = true;
        }

        public AchEntry(Guid id, string nachaString, Guid achBatchId)
        {
            CheckNachaString(nachaString, "ACH entry string must be 94 characters long");

            Id = id;
            RecordType = Convert.ToByte(nachaString[..1]);
            TransactionCode = Convert.ToByte(nachaString[1..3]);
            ReceivingDfiId = nachaString[3..11].TrimEnd();
            CheckDigit = Convert.ToByte(nachaString[11..12]);
            DfiAccountNumber = nachaString[12..29].TrimEnd();
            Amount = decimal.Parse($"{nachaString[29..37]}.{nachaString[37..39]}", CultureInfo.InvariantCulture);
            Identification = nachaString[39..54].TrimEnd();
            AchOperator = null;
            Name = nachaString[54..76].TrimEnd();
            DiscretionaryData = nachaString[76..78].TrimEnd();
            AddendaRecordIndicator = Convert.ToByte(nachaString[78..79]);
            TraceNumber = nachaString[79..94].TrimEnd();
            OperatorRoutingNumber = null;
            DateJulian = null;
            SequenceNumber = null;
            AchBatchId = achBatchId;
            ParsingComplete = true;
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

        public AchReturnAddenda? AchReturnAddenda { get; private set; }

        public void SetReturnAddenda(AchReturnAddenda achReturnAddenda)
        {
            AchReturnAddenda = achReturnAddenda;
        }
    }
}