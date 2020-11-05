using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(WallsConfig), menuName = "Configs/WallsConfigs")]
public class WallsConfig : Config
{
    
    [System.Serializable]
    public class WallData
    {
        public ConstructType Type;
        public Wall Prefab;
        public int Price;
    }

    public List<WallData> Types;

    public void Initialize()
    {
        for(int i = 0; i < Types.Count; ++i)
        {
            Types[i].Prefab.SetType(Types[i].Type);
            Types[i].Prefab.SetPrice(Types[i].Price);
        }
    }
}
