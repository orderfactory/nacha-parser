using System;
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
        private readonly IAchService _achService;

        public FunctionParseNacha(IAchService achService)
        {
            _achService = achService;
        }

        [FunctionName("parse-nacha")]
        public async Task Run([BlobTrigger("returns/{name}")] Stream blobStream, string name,
            [Queue("returns-ach-to-process")] ICollector<AchInsertionResults> queueCollector,
            ILogger log)
        {
            try
            {
                var achInsertionResults = await _achService.AchParseAndSave(blobStream, name);
                queueCollector.Add(achInsertionResults);
                log.LogInformation(
                    $"C# Blob trigger function Processed blob\n Name: {name} \n Size: {blobStream.Length} Bytes");
            }
            catch (ArgumentException e)
            {
                log.LogError(e, $"Unable to process NACHA file\n Name: {name} \n Size: {blobStream.Length} Bytes");
            }
        }
    }
}