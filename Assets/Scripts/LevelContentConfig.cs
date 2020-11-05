using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(LevelContentConfig), menuName="Configs/LevelConfig")]
public class LevelContentConfig : Config
{
    public GameObject LevelMesh;
    public int LevelID;
    public List<ConstructData> ElementsCount;

    [System.Serializable]
    public class ConstructData
    {
        public ConstructType Type;
        public int Count;

        public ConstructData(ConstructType type, int count)
        {
            Type = type;
            Count = count;
        }
    }

    public void SetElementsCount(List<Tile> tiles)
    {
        List<ConstructData> constructs = new List<ConstructData>();
        foreach(var type in (ConstructType[])Enum.GetValues(typeof(ConstructType)))
        {
            constructs.Add(new ConstructData(type, tiles.Where(x=>x.Type == type).Count()));
        }
        ElementsCount = constructs;
    }
}
