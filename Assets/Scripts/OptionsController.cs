using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] int defaultDifficulty = 0;

    MusicPlayer musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPreferences.GetMasterVolume();
        musicPlayer = FindObjectOfType<MusicPlayer>();
        difficultySlider.value = PlayerPreferences.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVolume();
    }

    private void UpdateVolume()
    {
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("No music player found...did you start from splash screen?");
        }
    }

    public void SaveAndExit()
    {
        PlayerPreferences.SetMasterVolume(volumeSlider.value);
        PlayerPreferences.SetDifficulty(difficultySlider.value);
        FindObjectOfType<SceneLoader>().LoadStartScreen();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
