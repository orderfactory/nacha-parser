using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using OrderFactory.Nacha.Parser.Data;

namespace OrderFactory.Nacha.Parser.Core
{
    public interface IAchService
    {
        Task<AchInsertionResults> AchParseAndSave(Stream stream, string? name);
    }

    public class AchService : IAchService
    {
        private readonly IAchParser _achParser;
        private readonly IAchRepository _achRepository;
        private readonly ILogger<AchService> _logger;

        public AchService(IAchParser achParser, IAchRepository achRepository, ILogger<AchService> logger)
        {
            _achParser = achParser;
            _achRepository = achRepository;
            _logger = logger;
        }

        public async Task<AchInsertionResults> AchParseAndSave(Stream stream, string? name)
        {
            var achFile = await _achParser.ParseAsync(stream, name);
            var achInsertionResults = await _achRepository.InsertAchFile(achFile);
            _logger.LogInformation("Ach inserted to the database. ({achInsertionResults})", achInsertionResults);
            return achInsertionResults;
        }
    }
}