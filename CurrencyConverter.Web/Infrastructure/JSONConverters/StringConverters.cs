using System.Text.Json;
using System.Text.Json.Serialization;

namespace CurrencyConverter.Web.Infrastructure.JSONConverters;

/* 
    Not needed in my case but worth knowing about -- from my tutorial. For cases
    when Json returns a number but we needed a string type for example

    Usage, [JsonConverter(typeof(StringConverter))] <-- any time we try to deserialize a string,
    it will use this converter to convert it to a string even if it's a number in the JSON

*/
public class StringConverter : JsonConverter<string?>
{
    public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return (reader.TokenType == JsonTokenType.Number) ? reader.GetInt32().ToString() : reader.GetString();
    }

    public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value);
    }
}