using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using OrderFactory.Nacha.Parser.Core;
using OrderFactory.Nacha.Parser.Data;

namespace OrderFactory.Nacha.Functions
{
    public class FunctionParseNacha
    {
        private readonly IAchParser _achParser;
        private readonly IAchRepository _achRepository;

        public FunctionParseNacha(IAchParser achParser, IAchRepository achRepository)
        {
            _achParser = achParser;
            _achRepository = achRepository;
        }

        [FunctionName("parse-nacha")]
        public async Task Run([BlobTrigger("returns/{name}")]
            Stream myBlob, string name, ILogger log)
        {
            var achFile = await _achParser.ParseAsync(myBlob);
            await _achRepository.InsertAchFile(achFile);
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}