using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    public static OptionsUI instance { get; private set; }

    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button soundEffectPlusButton;
    [SerializeField] private Button soundEffectMinusButton;
    [SerializeField] private Button musicPlusButton;
    [SerializeField] private Button musicMinusButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;

    private void Awake()
    {
        instance = this;

        soundEffectPlusButton.onClick.AddListener(() =>
        {
            SoundManager.instance.IncreaseVolume();
            UpdateVisual();
        });

        soundEffectMinusButton.onClick.AddListener(() =>
        {
            SoundManager.instance.DecreaseVolume();
            UpdateVisual();
        });

        musicPlusButton.onClick.AddListener(() =>
        {
            MusicManager.instance.IncreaseVolume();
            UpdateVisual();
        });

        musicMinusButton.onClick.AddListener(() =>
        {
            MusicManager.instance.DecreaseVolume();
            UpdateVisual();
        });

        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    private void Start()
    {
        GameManager.instance.OnGameUnpaused += OnGameUnpaused;
        UpdateVisual();

        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectsText.text = "Sound Effects: " +  Mathf.Round(SoundManager.instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.instance.GetVolume() * 10f);
    }
}