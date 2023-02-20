using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;

    private const string CUT = "Cut";

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        cuttingCounter.OnCut += OnCut;
    }

    private void OnApplicationQuit()
    {
        cuttingCounter.OnCut -= OnCut;
    }

    private void OnCut(object sender, EventArgs e)
    {
        animator.SetTrigger(CUT);
    }
}