using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioItem[] items;

    private void Start()
    {
        if (items == null || items.Length <=0) return;
        for (int i = 0; i < items.Length; i++)
        {
            var item = items[i];
            if (item != null)
            {
                Pref.SetBool(PrefConst.MUSIC_AUDIO + i, true);
            }
        }
    }
}
[System.Serializable]
public class AudioItem
{
    public AudioClip clip;
}