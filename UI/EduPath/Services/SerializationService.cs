namespace EduPath.Services;

public sealed class SerializationService : ISerializationService
{
    public string Serialize<T>(T obj) => JsonSerializer.Serialize(obj);

    public T? Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json);
}