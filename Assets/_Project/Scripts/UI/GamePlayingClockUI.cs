using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayingClockUI : MonoBehaviour
{
    [SerializeField] private Image timerImage;

    private void Start()
    {
        timerImage.fillAmount = 1;
    }

    private void Update()
    {
        if(GameManager.instance.IsGamePlaying())
            timerImage.fillAmount = GameManager.instance.GetGamePlayingTimerNormalized();
    }
}