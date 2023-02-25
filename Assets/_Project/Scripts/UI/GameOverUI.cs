using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ordersCompletedText;

    private void Start()
    {
        GameManager.instance.OnStateChanged += OnStateChanged;
        Hide();
    }

    private void OnApplicationQuit()
    {
        GameManager.instance.OnStateChanged -= OnStateChanged;
    }

    private void OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.instance.IsGameOver())
        {
            Show();
            ordersCompletedText.text = DeliveryManager.instance.GetSuccessfulRecipesAmount().ToString();
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