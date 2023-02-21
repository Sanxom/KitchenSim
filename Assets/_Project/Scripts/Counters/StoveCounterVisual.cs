using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject stoveOnGO;
    [SerializeField] private GameObject particlesGO;
    [SerializeField] private StoveCounter stoveCounter;

    private void Start()
    {
        stoveCounter.OnStateChanged += OnStateChanged;
    }

    private void OnApplicationQuit()
    {
        stoveCounter.OnStateChanged -= OnStateChanged;
    }

    private void OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        stoveOnGO.SetActive(showVisual);
        particlesGO.SetActive(showVisual);
    }
}