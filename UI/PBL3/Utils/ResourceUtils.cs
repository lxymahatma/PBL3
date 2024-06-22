using Avalonia.Platform;

namespace PBL3.Utils;

public static class ResourceUtils
{
    public static Stream GetResource(string loc) => AssetLoader.Open(new Uri(loc));
}