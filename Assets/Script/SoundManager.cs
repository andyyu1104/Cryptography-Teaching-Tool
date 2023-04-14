using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        if (!PlayerPrefs.HasKey("musicVol"))
        {
            PlayerPrefs.SetFloat("musicVol", 1);
            Load();            
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }
   
    private void Load()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("musicVol");
        volumeSlider.value = PlayerPrefs.GetFloat("musicVol");
    }
   
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVol", volumeSlider.value);
    }
   

}
