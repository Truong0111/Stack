using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : Singleton<GUIManager>
{
    [SerializeField] private TextMeshProUGUI moneyText;
    public override void Awake()
    {
        MakeSingleton(true);
    }
    private void Update()
    {
        UpdateUI();
    }
    private void UpdateUI()
    {
        if (SceneManager.GetActiveScene().name == "MenuScene")
        {
            moneyText = GameObject.Find("MoneyText").GetComponent<TextMeshProUGUI>();
            UpdateMoney();
        }
    }
    public void UpdateMoney()
    {
        if (moneyText)
            moneyText.text = Pref.Money + "";
    }
}
