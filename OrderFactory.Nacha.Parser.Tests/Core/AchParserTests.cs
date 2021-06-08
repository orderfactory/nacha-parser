using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NSubstitute;
using OrderFactory.Nacha.Parser.Core;
using Xunit;

namespace OrderFactory.Nacha.Parser.Tests.Core
{
    public class AchParserTests
    {
        private readonly IGuidGenerator _guidGenerator = Substitute.For<IGuidGenerator>();

        [Fact]
        public async Task GivenStreamThenParseAchFile()
        {
            var assembly = GetType().Assembly;
            const string resourceName = "OrderFactory.Nacha.Parser.Tests.Resources.sample_ach_returns_file_NC.txt";
            await using var stream = assembly.GetManifestResourceStream(resourceName);

            _guidGenerator.NewGuid().Returns(Guid.NewGuid());
            var parser = new AchParser(_guidGenerator);

            var achFile = await parser.ParseAsync(stream!);

            achFile.Should().NotBeNull();
            achFile.BatchCount.Should().Be(3);
            achFile.AchBatches.Count().Should().Be(3);
            achFile.ImmediateOriginName.Should().Be("FIRST CITIZENS NC");
            achFile.AchBatches.ElementAt(2).AchEntries.First().Name.Should().Be("MINNIE MOUSE");
            achFile.AchBatches.ElementAt(0).AchEntries.ElementAt(1).TraceNumber.Should().Be("053100302316300");
            achFile.AchBatches.ElementAt(1).AchEntries.First().AchReturnAddenda!.OriginalReceivingDfiId.Should()
                .Be("31407426");
            achFile.TotalDebitAmount.Should().Be(1913.45M);
        }
    }
}