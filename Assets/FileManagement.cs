using System.IO;
using UnityEngine;

public static class FileManager
{
    public static bool Exists(string relativePath)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, relativePath);

        if (Directory.Exists(fullPath))
        {
            string[] files = Directory.GetFiles(fullPath);
            return files.Length > 0;
        }

        if (File.Exists(fullPath))
        {
            return true;
        }

        return false;
    }
}


