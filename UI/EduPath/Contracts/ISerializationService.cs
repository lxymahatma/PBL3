namespace EduPath.Contracts;

public interface ISerializationService
{
    public string Serialize<T>(T obj);
    public T? Deserialize<T>(string text);
    Task<string> SerializeAsync<T>(T obj);
    Task<T?> DeserializeAsync<T>(string text);
    Task<T?> DeserializeAsync<T>(Stream stream);
}