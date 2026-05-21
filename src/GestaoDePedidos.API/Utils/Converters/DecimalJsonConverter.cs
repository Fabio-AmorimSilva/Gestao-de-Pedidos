namespace GestaoDePedidos.API.Utils.Converters;

public sealed class DecimalJsonConverter
    : JsonConverter<decimal>
{
    public override decimal Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        return reader.GetDecimal();
    }

    public override void Write(
        Utf8JsonWriter writer,
        decimal value,
        JsonSerializerOptions options
    )
    {
        var rounded =
            Math.Round(
                value,
                2,
                MidpointRounding.AwayFromZero);

        writer.WriteNumberValue(rounded);
    }
}