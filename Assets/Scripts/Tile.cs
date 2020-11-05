using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConstructType
{
    NONE,
    NORMAL_CORNER,
    NORMAL_SINGLE,
    NORMAL_HALF_CROSS,
    NORMAL_CROSS,
    NORMAL_HALF_SINGLE,
    NORMAL_OUTSIDE_DOOR,
    NORMAL_INSIDE_DOOR,
    NORMAL_WINDOW,
    FLOOR,
    BASEMENT_CORNER,
    BASEMENT_SINGLE,
    BASEMENT_HALF_CROSS,
    BASEMENT_CROSS,
    BASEMENT_HALF_SINGLE,
    BASEMENT_OUTSIDE_DOOR,
    BASEMENT_INSIDE_DOOR,
    BASEMENT_WINDOW,
    BASEMENT_THIRD_SQUARE,
    ROOF_TILTED_NORMAL,
    ROOF_TILTED_CORNER,
    ROOF_TILTED_WINDOW,
    ROOF_STRAIGHT_NORMAL,
    ROOF_STRAIGHT_CORNER,
    ROOF_STRAIGHT_CHIMNEY
}


public class Tile : MonoBehaviour
{
    public ConstructType Type;
    public SpriteRenderer spriteRenderer;
    private WallsConfig walls;

    [ContextMenu("XD")]
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        walls = ConfigLoader.GetConfig<WallsConfig>();
    }

    public void SetSprite(Sprite sprite) => spriteRenderer.sprite = sprite;

    public void PrepareToBuild()
    {
        
    }

    public void Build(int id)
    {
        var prefab = walls.Types.Find(x => x.Type == Type);
        var wall = Instantiate(prefab.Prefab, transform);
        var textMeshObject = new GameObject();
        spriteRenderer.enabled = false;

        if (Type == ConstructType.NORMAL_WINDOW)
        {
            var lok = wall.gameObject.AddComponent<Airlock>();
            var textMesh = textMeshObject.AddComponent<TextMesh>();
            textMeshObject.transform.parent = wall.gameObject.transform;
            textMeshObject.transform.eulerAngles = new Vector3(90, 0, 0);
            textMeshObject.transform.localPosition = new Vector3(0, 0, 0);
            lok.Set(id, gameObject, false);
            ObjectsManager.Instance.AddObject(lok);
        }
    }
}
