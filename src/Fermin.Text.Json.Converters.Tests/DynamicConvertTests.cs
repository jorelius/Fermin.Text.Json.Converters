using System;
using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Fermin.Text.Json.Converters;
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

        //private const string mixedJson = "{\"foo\":\"test\",\"bar\":{\"baz\":{\"qux\":1},\"quux\":\"quuz\"}}";
        private const string mixedJson = "{\"num\":0.2345,\"foo\":\"test\",\"bar\":{\"baz\":{\"qux\":1},\"quux\":\"quuz\",\"corge\":[\"blah\"],\"grault\":[]}}";
        

        public class MixedDto
        {
            public double num {get; set;}
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
            Assert.Equal(0.2345, dto.num);
            Assert.Equal("quuz", dto.bar.quux);

            string dtoString = JsonSerializer.Serialize<dynamic>(dto, options);

            Assert.Equal(mixedJson, dtoString);
        }

        public class AnnotatedMixedDto
        {
            public double num {get; set;}
            public string foo {get; set;}

            [JsonConverter(typeof(DynamicConverter))]
            public dynamic bar {get; set;}
        }

        [Fact]
        public void SerializeAnnotatedDto()
        {
            var options = new JsonSerializerOptions();

            AnnotatedMixedDto dto = JsonSerializer.Deserialize<AnnotatedMixedDto>(mixedJson, options);

            Assert.Equal("test", dto.foo);
            Assert.Equal(1, dto.bar.baz.qux);
            Assert.Equal("quuz", dto.bar.quux);

            string dtoString = JsonSerializer.Serialize<AnnotatedMixedDto>(dto, options);

            Assert.Equal(mixedJson, dtoString);
        }

    }
}
