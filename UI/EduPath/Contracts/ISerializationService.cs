namespace EduPath.Contracts;

public interface ISerializationService
{
    public string Serialize<T>(T obj);
    public T? Deserialize<T>(string json);
    Task<string> SerializeAsync<T>(T obj);
    Task<T?> DeserializeAsync<T>(string json);
}