using System;
using System.Collections.Generic;
using System.Globalization;

namespace OrderFactory.Nacha.Parser.Models
{
    public class AchFile : AchBase
    {
        private readonly ICollection<AchBatch> _achBatches = new List<AchBatch>();

        public AchFile(Guid id, byte recordType, byte priorityCode, string immediateDestination, string immediateOrigin,
            DateTime creationDateTime, string fileIdModifier, short recordSize, byte blockingFactor, byte formatCode,
            string immediateDestinationName, string immediateOriginName, string referenceCode, byte controlRecordType,
            int batchCount, int blockCount, int entryAndAddendaCount, long entryHash, decimal totalDebitAmount,
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
            ParsingComplete = true;
        }

        public AchFile(Guid id, string nachaStartString)
        {
            CheckNachaString(nachaStartString, "ACH file start string must be 94 characters long");

            Id = id;
            RecordType = Convert.ToByte(nachaStartString[..1]);
            PriorityCode = Convert.ToByte(nachaStartString[1..3]);
            ImmediateDestination = nachaStartString[4..13];
            ImmediateOrigin = nachaStartString[14..23];
            CreationDateTime =
                DateTime.ParseExact(nachaStartString[23..33], "yyMMddHHmm", CultureInfo.InvariantCulture);
            FileIdModifier = nachaStartString[33..34].TrimEnd();
            RecordSize = Convert.ToInt16(nachaStartString[34..37]);
            BlockingFactor = Convert.ToByte(nachaStartString[37..39]);
            FormatCode = Convert.ToByte(nachaStartString[39..40]);
            ImmediateDestinationName = nachaStartString[40..63].TrimEnd();
            ImmediateOriginName = nachaStartString[63..86].TrimEnd();
            ReferenceCode = nachaStartString[86..94].TrimEnd();
        }

        public void CompleteParsing(string nachaEndString)
        {
            CheckNachaString(nachaEndString, "ACH file end string must be 94 characters long");

            ControlRecordType = Convert.ToByte(nachaEndString[..1]);
            BatchCount = Convert.ToInt32(nachaEndString[1..7]);
            BlockCount = Convert.ToInt32(nachaEndString[7..13]);
            EntryAndAddendaCount = Convert.ToInt32(nachaEndString[13..21]);
            EntryHash = Convert.ToInt64(nachaEndString[21..31]);
            TotalDebitAmount = decimal.Parse($"{nachaEndString[31..41]}.{nachaEndString[41..43]}",
                CultureInfo.InvariantCulture);
            TotalCreditAmount = decimal.Parse($"{nachaEndString[43..53]}.{nachaEndString[53..55]}",
                CultureInfo.InvariantCulture);
            Reserved = nachaEndString[55..94].TrimEnd();

            ParsingComplete = true;
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
        public byte? ControlRecordType { get; private set; }
        public int? BatchCount { get; private set; }
        public int? BlockCount { get; private set; }
        public int? EntryAndAddendaCount { get; private set; }
        public long? EntryHash { get; private set; }
        public decimal? TotalDebitAmount { get; private set; }
        public decimal? TotalCreditAmount { get; private set; }
        public string? Reserved { get; private set; }
        public IEnumerable<AchBatch> AchBatches => _achBatches;

        public void AddBatch(AchBatch achBatch)
        {
            _achBatches.Add(achBatch);
        }
    }
}