using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

using Random = UnityEngine.Random;


public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public List<GameObject> prefabTiles;
    public float tileSize;
    
    public Texture2D mapTexture;
    public List<Color> mapColors;
        
    public GameObject[,] tiles;
    

    private void Awake()
    {
        instance = this;        
    }

    private void Start()
    {
        PlaceTiles();
    }

    private void PlaceTiles()
    {
        tiles = new GameObject[mapTexture.width, mapTexture.height];
        
        for (int y = 0; y < mapTexture.height; y++)
        { 
            for (int x = 0; x < mapTexture.width; x++)
            {
                GameObject tilePrefab = PrefabFromPixel(new Vector2Int(x, y));
                Vector3 tilePos = new Vector3(tileSize * (mapTexture.width - x), 0, tileSize * (mapTexture.height - y));
                tiles[x, y] = Instantiate(tilePrefab, tilePos, Quaternion.identity);
                tiles[x, y].GetComponent<Tile>().pos = new Vector2Int(x, y);
            }                
        }
    }

    private GameObject PrefabFromPixel(Vector2Int pos)
    {
        int index = mapColors.FindIndex((x => x.Equals(mapTexture.GetPixel(pos.x, mapTexture.height - pos.y))));

        return prefabTiles[index];
    }
}
