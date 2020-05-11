# Fermin.Text.Json.Converters
Set of System.Text.Json Converts that are not included by default.

## Install

[Nuget](https://www.nuget.org/packages/Fermin.Text.Json.Converters/)

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

// add converter to serializer using extension method
var options = new JsonSerializerOptions().AddDynamicConverter();

// convert to dto
MixedDto dto = JsonSerializer.Deserialize<MixedDto>(json, options);

```

Directly to dynamic

``` csharp

// add converter to serializer using extension method
var options = new JsonSerializerOptions().AddDynamicConverter();

dynamic dto = JsonSerializer.Deserialize<dynamic>(json, options);

```

Annotated Dto

``` csharp
public class AnnotatedMixedDto
{
    public string foo {get; set;}

    [JsonConverter(typeof(DynamicConverter))]
    public dynamic bar {get; set;}
}
```
