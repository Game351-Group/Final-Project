using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    // This script is for adjusting in-game sounds
    [SerializeField]
    private Slider volumeSlider;
    private List<AudioSource> allAudioSources;

    void Start()
    {
        allAudioSources = new List<AudioSource>(FindObjectsOfType<AudioSource>());

        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = savedVolume;
            AdjustVolume(savedVolume);
        }
        volumeSlider.onValueChanged.AddListener(AdjustVolume);
    }

    public void AdjustVolume(float newVolume)
    {
        foreach (AudioSource audioSource in allAudioSources)
        {
            audioSource.volume = newVolume;
        }
        PlayerPrefs.SetFloat("Volume", newVolume);
    }
}

