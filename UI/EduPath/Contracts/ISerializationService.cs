namespace EduPath.Contracts;

public interface ISerializationService
{
    public string Serialize<T>(T obj);
    public T? Deserialize<T>(string json);
}