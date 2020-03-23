# Fermin.Text.Json.Converters
Set of System.Text.Json Converts that are not included by default.

## Converters


### Dynamic 
Support for converting Json to Mixed Dtos and directly to dynamics using ExpandoObjects is lacking in System.Text.Json. The Fermin.Text.Json.Converters.DynamicConverter fills that gap.

e.g.

Mixed Dto

``` csharp
public class MixedDto
{
    public string foo {get; set;}
    public dynamic bar {get; set;}
}

// add converter to serializer
var options = new JsonSerializerOptions();
options.Converters.Add(new DynamicConverter());

// convert to dto
MixedDto dto = JsonSerializer.Deserialize<MixedDto>(json, options);

```

Directly to dynamic

``` csharp

// add converter to serializer
var options = new JsonSerializerOptions();
options.Converters.Add(new DynamicConverter());

dynamic dto = JsonSerializer.Deserialize<dynamic>(json, options);

```