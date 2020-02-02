using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Savant.Api.Services;
using Xunit;

namespace Savant.Api.UnitTests
{
    public class StringTypeParserTests
    {
        [Theory]
        [InlineData("0.0m", DataType.Decimal)]
        [InlineData("0.0d", DataType.Double)]
        [InlineData("0.0f", DataType.Float)]
        [InlineData("1", DataType.Int)]
        [InlineData("true", DataType.Bool)]
        [InlineData("false", DataType.Bool)]
        [InlineData("True", DataType.Bool)]
        [InlineData("False", DataType.Bool)]
        [InlineData("TODO", DataType.DateTimeOffset)]
        [InlineData("TODO", DataType.DateTimeUtc)]
        [InlineData("TODO", DataType.DateTime)]
        [InlineData("TODO", DataType.Time)]
        [InlineData("Hello world!", DataType.String)]
        public void FromString_ReturnsExpectedDataType(string value, DataType expectedDataType)
        {
            var parser = new StringTypeParser();
            var result = parser.FromString(value);

            result.type.Should().Be(expectedDataType);
        }
    }
}
