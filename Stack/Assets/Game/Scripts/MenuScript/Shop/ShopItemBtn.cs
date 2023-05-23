using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemBtn : MonoBehaviour
{
    [SerializeField] private Text priceText;
    [SerializeField] private Image hud;
    [SerializeField] private Button btn;

    public void UpdateUI(ShopItem item, int shopItemId)
    {
        if(item == null) return;
        if (hud)
            hud.sprite = item.hud;

        bool isUnlocked = Pref.GetBool(PrefConst.MATERIAL_PREFIX + shopItemId);

        if (isUnlocked)
        {
            if(shopItemId == Pref.CurMatId) 
            {
                if (priceText)
                    priceText.text = "Active";
                
            }
            else
            {
                if (priceText)
                    priceText.text = "Owned";
            }
        }
        else
        {
            if (priceText)
                priceText.text = item.price.ToString();
        }
    }

    public Button GetBtn() { return btn; }

}
