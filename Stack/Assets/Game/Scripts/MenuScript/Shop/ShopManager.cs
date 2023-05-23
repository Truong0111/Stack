using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    public ShopItem[] items;

    public override void Start()
    {
        if (items == null || items.Length <= 0) return;

        for (int i = 0; i < items.Length; i++)
        {
            var item = items[i];
            if(item != null)
            {
                if (i == 0)
                {
                    Pref.SetBool(PrefConst.MATERIAL_PREFIX + i, true);
                }
                else
                {
                    if(!PlayerPrefs.HasKey(PrefConst.MATERIAL_PREFIX + i))
                    {
                        Pref.SetBool(PrefConst.MATERIAL_PREFIX + i, false);
                    }
                }
            }
        }
    }
}

[System.Serializable]
public class ShopItem
{
    public int price;
    public Sprite hud;
    public Material mat;
}
