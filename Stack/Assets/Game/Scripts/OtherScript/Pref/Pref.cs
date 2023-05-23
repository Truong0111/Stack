using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pref
{
    public static int CurMatId
    {
        set => PlayerPrefs.SetInt(PrefConst.CUR_MAT_ID, value);
        get => PlayerPrefs.GetInt(PrefConst.CUR_MAT_ID);
    }
    public static int Money
    {
        set => PlayerPrefs.SetInt(PrefConst.MONEY,value);
        get => PlayerPrefs.GetInt(PrefConst.MONEY);
    }
    public static int HighScore
    {
        set => PlayerPrefs.SetInt(PrefConst.HIGH_SCORE,value);
        get => PlayerPrefs.GetInt(PrefConst.HIGH_SCORE);
    }
    public static int CurMusIcId
    {
        set => PlayerPrefs.SetInt(PrefConst.CUR_MUS_ICON_ID,value);
        get => PlayerPrefs.GetInt(PrefConst.CUR_MUS_ICON_ID);
    }
    public static void SetBool(string key, bool isUnlock)
    {
        int value = isUnlock ? 1 : 0;
        PlayerPrefs.SetInt(key, value);
    }
    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }
}
