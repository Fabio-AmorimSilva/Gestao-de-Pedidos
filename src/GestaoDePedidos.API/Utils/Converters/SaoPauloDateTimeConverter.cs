namespace GestaoDePedidos.API.Utils.Converters;

public class SaoPauloDateTimeConverter : JsonConverter<DateTime>
{
    private static readonly TimeZoneInfo TimeZone =
        TimeZoneInfo.FindSystemTimeZoneById(
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? "E. South America Standard Time"
                : "America/Sao_Paulo"
        );

    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return reader.GetDateTime();
    }

    public override void Write(
        Utf8JsonWriter writer,
        DateTime value,
        JsonSerializerOptions options
    )
    {
        var utcDate = value.Kind == DateTimeKind.Utc
                ? value
                : DateTime.SpecifyKind(
                    value,
                    DateTimeKind.Utc
                );

        var saoPauloDate =
            TimeZoneInfo.ConvertTimeFromUtc(
                utcDate,
                TimeZone
            );

        writer.WriteStringValue(saoPauloDate.ToString("yyyy-MM-ddTHH:mm:ss"));
    }
}