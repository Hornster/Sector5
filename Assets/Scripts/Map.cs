using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;

[System.Serializable]
public class FloorData
{
    public List<Tile> Tiles;
    public FloorData() => Tiles = new List<Tile>();
}

public class Map : MonoBehaviour
{
    public List<FloorData> Floors;
    public Vector3 Min;
    public Vector3 Max;

    private void Awake()
    {
        Floors = new List<FloorData>();
    }

    public void SetTiles(Dictionary<ConstructType, Sprite> sprites)
    {
        foreach (FloorData floor in Floors)
        {
            foreach (Tile tile in floor.Tiles)
            {
                tile.SetSprite(sprites[tile.Type]);
            }
        }
    }

    public void Spawn(int levelFloors, Transform mapTransform, GameObject mapMesh, Tile tileTemplate, Floor floorTemplate)
    {
        List<Transform> meshFloors = new List<Transform>();
        List<Transform> floorsTransforms = new List<Transform>();
        for(int i = 0; i < levelFloors; ++i)
        {
            Transform floorTransform = SpawnFloor(mapTransform, floorTemplate, i);
            floorsTransforms.Add(floorTransform);
            meshFloors.Add(mapMesh.transform.GetChild(i));
        }

        for (int i = 0; i < meshFloors.Count; ++i)
        {
            FloorData floor = new FloorData();
            var transforms = meshFloors[i].GetComponentsInChildren<Transform>();

            for (int j = 1; j < transforms.Length; ++j)
            {
                var type = (ConstructType)int.Parse(transforms[j].name.Substring(0, transforms[j].name.IndexOf(".")));
                Tile tile = SpawnTile(tileTemplate, floorsTransforms, i, transforms, j, type);
                floor.Tiles.Add(tile);
            }
            Floors.Add(floor);
        }

        for (int i = 0; i < Floors.Count; ++i)
        {
            Floors[i].Tiles = Floors[i].Tiles.OrderBy(x => Vector3.Distance(x.transform.position, Vector3.zero)).ToList();
        }

        Max = new Vector3(
            Math.Max(Floors[0].Tiles.Last().transform.position.x, Floors[0].Tiles.First().transform.position.x),
            0,
            Math.Max(Floors[0].Tiles.Last().transform.position.z, Floors[0].Tiles.First().transform.position.z)) + new Vector3(1, 0, 1);
        Min = new Vector3(
            Math.Min(Floors[0].Tiles.Last().transform.position.x, Floors[0].Tiles.First().transform.position.x),
            0,
            Math.Min(Floors[0].Tiles.Last().transform.position.z, Floors[0].Tiles.First().transform.position.z)) - new Vector3(1, 0 ,1);
    }

    private Tile SpawnTile(Tile tileTemplate, List<Transform> floorsTransforms, int i, Transform[] transforms, int j, ConstructType type)
    {
        Tile tile = Instantiate(tileTemplate, floorsTransforms[i].transform);
        tile.transform.localPosition = transforms[j].transform.position;
        tile.transform.rotation = transforms[j].transform.rotation;
        tile.Type = type;
        return tile;
    }

    private Transform SpawnFloor(Transform mapTransform, Floor floorTemplate, int i)
    {
        Transform floorTransform = Instantiate(floorTemplate.transform, mapTransform);
        floorTransform.localPosition = new Vector3(0, i * 2, 0);
        floorTransform.name = $"Floor{i}";
        return floorTransform;
    }
}
