using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConfigLoader
{
    public static T[] GetLevelConfigs<T>()
        where T : Config
    {
        List<T> configs = new List<T>();
        string[] dirs = Directory.GetDirectories($"{Application.dataPath}/Resources/Configs/Levels/");
        foreach (string dir in dirs)
        {
            var d = new DirectoryInfo(dir);
            T config = Resources.Load<T>($"Configs/Levels/{d.Name}/{typeof(T).Name}");
            configs.Add(config);
        }

        if (configs != null)
        {
            return configs.ToArray();
        }

        return null;
    }

    public static T GetConfig<T>()
        where T : Config
    {
        T config = Resources.Load<T>($"Configs/{typeof(T).Name}"); 
        if (config != null)
        {
            return config;
        }
        return null;
    }
}
