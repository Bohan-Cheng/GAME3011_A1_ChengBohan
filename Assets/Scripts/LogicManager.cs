using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManager : MonoBehaviour
{
    [SerializeField] TileManager TileMana;
    [SerializeField] GameObject Scanner;
    [SerializeField] Text ModeText;
    [SerializeField] Text ScoreText;
    [SerializeField] Text ScansText;
    [SerializeField] Text ExtractsText;
    [SerializeField] Text FinalScoreText;
    [SerializeField] GameObject GameOverMsg;
    public bool isScanMode = false;
    public int Score = 0;
    public int ScanCount = 6;
    public int ExtractCount = 3;

    void Start()
    {
        UpdateMode();
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        ScoreText.text = "Score: " + Score;
        ScansText.text = "Scans: " + ScanCount;
        ExtractsText.text = "Extracts: " + ExtractCount;
    }

    void UpdateMode()
    {
        if(isScanMode)
        {
            ModeText.text = "Mode: Scan";
        }
        else
        {
            ModeText.text = "Mode: Extract";
        }
        Scanner.SetActive(isScanMode);
    }

    public void GameOver()
    {
        GameOverMsg.SetActive(true);
        FinalScoreText.text = "Score: " + Score;
        UpdateInfo();
        TileMana.ShowAllTiles();
    }

    // UI Buttons
    public void OnRestartClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    public void OnToggleClick()
    {
        isScanMode = isScanMode ? false : true;
        UpdateMode();
    }

    public void OnAcceptClick()
    {
        GameOverMsg.SetActive(false);
    }
}
