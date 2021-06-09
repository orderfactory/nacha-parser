using System;

namespace OrderFactory.Nacha.Parser.Data
{
    public class AchInsertionResults
    {
        public AchInsertionResults(Guid achFileId, int achBatchesInserted, int achEntriesInserted,
            int achReturnAddendaInserted)
        {
            AchFileId = achFileId;
            AchBatchesInserted = achBatchesInserted;
            AchEntriesInserted = achEntriesInserted;
            AchReturnAddendaInserted = achReturnAddendaInserted;
        }

        public Guid AchFileId { get; }
        public int AchBatchesInserted { get; }
        public int AchEntriesInserted { get; }
        public int AchReturnAddendaInserted { get; }

        public override string ToString()
        {
            return
                $"{nameof(AchFileId)}: {AchFileId}, {nameof(AchBatchesInserted)}: {AchBatchesInserted}, {nameof(AchEntriesInserted)}: {AchEntriesInserted}, {nameof(AchReturnAddendaInserted)}: {AchReturnAddendaInserted}";
        }
    }
}