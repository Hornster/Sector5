using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(ConstructionSpritesConfig), menuName = "Configs/ConstructionsConfig")]
public class ConstructionSpritesConfig : Config
{
    public List<ConstructionSpritesData> ConstructionSprites;

    [System.Serializable]
    public class ConstructionSpritesData
    {
        public ConstructType Type;
        public Sprite Sprite;
    }
}
