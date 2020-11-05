using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapSpawner : Singleton<MapSpawner>
{
    public Dictionary<int, LevelContentConfig> LevelsConfigs;
    private ConstructionSpritesConfig spritesConfig;
    private PrefabConfig prefabConfig;
    [SerializeField] private MeshFilter plane;

    private void Start()
    {
        SpawnMap(0);
    }

    public void SetConfigs(LevelContentConfig[] configs, ConstructionSpritesConfig spritesConfig, PrefabConfig prefabConfig)
    {
        this.LevelsConfigs = configs.ToDictionary(x => x.LevelID, x => x);
        this.spritesConfig = spritesConfig;
        this.prefabConfig = prefabConfig;
    }

    public void SpawnMap(int id)
    {
        var mapPrefab = Instantiate(prefabConfig.MapPrefab, new Vector3(0, 0.05f, 0), Quaternion.identity);
        var map = mapPrefab.GetComponent<Map>();

        map.Spawn(mapPrefab.transform, LevelsConfigs[id].LevelMesh, prefabConfig.TilePrefab);
        map.SetTiles(spritesConfig.ConstructionSprites.ToDictionary(x => x.Type, x => x.Sprite));
    }
}
