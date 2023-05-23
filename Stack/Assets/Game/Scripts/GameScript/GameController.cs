using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private StackController stc;
    [SerializeField] private UIController ui;
    private int Score;
    private int HighScore;
    private int Combo;
    private bool IsGameOver;
    private bool IsGameStart;
    private String MENU_SCENE = "MenuScene";
    private void Start()
    {
        Application.targetFrameRate = 120;
    }
    private void OnEnable()
    {
        StartGame();
        stc.StartGame();
    }
    private void Update()
    {
        if(IsGameOver)
        {
            GameOver();
            ui.ShowGameOverPanel(true);
        }
    }
    private void StartGame()
    {
        Score = 0;
        Combo = 0;
        HighScore = PlayerPrefs.GetInt(PrefConst.HIGH_SCORE);
        IsGameOver = false;
        IsGameStart = true;
        ui.ShowGameOverPanel(false);
    }
    private void GameOver()
    {
        stc.GameOver();
        if(Score > HighScore)
        {
            PlayerPrefs.SetInt(PrefConst.HIGH_SCORE, Score);
        }
        ui.SetHighScoreText(Score);
        ui.ShowGameOverPanel(true);
    }
    
    public void ScoreIncreament()
    {
        Score++;
    }
    public void ComboIncreament()
    {
        Combo++;
        Pref.Money++;
    }
    
    public int GetScore()
    {
        return Score;
    }
    public void SetScore(int score)
    {
        Score = score;
    }
    public int GetCombo()
    {
        return Combo;
    }
    public void SetCombo(int combo)
    {
        Combo = combo;
    }
    public bool GetGameOver()
    {
        return IsGameOver;
    }
    public void SetGameOver(bool gameOver)
    {
        IsGameOver = gameOver;
    }
    public bool GetGameStart()
    {
        return IsGameStart;
    }
    public void SetGameStart(bool gameStart)
    {
        IsGameStart = gameStart;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(MENU_SCENE);
    }
}
