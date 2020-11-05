using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour
{
    private void Awake()
    {
        var levelConfigs = ConfigLoader.GetLevelConfigs<LevelContentConfig>();
        var spritesConfig = ConfigLoader.GetConfig<ConstructionSpritesConfig>();
        var prefabConfig = ConfigLoader.GetConfig<PrefabConfig>();
        var wallsConfigs = ConfigLoader.GetConfig<WallsConfig>();
        wallsConfigs.Initialize();

        var task = SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        task.completed += InitializeMap(levelConfigs, spritesConfig, prefabConfig);
    }

    private Action<AsyncOperation> InitializeMap(LevelContentConfig[] levelConfigs, ConstructionSpritesConfig spritesConfig, PrefabConfig prefabConfig)
    {
        return _ =>
        {
            MapSpawner.Instance.SetConfigs(levelConfigs, spritesConfig, prefabConfig);
        };
    }
}