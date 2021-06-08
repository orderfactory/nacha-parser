using System;
using FluentAssertions;
using OrderFactory.Nacha.Parser.Models;
using Xunit;

namespace OrderFactory.Nacha.Parser.Tests.Models
{
    public class AchFileTests
    {
        [Fact]
        public void GivenWrongSizeStartStringThenTrow()
        {
            Action creteEntry = () =>
            {
                var _ = new AchFile(default, "foo");
            };

            creteEntry.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenWrongSizeEndStringThenTrow()
        {
            Action creteEntry = () =>
            {
                var achFile = new AchFile(default,
                    "101 053100300 0531003001409052049T094101RESOLVED RETURN DATA   FIRST CITIZENS NC              ");
                achFile.CompleteParsing("bar");
            };

            creteEntry.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenStringsThenParse()
        {
            var fileId = Guid.NewGuid();

            var expected = new AchFile(
                fileId,
                1,
                1,
                "053100300",
                "053100300",
                new DateTime(2014, 09, 05, 20, 49, 00),
                "T",
                94,
                10,
                1,
                "RESOLVED RETURN DATA",
                "FIRST CITIZENS NC",
                "",
                9,
                3,
                2,
                8,
                107389650,
                1913.45M,
                0,
                ""
            );

            const string nachaStartString =
                "101 053100300 0531003001409052049T094101RESOLVED RETURN DATA   FIRST CITIZENS NC              ";
            const string nachaEndString =
                "9000003000002000000080107389650000000191345000000000000                                       ";

            var achFile = new AchFile(fileId, nachaStartString);
            achFile.CompleteParsing(nachaEndString);

            achFile.Should().BeEquivalentTo(expected);
        }
    }
}