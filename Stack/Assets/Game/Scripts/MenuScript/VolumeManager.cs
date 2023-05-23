using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    
    [SerializeField] private Image currentImage;
    [SerializeField] private Sprite VolumeOn;
    [SerializeField] private Sprite VolumeOff;
    
    private void Start()
    {
        StartVolume();
    }
    public void StartVolume()
    {
        if (!PlayerPrefs.HasKey(PrefConst.CUR_MUS_ICON_ID))
        {
            PlayerPrefs.SetInt(PrefConst.CUR_MUS_ICON_ID, 1);
            currentImage.sprite = VolumeOn;
            VolumeController.Ins.SetVolumeOn();
        }
        else
        {
            if (PlayerPrefs.GetInt(PrefConst.CUR_MUS_ICON_ID) == 1)
                currentImage.sprite = VolumeOn;
            else currentImage.sprite = VolumeOff;
        }
    }
    public void VolumeChange()
    {
        if(PlayerPrefs.GetInt(PrefConst.CUR_MUS_ICON_ID) == 1)
        {
            currentImage.sprite = VolumeOff;
            PlayerPrefs.SetInt(PrefConst.CUR_MUS_ICON_ID, 0);
            VolumeController.Ins.SetVolumeOff();
        }
        else
        {
            currentImage.sprite = VolumeOn;
            PlayerPrefs.SetInt(PrefConst.CUR_MUS_ICON_ID, 1);
            VolumeController.Ins.SetVolumeOn();
        }
    }
}
