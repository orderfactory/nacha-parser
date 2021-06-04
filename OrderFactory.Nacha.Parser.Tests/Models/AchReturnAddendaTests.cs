using System;
using FluentAssertions;
using OrderFactory.Nacha.Parser.Models;
using Xunit;

namespace OrderFactory.Nacha.Parser.Tests.Models
{
    public class AchReturnAddendaTests
    {
        [Fact]
        public void GivenWrongSizeStringThenTrow()
        {
            Action creteAddenda = () =>
            {
                var _ = new AchReturnAddenda(default, "foo", default);
            };

            creteAddenda.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenStringThenParse()
        {
            var entryId = Guid.NewGuid();
            var batchId = Guid.NewGuid();
            var expected = new AchReturnAddenda(
                entryId,
                7,
                98,
                "C01",
                "053100300000645",
                "25327836",
                "158659591416",
                "053100302670271",
                batchId
            );
            const string nachaString =
                "798C01053100300000645      25327836158659591416                                053100302670271";

            var entry = new AchReturnAddenda(entryId, nachaString, batchId);

            entry.Should().BeEquivalentTo(expected);
        }
    }
}