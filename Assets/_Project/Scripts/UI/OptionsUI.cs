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

    [SerializeField] private GameObject pressToRebindKeyGO;

    [Header("Option Buttons")]
    [SerializeField] private Button soundEffectPlusButton;
    [SerializeField] private Button soundEffectMinusButton;
    [SerializeField] private Button musicPlusButton;
    [SerializeField] private Button musicMinusButton;
    [SerializeField] private Button closeButton;

    [Header("Keyboard Keybinds")]
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [SerializeField] private Button pauseButton;

    [Header("Gamepad Keybinds")]
    [SerializeField] private Button gamepadInteractButton;
    [SerializeField] private Button gamepadInteractAlternateButton;
    [SerializeField] private Button gamepadPauseButton;

    [Header("Sound Text")]
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;

    [Header("Keyboard Keybind Text")]
    [SerializeField] private TextMeshProUGUI moveUpButtonText;
    [SerializeField] private TextMeshProUGUI moveDownButtonText;
    [SerializeField] private TextMeshProUGUI moveLeftButtonText;
    [SerializeField] private TextMeshProUGUI moveRightButtonText;
    [SerializeField] private TextMeshProUGUI interactButtonText;
    [SerializeField] private TextMeshProUGUI interactAlternateButtonText;
    [SerializeField] private TextMeshProUGUI pauseButtonText;

    [Header("Gamepad Keybind Text")]
    [SerializeField] private TextMeshProUGUI gamepadInteractButtonText;
    [SerializeField] private TextMeshProUGUI gamepadInteractAlternateButtonText;
    [SerializeField] private TextMeshProUGUI gamepadPauseButtonText;

    private Action onCloseButtonAction;

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
            onCloseButtonAction();
        });

        moveUpButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Up);
        });

        moveDownButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Down);
        });

        moveLeftButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Left);
        });

        moveRightButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Move_Right);
        });

        interactButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Interact);
        });

        interactAlternateButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Interact_Alternate);
        });

        gamepadInteractButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Gamepad_Interact);
        });

        gamepadInteractAlternateButton.onClick.AddListener(() =>
        {
            RebindBinding(GameInput.Binding.Gamepad_Interact_Alternate);
        });
    }

    private void Start()
    {
        GameManager.instance.OnGameUnpaused += OnGameUnpaused;
        UpdateVisual();

        HidePressToRebindKey();
        Hide();
    }

    private void OnDestroy()
    {
        GameManager.instance.OnGameUnpaused -= OnGameUnpaused;
    }

    public void Show(Action onCloseButtonAction)
    {
        this.onCloseButtonAction = onCloseButtonAction;
        gameObject.SetActive(true);

        soundEffectMinusButton.Select();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void RebindBinding(GameInput.Binding binding)
    {
        ShowPressToRebindKey();
        GameInput.instance.RebindBinding(binding, () => 
        {
            HidePressToRebindKey();
            UpdateVisual();
        });
    }

    private void OnGameUnpaused(object sender, EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEffectsText.text = "Sound Effects: " +  Mathf.Round(SoundManager.instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.instance.GetVolume() * 10f);

        moveUpButtonText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Up);
        moveDownButtonText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Down);
        moveLeftButtonText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightButtonText.text = GameInput.instance.GetBindingText(GameInput.Binding.Move_Right);

        interactButtonText.text = GameInput.instance.GetBindingText(GameInput.Binding.Interact);
        interactAlternateButtonText.text = GameInput.instance.GetBindingText(GameInput.Binding.Interact_Alternate);
        pauseButtonText.text = GameInput.instance.GetBindingText(GameInput.Binding.Pause);

        gamepadInteractButtonText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        gamepadInteractAlternateButtonText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_Interact_Alternate);
        gamepadPauseButtonText.text = GameInput.instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
    }

    private void ShowPressToRebindKey()
    {
        pressToRebindKeyGO.SetActive(true);
    }

    private void HidePressToRebindKey()
    {
        pressToRebindKeyGO.SetActive(false);
    }
}