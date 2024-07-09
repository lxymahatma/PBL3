using System.Text;

namespace EduPath.Services;

public sealed class SerializationService : ISerializationService
{
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };
    public string Serialize<T>(T obj) => JsonSerializer.Serialize(obj, _options);

    public T? Deserialize<T>(string text) => JsonSerializer.Deserialize<T>(text);

    public async Task<string> SerializeAsync<T>(T obj)
    {
        await using var stream = new MemoryStream();
        await JsonSerializer.SerializeAsync(stream, obj, _options);
        stream.Position = 0;
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }

    public async Task<T?> DeserializeAsync<T>(string text)
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }

    public async Task<T?> DeserializeAsync<T>(Stream stream) => await JsonSerializer.DeserializeAsync<T>(stream);
}