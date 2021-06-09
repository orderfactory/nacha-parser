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
        public Task<int> InsertAchFile(AchFile achFile);
    }

    public class AchRepository : IAchRepository
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public AchRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<int> InsertAchFile(AchFile achFile)
        {
            using var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            using var connection = Connection();
            var count = await connection.InsertAsync(achFile);
            await InsertAchBatches(achFile, connection);
            await InsertAchEntries(achFile, connection);
            await InsertAchReturnAddenda(achFile, connection);
            transaction.Complete();
            return count;
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