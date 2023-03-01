using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keyMoveUpText;
    [SerializeField] private TextMeshProUGUI keyMoveLeftText;
    [SerializeField] private TextMeshProUGUI keyMoveDownText;
    [SerializeField] private TextMeshProUGUI keyMoveRightText;
    [SerializeField] private TextMeshProUGUI keyInteractText;
    [SerializeField] private TextMeshProUGUI keyInteractAltText;
    [SerializeField] private TextMeshProUGUI keyPauseText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractText;
    [SerializeField] private TextMeshProUGUI keyGamepadInteractAltText;
    [SerializeField] private TextMeshProUGUI keyGamepadPauseText;

    private void Start()
    {
        GameInput.instance.OnBindingRebind += OnBindingRebind;
        GameManager.instance.OnStateChanged += OnStateChanged;
        UpdateVisual();

        Show();
    }
    
    private void OnBindingRebind(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.instance.IsCountdownToStartActive())
            Hide();
    }

    private void UpdateVisual()
    {
        keyMoveUpText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Up);
        keyMoveLeftText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Left);
        keyMoveDownText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Down);
        keyMoveRightText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Right);
        keyInteractText.text = GameInput.instance.GetBindingText(GameInput.Binding.Interact);
        keyInteractAltText.text = GameInput.instance.GetBindingText(GameInput.Binding.Interact_Alternate);
        keyPauseText.text = GameInput.instance.GetBindingText(GameInput.Binding.Pause);
        keyGamepadInteractText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        keyGamepadInteractAltText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_Interact_Alternate);
        keyGamepadPauseText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
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