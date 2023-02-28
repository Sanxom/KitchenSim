using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button mainMenuButton;

    private void Awake()
    {
        resumeButton.onClick.AddListener(() =>
        {
            GameManager.instance.TogglePauseGame();
        });

        optionsButton.onClick.AddListener(() =>
        {
            OptionsUI.instance.Show();
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenu);
        });
    }

    private void Start()
    {
        GameManager.instance.OnGamePaused += OnGamePaused;
        GameManager.instance.OnGameUnpaused += OnGameUnpaused;

        Hide();
    }

    private void OnApplicationQuit()
    {
        GameManager.instance.OnGamePaused -= OnGamePaused;
        GameManager.instance.OnGameUnpaused -= OnGameUnpaused;
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnGamePaused(object sender, EventArgs e)
    {
        Show();
    }

    private void OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }
}