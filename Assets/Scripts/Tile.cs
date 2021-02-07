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
    TileManager TileMana;
    LogicManager LogicMana;

    // Start is called before the first frame update
    void Start()
    {
        InitTile();
        if (!IsHidden)
            GetComponent<Image>().color = TileColor;
    }

    void InitTile()
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
    }

    public void SetManagers(TileManager tm, LogicManager lm)
    {
        TileMana = tm;
        LogicMana = lm;
    }

    public void ShowTile()
    {
        IsHidden = false;
        GetComponent<Image>().color = TileColor;
    }

    public void OnTileClicked()
    {
        // Show the scan area of the tiles 3*3
        if(LogicMana.isScanMode && LogicMana.ScanCount > 0)
        {
            TileMana.ShowSroundTiles(x - 1, y - 1, 3);
            LogicMana.ScanCount--;
        }
        // To extract one tile and show the tile
        else if(!LogicMana.isScanMode && LogicMana.ExtractCount > 0)
        {
            ShowTile();
            LogicMana.ExtractCount--;
            LogicMana.Score += TileScore;
            if (TileType > 0)
            {
                TileType -= 1;
                InitTile();
                ShowTile();
            }
        }

        // Check if game should end
        if(LogicMana.ExtractCount <= 0)
        {
            LogicMana.GameOver();
            LogicMana.ScanCount = 0;
        }
        LogicMana.UpdateInfo();
    }
}
