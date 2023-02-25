using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;

    private void Start()
    {
        GameManager.instance.OnStateChanged += OnStateChanged;
        Hide();
    }

    private void Update()
    {
        countdownText.text = GameManager.instance.GetCountdownToStartTimer().ToString("#");
    }

    private void OnApplicationQuit()
    {
        GameManager.instance.OnStateChanged -= OnStateChanged;
    }

    private void OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.instance.IsCountdownToStartActive())
        {
            Show();
        }
        else
            Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}