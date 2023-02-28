using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private const string PLAYER_PREFS_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";

    private float volume = 0.3f;

    private void Awake()
    {
        instance = this;

        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, 0.3f);
    }

    private void Start()
    {
        DeliveryManager.instance.OnRecipeSuccess += OnRecipeSuccess;
        DeliveryManager.instance.OnRecipeFailed += OnRecipeFailed;
        CuttingCounter.OnAnyCut += OnAnyCut;
        Player.Instance.OnPickedUpSomething += OnPickedUpSomething;
        BaseCounter.OnAnyObjectPlacedHere += OnAnyObjectPlacedHere;
        TrashCounter.OnAnyObjectTrashed += OnAnyObjectTrashed;
    }

    private void OnApplicationQuit()
    {
        DeliveryManager.instance.OnRecipeSuccess -= OnRecipeSuccess;
        DeliveryManager.instance.OnRecipeFailed -= OnRecipeFailed;
        CuttingCounter.OnAnyCut -= OnAnyCut;
        Player.Instance.OnPickedUpSomething -= OnPickedUpSomething;
        BaseCounter.OnAnyObjectPlacedHere -= OnAnyObjectPlacedHere;
        TrashCounter.OnAnyObjectTrashed -= OnAnyObjectTrashed;
    }

    public float GetVolume()
    {
        return volume;
    }

    public void PlayFootstepSound(Vector3 position)
    {
        PlaySound(audioClipRefsSO.footstepSounds, position);
    }

    public void IncreaseVolume()
    {
        volume += 0.1f;
        if(volume > 1f) 
            volume = 1f;

        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, volume);
        PlayerPrefs.Save();
    }

    public void DecreaseVolume()
    {
        volume -= 0.1f;
        if (volume < 0f)
            volume = 0f;

        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, volume);
        PlayerPrefs.Save();
    }

    private void PlaySound(AudioClip audioClip, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volumeMultiplier * volume);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClipArray[UnityEngine.Random.Range(0, audioClipArray.Length)], position, volume);
    }

    private void OnRecipeSuccess(object sender, EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.instance;
        PlaySound(audioClipRefsSO.deliverySuccessSounds, deliveryCounter.transform.position);
    }

    private void OnRecipeFailed(object sender, EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.instance;
        PlaySound(audioClipRefsSO.deliveryFailSounds, deliveryCounter.transform.position);
    }

    private void OnAnyCut(object sender, EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(audioClipRefsSO.chopSounds, cuttingCounter.transform.position);
    }

    private void OnPickedUpSomething(object sender, EventArgs e)
    {
        PlaySound(audioClipRefsSO.objectPickupSounds, Player.Instance.transform.position);
    }

    private void OnAnyObjectPlacedHere(object sender, EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(audioClipRefsSO.objectDropSounds, baseCounter.transform.position);
    }

    private void OnAnyObjectTrashed(object sender, EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        PlaySound(audioClipRefsSO.objectDropSounds, trashCounter.transform.position);
    }
}