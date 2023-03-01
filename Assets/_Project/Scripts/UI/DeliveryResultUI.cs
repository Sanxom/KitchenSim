using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{ 
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Sprite successSprite;
    [SerializeField] private Sprite failedSprite;
    [SerializeField] private Color successColor;
    [SerializeField] private Color failedColor;

    private const string POPUP = "Popup";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        DeliveryManager.instance.OnRecipeSuccess += OnRecipeSuccess;
        DeliveryManager.instance.OnRecipeFailed += OnRecipeFailed;

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        DeliveryManager.instance.OnRecipeSuccess -= OnRecipeSuccess;
        DeliveryManager.instance.OnRecipeFailed -= OnRecipeFailed;
    }

    private void OnRecipeSuccess(object sender, EventArgs e)
    {
        gameObject.SetActive(true);
        animator.SetTrigger(POPUP);
        backgroundImage.color = successColor;
        iconImage.sprite = successSprite;
        messageText.text = "DELIVERY\nSUCCESS";
    }

    private void OnRecipeFailed(object sender, EventArgs e)
    {
        gameObject.SetActive(true);
        animator.SetTrigger(POPUP);
        backgroundImage.color = failedColor;
        iconImage.sprite = failedSprite;
        messageText.text = "DELIVERY\nFAILED";
    }
}