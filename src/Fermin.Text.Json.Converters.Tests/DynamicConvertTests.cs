using System;
using System.Dynamic;
using System.Text.Json;
using Xunit;

namespace Fermin.Text.Json.Converters.Tests
{
    public class DynamicConvertTests
    {
        [Fact]
        public void SerializeToandFromMixedDto()
        {
            var options = new JsonSerializerOptions().AddDynamicConverter();

            MixedDto dto = JsonSerializer.Deserialize<MixedDto>(mixedJson, options);

            Assert.Equal("test", dto.foo);
            Assert.Equal(1, dto.bar.baz.qux);
            Assert.Equal("quuz", dto.bar.quux);

            string dtoString = JsonSerializer.Serialize<MixedDto>(dto, options);

            Assert.Equal(mixedJson, dtoString);
        }

        private const string mixedJson = "{\"foo\":\"test\",\"bar\":{\"baz\":{\"qux\":1},\"quux\":\"quuz\"}}";

        public class MixedDto
        {
            public string foo {get; set;}
            public dynamic bar {get; set;}
        }

        [Fact]
        public void SerializeToAndFromDynamic()
        {
            var options = new JsonSerializerOptions().AddDynamicConverter();

            dynamic dto = JsonSerializer.Deserialize<dynamic>(mixedJson, options);

            Assert.Equal("test", dto.foo);
            Assert.Equal(1, dto.bar.baz.qux);
            Assert.Equal("quuz", dto.bar.quux);

            string dtoString = JsonSerializer.Serialize<dynamic>(dto, options);

            Assert.Equal(mixedJson, dtoString);
        }
    }
}
