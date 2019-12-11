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
        ClearTiles();

        float tileSize = prefabTiles[0].GetComponent<Renderer>().bounds.size.x;
        Vector3 offset = new Vector3(mapTexture.width * tileSize / 2, 0, mapTexture.height * tileSize / 2);
        tiles = new GameObject[mapTexture.width, mapTexture.height];
        
        for (int y = 0; y < mapTexture.height; y++)
        { 
            for (int x = 0; x < mapTexture.width; x++)
            {
                GameObject tilePrefab = PrefabFromPixel(new Vector2Int(x, y));

                if (tilePrefab)
                {
                    Vector3 tilePos = new Vector3(x * tileSize, 0, y * tileSize) - offset;
                    tiles[x, y] = Instantiate(tilePrefab, tilePos, Quaternion.identity, transform);
                    tiles[x, y].GetComponent<Tile>().pos = new Vector2Int(x, y);
                }
            }                
        }
    }

    private GameObject PrefabFromPixel(Vector2Int pos)
    {
        int index = mapColors.FindIndex(x => x.Equals(mapTexture.GetPixel(pos.x, pos.y)));
        
        if (index == -1)
        {
            return null;
        }
        
        return prefabTiles[index];
    }
    
    public void ClearTiles()
    {
        for (int i = this.transform.childCount; i > 0; --i)
            DestroyImmediate(transform.GetChild(0).gameObject);
    }
}
