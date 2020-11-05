using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(PrefabConfig), menuName = "Configs/PrefabConfigs")]
public class PrefabConfig : Config
{
    public Tile TilePrefab;
    public Map MapPrefab;
    public Floor FloorPrefab;
}
