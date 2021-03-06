using OrderFactory.Nacha.Parser.Models;

namespace OrderFactory.Nacha.Parser.Core
{
    internal class Parsing
    {
        public Parsing(string? name)
        {
            Name = name;
        }

        public string? Name { get; }
        public bool Complete => CurrentAchFile is {ParsingComplete: true};
        public AchFile? CurrentAchFile { get; set; }
        public AchBatch? CurrentAchBatch { get; set; }
        public AchEntry? CurrentAchEntry { get; set; }
    }
}