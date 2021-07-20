using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settings : MonoBehaviour
{
    [Header("Music")]
    public AudioMixer audioMixer;
    public Slider musicVolumeSlider, sfxVolumeSlider;
    public float max, min;
    [Header("post-processing")]
    public GameObject postprocessing;
    public Toggle Toggle;
    private void Awake()
    {

    }
    private void Start()
    {
        if (musicVolumeSlider != null && sfxVolumeSlider != null && audioMixer != null && Toggle != null)
        {
            musicVolumeSlider.maxValue = max;
            musicVolumeSlider.minValue = min;

            sfxVolumeSlider.maxValue = max;
            sfxVolumeSlider.minValue = min;

            musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume", 0);
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0);

            audioMixer.SetFloat("Music_Volume", musicVolumeSlider.value);
            audioMixer.SetFloat("Sfx_Volume", sfxVolumeSlider.value);

            if (PlayerPrefs.GetInt("enable-PP", 1) == 1)
            {
                Toggle.isOn = true;
                postprocessing.SetActive(true);
            }
            else
            {
                Toggle.isOn = false;
                postprocessing.SetActive(false);
            }
        }
    }
    public void setMusicVolume(float Volume)
    {
        PlayerPrefs.SetFloat("musicVolume", Volume);
        audioMixer.SetFloat("Music_Volume", Volume);
        PlayerPrefs.Save();
    }
    public void setSFXVolume(float volume)
    {
        PlayerPrefs.SetFloat("sfxVolume", volume);
        audioMixer.SetFloat("Sfx_Volume", volume);
        PlayerPrefs.Save();
    }
    public void setGraphics(float volume)
    {
        return;
    }
    public void disablePostProcessing(bool toggle)
    {
        if (toggle)
        {
            PlayerPrefs.SetInt("enable-PP", 1);
        }
        else
        {
            PlayerPrefs.SetInt("enable-PP", 0);
        }
        PlayerPrefs.Save();
    }
}
