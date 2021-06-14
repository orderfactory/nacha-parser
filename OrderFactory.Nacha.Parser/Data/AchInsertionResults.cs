using System;

namespace OrderFactory.Nacha.Parser.Data
{
    public class AchInsertionResults
    {
        public AchInsertionResults(Guid achFileId, int achBatchesCount, int achEntriesCount,
            int achReturnAddendaCount)
        {
            AchFileId = achFileId;
            AchBatchesCount = achBatchesCount;
            AchEntriesCount = achEntriesCount;
            AchReturnAddendaCount = achReturnAddendaCount;
        }

        public Guid AchFileId { get; }
        public int AchBatchesCount { get; }
        public int AchEntriesCount { get; }
        public int AchReturnAddendaCount { get; }

        public override string ToString()
        {
            return
                $"{nameof(AchFileId)}: {AchFileId}, {nameof(AchBatchesCount)}: {AchBatchesCount}, {nameof(AchEntriesCount)}: {AchEntriesCount}, {nameof(AchReturnAddendaCount)}: {AchReturnAddendaCount}";
        }
    }
}