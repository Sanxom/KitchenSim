using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;

    private const string NUMBER_POPUP = "NumberPopup";

    private Animator animator;
    private int previousCountdownNumber;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        GameManager.instance.OnStateChanged += OnStateChanged;
        Hide();
    }

    private void Update()
    {
        int countdownNumber = Mathf.CeilToInt(GameManager.instance.GetCountdownToStartTimer());
        countdownText.text = countdownNumber.ToString();

        if(previousCountdownNumber != countdownNumber)
        {
            previousCountdownNumber = countdownNumber;
            animator.SetTrigger(NUMBER_POPUP);
            SoundManager.instance.PlayCountdownSound();
        }
    }

    private void OnDestroy()
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