using System;
using FluentAssertions;
using OrderFactory.Nacha.Parser.Models;
using Xunit;

namespace OrderFactory.Nacha.Parser.Tests.Models
{
    public class AchBatchTests
    {
        [Fact]
        public void GivenWrongSizeStartStringThenTrow()
        {
            Action creteEntry = () =>
            {
                var _ = new AchBatch(default, "foo",
                    "820000000400506543880000001271160000000000001591585639                         053100300000001",
                    default);
            };

            creteEntry.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenWrongSizeEndStringThenTrow()
        {
            Action creteEntry = () =>
            {
                var _ = new AchBatch(default,
                    "5200ABCCOMP         000000000000000000  1123456789WEBLOAN PYMT 0829141408290001053100300000001",
                    "bar", default);
            };

            creteEntry.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenStringsThenParse()
        {
            var fileId = Guid.NewGuid();
            var batchId = Guid.NewGuid();

            var expected = new AchBatch(
                batchId,
                5,
                200,
                "ABCCOMP",
                "000000000000000000",
                "1123456789",
                "WEB",
                "LOAN PYMT",
                "082914",
                new DateTime(2014, 08, 29),
                0,
                "1",
                "05310030",
                1,
                8,
                200,
                4,
                50654388,
                1271.16M,
                0M,
                "1591585639",
                "",
                "",
                "05310030",
                1,
                fileId
            );

            const string nachaStartString =
                "5200ABCCOMP         000000000000000000  1123456789WEBLOAN PYMT 0829141408290001053100300000001";
            const string nachaEndString =
                "820000000400506543880000001271160000000000001591585639                         053100300000001";

            var batch = new AchBatch(batchId, nachaStartString, nachaEndString, fileId);

            batch.Should().BeEquivalentTo(expected);
        }
    }
}