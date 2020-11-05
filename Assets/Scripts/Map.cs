using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Video;


public class Map : MonoBehaviour
{
    public List<Tile> Tiles;
    public Vector3 Min;
    public Vector3 Max;

    public void SetTiles(Dictionary<ConstructType, Sprite> sprites)
    {
        foreach (Tile tile in Tiles)
        {
            tile.SetSprite(sprites[tile.Type]);
        }      
    }

    public void Spawn(Transform mapTransform, GameObject mesh, Tile tileTemplate)
    {
        var transforms = mesh.GetComponentsInChildren<Transform>().ToList();

        var childsB = transforms.Find(x=>x.name.Equals("b")).GetComponentsInChildren<Transform>();
        var childsS = transforms.Find(x => x.name.Equals("s")).GetComponentsInChildren<Transform>();

        for(int i = 0; i < 3; ++i)
        {
            var center = new GameObject();
            center.name = $"Room{i}";
            center.transform.position = transforms.Find(x => x.name.Equals($"c{i}")).transform.position + mapTransform.transform.position;
            var room = center.AddComponent<Room>();
            var textMesh = center.AddComponent<TextMesh>();
            textMesh.gameObject.transform.eulerAngles = new Vector3(90, 0, 0);
            room.SetId(i);
            RoomManager.Instance.Rooms.Add(room);
        }

        for (int i = 1; i < childsB.Length; ++i)
        {
            var type = (ConstructType)int.Parse(childsB[i].name.Substring(0, childsB[i].name.IndexOf(".")));
            Tile tile = SetTile(tileTemplate, childsB[i], type, mapTransform);
            tile.PrepareToBuild();
            Tiles.Add(tile);         
        }

        for(int i = 1; i < childsS.Length; ++i)
        {
            var type = (ConstructType)int.Parse(childsS[i].name.Substring(0, childsS[i].name.IndexOf(".")));
            Tile tile = SetTile(tileTemplate, childsS[i], type, mapTransform);
            tile.Build(i);
            Tiles.Add(tile);
        }

    }

    private Tile SetTile(Tile tileTemplate, Transform child, ConstructType type, Transform mapTransform)
    {
        Tile tile = Instantiate(tileTemplate, mapTransform);
        tile.transform.localPosition = child.position;
        tile.transform.localRotation = child.transform.rotation;
        tile.Type = type;
        return tile;
    }
}
