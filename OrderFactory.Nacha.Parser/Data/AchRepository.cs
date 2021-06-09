using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Dapper.Contrib.Extensions;
using OrderFactory.Nacha.Parser.Models;

namespace OrderFactory.Nacha.Parser.Data
{
    public interface IAchRepository
    {
        public Task<AchInsertionResults> InsertAchFile(AchFile achFile);
    }

    public class AchRepository : IAchRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public AchRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<AchInsertionResults> InsertAchFile(AchFile achFile)
        {
            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            using var connection = Connection();

            await connection.InsertAsync(achFile);
            var achBatchesInserted = await InsertAchBatches(achFile, connection);
            var achEntriesInserted = await InsertAchEntries(achFile, connection);
            var achReturnAddendaInserted = await InsertAchReturnAddenda(achFile, connection);

            var achInsertionResults = new AchInsertionResults(
                achFile.Id,
                achBatchesInserted,
                achEntriesInserted,
                achReturnAddendaInserted
            );

            transaction.Complete();
            return achInsertionResults;
        }

        private static Task<int> InsertAchBatches(AchFile achFile, IDbConnection connection)
        {
            return connection.InsertAsync(achFile.AchBatches);
        }

        private static Task<int> InsertAchEntries(AchFile achFile, IDbConnection connection)
        {
            var allEntries = achFile.AchBatches.SelectMany(a => a.AchEntries);
            return connection.InsertAsync(allEntries);
        }

        private static Task<int> InsertAchReturnAddenda(AchFile achFile, IDbConnection connection)
        {
            var allAddenda = achFile.AchBatches
                .SelectMany(a => a.AchEntries)
                .Where(a => a.AchReturnAddenda != null)
                .Select(a => a.AchReturnAddenda);

            return connection.InsertAsync(allAddenda);
        }

        private IDbConnection Connection()
        {
            return _sqlConnectionFactory.CreateConnection();
        }
    }
}