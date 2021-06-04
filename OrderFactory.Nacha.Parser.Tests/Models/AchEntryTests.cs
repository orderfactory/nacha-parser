using System;
using FluentAssertions;
using OrderFactory.Nacha.Parser.Models;
using Xunit;

namespace OrderFactory.Nacha.Parser.Tests.Models
{
    public class AchEntryTests
    {
        [Fact]
        public void GivenWrongSizeStringThenTrow()
        {
            Action creteEntry = () =>
            {
                var _ = new AchEntry(default, "foo", default);
            };

            creteEntry.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenStringThenParse()
        {
            var entryId = Guid.NewGuid();
            var batchId = Guid.NewGuid();
            var expected = new AchEntry(
                entryId,
                6,
                26,
                "25327194",
                1,
                "2345678912",
                655.70M,
                "0000018499",
                null,
                "SUMMER HOUSES",
                "S",
                1,
                "053100302316298",
                null,
                null,
                null,
                batchId
            );
            const string nachaString =
                "6262532719412345678912       00000655700000018499     SUMMER HOUSES         S 1053100302316298";

            var entry = new AchEntry(entryId, nachaString, batchId);

            entry.Should().BeEquivalentTo(expected);
        }
    }
}