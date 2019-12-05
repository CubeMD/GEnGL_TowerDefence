using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

using Random = UnityEngine.Random;


public class GridManager : MonoBehaviour
{
    public Texture2D mapTexture;
    public float tileSize;
    
    public List<GameObject> prefabTiles;
    public List<Color> mapColors;
        
    public GameObject[,] tiles;
    
    public static GridManager instance;

    private void Awake()
    {
        instance = this;        
    }

    public void PlaceTiles()
    {
        Vector3 offset = new Vector3(mapTexture.width * tileSize / 2, 0, mapTexture.height * tileSize / 2);
        tiles = new GameObject[mapTexture.width, mapTexture.height];
        
        for (int y = 0; y < mapTexture.height; y++)
        { 
            for (int x = 0; x < mapTexture.width; x++)
            {
                GameObject tilePrefab = PrefabFromPixel(new Vector2Int(x, y));
                Vector3 tilePos = new Vector3(x, 0, y) - offset;
                tiles[x, y] = Instantiate(tilePrefab, tilePos, Quaternion.identity, transform);
                tiles[x, y].GetComponent<Tile>().pos = new Vector2Int(x, y);
                tiles[x, y].name = tilePrefab.name + ":" + x + "|" + y;
            }                
        }
    }

    private GameObject PrefabFromPixel(Vector2Int pos)
    {
        Color pixelColor = mapTexture.GetPixel(pos.x, pos.y);
        int index = mapColors.FindIndex(x => x.Equals(pixelColor));
        return prefabTiles[index];
    }
    
    public void ClearTiles()
    {
        for (int i = this.transform.childCount; i > 0; --i)
            DestroyImmediate(transform.GetChild(0).gameObject);
    }
}
