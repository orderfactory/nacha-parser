using System;
using System.IO;
using System.Threading.Tasks;
using OrderFactory.Nacha.Parser.Models;

namespace OrderFactory.Nacha.Parser.Core
{
    public interface IAchParser
    {
        Task<AchFile> ParseAsync(Stream stream, string? name);
    }

    public class AchParser : IAchParser
    {
        private readonly IGuidGenerator _guidGenerator;

        public AchParser(IGuidGenerator guidGenerator)
        {
            _guidGenerator = guidGenerator;
        }

        public async Task<AchFile> ParseAsync(Stream stream, string? name)
        {
            using StreamReader reader = new StreamReader(stream);
            var parsing = new Parsing(name);

            string nachaString;
            while (!parsing.Complete && (nachaString = await reader.ReadLineAsync()) != null)
                ProcessNachaString(nachaString.PadRight(94,' '), parsing);

            if (parsing.CurrentAchFile is {ParsingComplete: true}) return parsing.CurrentAchFile;

            throw new ArgumentException($"Unable to complete parsing of ACH file '{name}' from stream.", nameof(stream));
        }

        private void ProcessNachaString(string nachaString, Parsing parsing)
        {
            switch (nachaString[..1])
            {
                case "1":
                    ProcessFileHeader(nachaString, parsing);
                    break;
                case "5":
                    ProcessBatchHeader(nachaString, parsing);
                    break;
                case "6":
                    ProcessEntry(nachaString, parsing);
                    break;
                case "7":
                    ProcessReturnAddenda(nachaString, parsing);
                    break;
                case "8":
                    ProcessBatchFooter(nachaString, parsing);
                    break;
                case "9":
                    ProcessFileFooter(nachaString, parsing);
                    break;
                default:
                    throw new ArgumentException("Unknown type of NACHA string.",
                        nameof(nachaString));
            }
        }

        private void ProcessFileHeader(string nachaString, Parsing parsing)
        {
            parsing.CurrentAchFile = new AchFile(_guidGenerator.NewGuid(), nachaString, parsing.Name);
        }

        private static void ProcessFileFooter(string nachaString, Parsing parsing)
        {
            if (parsing.CurrentAchFile == null || parsing.CurrentAchFile.ParsingComplete)
                throw new ArgumentException("Cannot close file without open file header.",
                    nameof(nachaString));
            parsing.CurrentAchFile.CompleteParsing(nachaString);
        }

        private static void ProcessBatchFooter(string nachaString, Parsing parsing)
        {
            if (parsing.CurrentAchBatch == null || parsing.CurrentAchBatch.ParsingComplete)
                throw new ArgumentException("Cannot close batch without open batch.",
                    nameof(nachaString));
            parsing.CurrentAchBatch.CompleteParsing(nachaString);
        }

        private void ProcessReturnAddenda(string nachaString, Parsing parsing)
        {
            if (parsing.CurrentAchEntry == null)
                throw new ArgumentException("Cannot process addenda without entry.",
                    nameof(nachaString));
            parsing.CurrentAchEntry.SetReturnAddenda(new AchReturnAddenda(_guidGenerator.NewGuid(),
                nachaString, parsing.CurrentAchEntry.Id));
        }

        private void ProcessEntry(string nachaString, Parsing parsing)
        {
            if (parsing.CurrentAchBatch == null || parsing.CurrentAchBatch.ParsingComplete)
                throw new ArgumentException("Cannot process entry without open batch.",
                    nameof(nachaString));
            var achEntry = new AchEntry(_guidGenerator.NewGuid(), nachaString,
                parsing.CurrentAchBatch.Id);
            parsing.CurrentAchEntry = achEntry;
            parsing.CurrentAchBatch.AddEntry(achEntry);
        }

        private void ProcessBatchHeader(string nachaString, Parsing parsing)
        {
            if (parsing.CurrentAchFile == null || parsing.CurrentAchFile.ParsingComplete)
                throw new ArgumentException("Cannot process batch header without open file header.",
                    nameof(nachaString));
            parsing.CurrentAchBatch =
                new AchBatch(_guidGenerator.NewGuid(), nachaString, parsing.CurrentAchFile.Id);
            parsing.CurrentAchFile.AddBatch(parsing.CurrentAchBatch);
        }
    }
}