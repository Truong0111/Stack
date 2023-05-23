using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject stack;
    [SerializeField] private ShopItemBtn shopItemBtn;
    private List<Material> mat = new List<Material>();
    
    public override void Awake()
    {
        MakeSingleton(false);
    }
    
    public override void Start()
    {
        base.Start();

        if(!PlayerPrefs.HasKey(PrefConst.MONEY))
            Pref.Money = 0;
        ActiveMat();
        GUIManager.Ins.UpdateMoney();

        if(!PlayerPrefs.HasKey(PrefConst.HIGH_SCORE))
            Pref.HighScore = 0;
    }
    
    public void ActiveMat()
    {
        if (mat != null)
            mat.Clear();

        var newMat = ShopManager.Ins.items[Pref.CurMatId].mat;
        if (newMat != null)
        {
            mat.Add(newMat);
        }
        stack.GetComponent<MeshRenderer>().materials = mat.ToArray();
        
    }
}
