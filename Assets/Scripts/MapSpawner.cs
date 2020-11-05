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

        map.Spawn(LevelsConfigs[id].LevelFloors, mapPrefab.transform, LevelsConfigs[id].LevelMesh, prefabConfig.TilePrefab, prefabConfig.FloorPrefab);
        map.SetTiles(spritesConfig.ConstructionSprites.ToDictionary(x => x.Type, x => x.Sprite));
        LevelsConfigs[id].SetElementsCount(map.Floors);
        Vector3[] verticesToCheck = plane.mesh.vertices;
        for (int i = 0; i < verticesToCheck.Length; i++)
        {
            var worldPos = plane.transform.TransformPoint(verticesToCheck[i]);
            if (worldPos.x < map.Min.x || worldPos.z < map.Min.z || worldPos.x > map.Max.x || worldPos.z > map.Max.z)
                verticesToCheck[i].y = 0.75f;
        }
        plane.mesh.vertices = verticesToCheck;
    }
}
