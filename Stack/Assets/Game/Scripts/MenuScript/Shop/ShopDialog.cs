using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDialog : Dialog
{
    public Transform gridRoot;
    public ShopItemBtn itemBtnPrefb;
    public override void Show(bool isShow)
    {
        base.Show(isShow);

        UpdateUI();
    }

    private void UpdateUI()
    {
        var items = ShopManager.Ins.items;

        if (items == null || items.Length <= 0 || !gridRoot || !itemBtnPrefb) return;

        ClearChild();
        
        for(int i=0; i<items.Length; i++)
        {
            int index = i;
            var item = items[i];
            if (item != null)
            {
                var itemBtnClone = Instantiate(itemBtnPrefb,Vector3.zero,Quaternion.identity);
                itemBtnClone.transform.SetParent(gridRoot);
                itemBtnClone.transform.localPosition = Vector3.zero;
                itemBtnClone.transform.localScale = Vector3.one;
                itemBtnClone.transform.localRotation = Quaternion.identity;

                itemBtnClone.UpdateUI(item, index);
                if (itemBtnClone.GetBtn())
                {
                    itemBtnClone.GetBtn().onClick.RemoveAllListeners();
                    itemBtnClone.GetBtn().onClick.AddListener(() => ItemEvent(item, index));
                }
            } 
        }
    }

    private void ItemEvent(ShopItem item, int shopItemId)
    {
        if(item == null) return;
        bool isUnlocked = Pref.GetBool(PrefConst.MATERIAL_PREFIX + shopItemId);

        if (isUnlocked)
        {
            if (shopItemId == Pref.CurMatId) return;
            Pref.CurMatId = shopItemId;
            GameManager.Ins.ActiveMat();
            UpdateUI();
        }
        else
        {
            if(Pref.Money >= item.price)
            {
                Pref.Money -= item.price;
                Pref.SetBool(PrefConst.MATERIAL_PREFIX + shopItemId, true);
                Pref.CurMatId = shopItemId;
                GUIManager.Ins.UpdateMoney();
                GameManager.Ins.ActiveMat();
                UpdateUI();
            }
        }
    }

    public void ClearChild()
    {
        if (!gridRoot || gridRoot.childCount <= 0) return;
        for(int i = 0; i < gridRoot.childCount; i++)
        {
            var child = gridRoot.GetChild(i);

            if(child)
                Destroy(child.gameObject);
        }
    }
}
