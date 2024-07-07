using Avalonia.Platform;

namespace EduPath.Utils;

public static class ResourceUtils
{
    public static Stream GetResource(string fileName) => AssetLoader.Open(new Uri($"avares://{nameof(EduPath)}/Assets/{fileName}"));
}