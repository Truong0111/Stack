using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameController gc;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI HighScoreText;
    private void Update()
    {
        SetScoreText(gc.GetScore());
    }
    public void SetScoreText(int score)
    {
        ScoreText.text = score + "";
    }
    public void SetHighScoreText(int highScore)
    {
        HighScoreText.text = highScore + "";
    }
    public void ShowGameOverPanel(bool isShow)
    {
        GameOverPanel.SetActive(isShow);
    }
}
