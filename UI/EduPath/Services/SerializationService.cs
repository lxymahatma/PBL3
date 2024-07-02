using System.Text;

namespace EduPath.Services;

public sealed class SerializationService : ISerializationService
{
    public string Serialize<T>(T obj) => JsonSerializer.Serialize(obj);

    public T? Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json);

    public async Task<string> SerializeAsync<T>(T obj)
    {
        await using var stream = new MemoryStream();
        await JsonSerializer.SerializeAsync(stream, obj);
        stream.Position = 0;
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }

    public async Task<T?> DeserializeAsync<T>(string json)
    {
        await using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }
}