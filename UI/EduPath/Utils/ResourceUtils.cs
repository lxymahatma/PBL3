using Avalonia.Platform;

namespace EduPath.Utils;

public static class ResourceUtils
{
    public static Stream GetResource(string loc) => AssetLoader.Open(new Uri(loc));
}