using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int x;
    public int y;
    public int TileScore;
    public bool IsHidden = true;
    public Color TileColor;
    public ETileType TileType = ETileType.NONE;
    public TileManager TMana;

    // Start is called before the first frame update
    void Start()
    {

        // Initialize tiles with its type given
        switch (TileType)
        {
            case ETileType.NONE:
                TileScore = 0;
                TileColor = Color.black;
                break;
            case ETileType.LOW:
                TileScore = 100;
                TileColor = Color.green;
                break;
            case ETileType.MID:
                TileScore = 800;
                TileColor = Color.yellow;
                break;
            case ETileType.HIGH:
                TileScore = 2000;
                TileColor = Color.red;
                break;
        }

        if (!IsHidden)
            GetComponent<Image>().color = TileColor;
    }

    public void ShowTile()
    {
        IsHidden = false;
        GetComponent<Image>().color = TileColor;
    }

    public void OnTileClicked()
    {
        // Show the scan area of the tiles 3*3
        TMana.ShowSroundTiles(x - 1, y - 1, 3);
    }
}
