using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ETileType
{
    NONE,
    LOW,
    MID,
    HIGH
}

public class TileManager : MonoBehaviour
{
    [SerializeField] int xCount = 32;
    [SerializeField] int yCount = 32;
    [SerializeField] int MaxResorceCount = 10;
    [SerializeField] GameObject TilePrefab;
    List<GameObject> AllTiles = new List<GameObject>();

    void Start()
    {
        SpawnTiles();
        InitTiles();
    }

    void InitTiles()
    {
        // Place max resorces on random places of the grip
        // Change the lowest reource sround tiles
        while (MaxResorceCount > 0)
        {
            int x = Random.Range(0, xCount+1);
            int y = Random.Range(0, yCount+1);

            Tile t = FindTile(x, y);
            if (t && t.TileType != ETileType.HIGH)
            {
                t.TileType = ETileType.HIGH;
                SetSroundTiles(t.x-2, t.y-2, 5, ETileType.LOW);
                MaxResorceCount--;
            }
        }

        // Change the middle resource sround tiles
        foreach (GameObject g in AllTiles)
        {
            Tile t = g.GetComponent<Tile>();
            if(t.TileType == ETileType.HIGH)
            {
                SetSroundTiles(t.x-1, t.y-1, 3, ETileType.MID);
            }
        }
    }

    void SetSroundTiles(int PosX, int PosY, int length, ETileType type)
    {
        for (int y = PosY; y < PosY + length; y++)
        {
            for (int x = PosX; x < PosX + length; x++)
            {
                Tile t = FindTile(x, y);
                if (t && t.TileType != ETileType.HIGH)
                {
                    t.TileType = type;
                }
            }
        }
    }

    public void ShowSroundTiles(int PosX, int PosY, int length)
    {
        for (int y = PosY; y < PosY + length; y++)
        {
            for (int x = PosX; x < PosX + length; x++)
            {
                Tile t = FindTile(x, y);
                if (t) { t.ShowTile(); }
            }
        }
    }

    Tile FindTile(int x, int y)
    {
        foreach (GameObject t in AllTiles)
        {
            Tile tile = t.GetComponent<Tile>();
            if (tile.x == x && tile.y == y)
            {
                return tile;
            }
        }
        return null;
    }

    void SpawnTiles()
    {
        for (int y = 0; y < yCount; y++)
        {
            for (int x = 0; x < xCount; x++)
            {
                // Spawn the tile and set its position and Tile Manager script
                GameObject tile = Instantiate(TilePrefab, transform);
                Tile tileScript = tile.GetComponent<Tile>();
                tileScript.x = x;
                tileScript.y = y;
                tileScript.TMana = this;
                AllTiles.Add(tile);
            }
        }
    }

}
