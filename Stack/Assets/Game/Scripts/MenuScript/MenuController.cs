using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject SettingPanel;
    [SerializeField] private GameObject ShopPanel;
    [SerializeField] private GameObject StartPanel;
    [SerializeField] private GameObject Stack;
    private String GAME_SCENE = "GameScene";
    public void OpenSettingPanel()
    {
        SettingPanel.SetActive(true);
        StartPanel.SetActive(false);
        Stack.SetActive(false);
    }
    public void CloseSettingPanel()
    {
        SettingPanel.SetActive(false);
        StartPanel.SetActive(true);
        Stack.SetActive(true);
    }
    public void OpenShopPanel()
    {
        StartPanel.SetActive(false);
        Stack.SetActive(false);
    }
    public void CloseShopPanel()
    {
        StartPanel.SetActive(true);
        Stack.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }
}
