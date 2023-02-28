using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance { get; private set; }

    private const string PLAYER_PREFS_MUSIC_VOLUME = "MusicVolume";

    private AudioSource audioSource;
    private float volume = 0.2f;

    private void Awake()
    {
        instance = this;

        audioSource = GetComponent<AudioSource>();

        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_MUSIC_VOLUME, 0.2f);
        audioSource.volume = volume;
    }

    public float GetVolume()
    {
        return volume;
    }

    public void IncreaseVolume()
    {
        volume += 0.1f;
        if (volume > 1f)
            volume = 1f;

        audioSource.volume = volume;

        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, volume);
        PlayerPrefs.Save();
    }

    public void DecreaseVolume()
    {
        volume -= 0.1f;
        if(volume < 0f)
            volume = 0f;

        audioSource.volume = volume;

        PlayerPrefs.SetFloat(PLAYER_PREFS_MUSIC_VOLUME, volume);
        PlayerPrefs.Save();
    }
}