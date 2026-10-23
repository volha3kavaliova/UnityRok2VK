using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public UnityEngine.UI.Slider musicSlider;
    public UnityEngine.UI.Slider sfxSlider;
    public AudioMixer mainMixer;


    public void SetMusicVolume ()
    {
        float volume = musicSlider.value;
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }
    
    public void SetSFXVolume ()
    {
        float volume = sfxSlider.value;
        mainMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }
}
