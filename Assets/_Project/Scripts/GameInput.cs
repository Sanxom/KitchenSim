using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput instance { get; private set; }

    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        instance = this;

        playerInputActions = new();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += InteractPerformed;
        playerInputActions.Player.InteractAlternate.performed += InteractAlternatePerformed;
        playerInputActions.Player.Pause.performed += PausePerformed;
    }

    private void OnDestroy()
    {
        playerInputActions.Player.Interact.performed -= InteractPerformed;
        playerInputActions.Player.InteractAlternate.performed -= InteractAlternatePerformed;
        playerInputActions.Player.Pause.performed -= PausePerformed;

        playerInputActions.Dispose();
    }

    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        return inputVector;
    }

    private void InteractPerformed(InputAction.CallbackContext context)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternatePerformed(InputAction.CallbackContext context)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void PausePerformed(InputAction.CallbackContext context)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }
}