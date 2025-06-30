namespace ConsoleApp.Persistencia;

using ConsoleApp.Modelos;
using System.Text.Json;
using System.Text.Json.Serialization;


public class ItemJsonConverter : JsonConverter<Item>
{
    public override Item Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var root = doc.RootElement;

        var tipo = root.GetProperty("TipoInterno").GetString();

        return tipo switch
        {
            "Arma" => JsonSerializer.Deserialize<Arma>(root.GetRawText(), options),
            "Pocao" => JsonSerializer.Deserialize<Pocao>(root.GetRawText(), options),
            "Granada" => JsonSerializer.Deserialize<Granada>(root.GetRawText(), options),
            "Municao" => JsonSerializer.Deserialize<Municao>(root.GetRawText(), options),
            _ => throw new JsonException("Tipo de item desconhecido")
        };
    }

    public override void Write(Utf8JsonWriter writer, Item value, JsonSerializerOptions options)
    {
        var tipo = value switch
        {
            Arma => "Arma",
            Pocao => "Pocao",
            Granada => "Granada",
            Municao => "Municao",
            _ => throw new NotSupportedException()
        };

        using var doc = JsonDocument.Parse(JsonSerializer.Serialize(value, value.GetType(), options));
        writer.WriteStartObject();
        writer.WriteString("TipoInterno", tipo);
        foreach (var prop in doc.RootElement.EnumerateObject())
        {
            prop.WriteTo(writer);
        }
        writer.WriteEndObject();
    }
}
