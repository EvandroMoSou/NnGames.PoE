using System.Reflection;

namespace NnGames.PoE.Test.Utils;

public static class EmbeddedResourceUtil
{
    public static string ReadResource(string resourceName, Assembly assembly)
    {
        using (Stream stream = assembly.GetManifestResourceStream(resourceName)!)
        using (StreamReader reader = new StreamReader(stream))
            return reader.ReadToEnd();
    }

    public static bool CheckResource(string resourceName, Assembly assembly)
    {
        var names = assembly.GetManifestResourceNames();
        return names.Contains(resourceName);
    }
}
