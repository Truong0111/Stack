using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : Singleton<VolumeController> 
{
    
    [SerializeField] AudioSource audSource;
    [SerializeField] AudioClip StackCombo;
    [SerializeField] AudioClip StackDrop;
    [SerializeField] AudioClip GameOver;
    
    public override void Start()
    {
        LoadVolume();
    }
    private void Update()
    {
        if(audSource == null)
        {
            audSource = GameObject.FindObjectOfType<AudioSource>();
        }
    }
    public void StackComboEfx()
    {
        audSource.PlayOneShot(StackCombo);
    }
    public void StackDropEfx()
    {
        audSource.PlayOneShot(StackDrop);
    }
    public void GameOverEfx()
    {
        audSource.PlayOneShot(GameOver);
    }
    public void SetVolumeOff()
    {
        PlayerPrefs.SetFloat("MusicVolume", 0);
        LoadVolume();
    }
    public void SetVolumeOn()
    {
        PlayerPrefs.SetFloat("MusicVolume", 0.5f);
        LoadVolume();
    }
    public void LoadVolume()
    {
        float volumeValue = PlayerPrefs.GetFloat("MusicVolume");
        AudioListener.volume = volumeValue;
    }
}
