using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject counterTopPoint;
    [SerializeField] private GameObject plateVisualPrefab;
    [SerializeField] private PlatesCounter platesCounter;

    private List<GameObject> plateVisualGameObjectList;

    private void Awake()
    {
        plateVisualGameObjectList = new List<GameObject>();
    }

    private void Start()
    {
        platesCounter.OnPlateSpawned += OnPlateSpawned;
        platesCounter.OnPlateRemoved += OnPlateRemoved;
    }

    private void OnPlateSpawned(object sender, EventArgs e)
    {
        GameObject plateVisualGO = Instantiate(plateVisualPrefab, counterTopPoint.transform);

        float plateOffsetY = 0.1f;
        plateVisualGO.transform.localPosition = new Vector3(0, plateOffsetY * plateVisualGameObjectList.Count, 0);
        plateVisualGameObjectList.Add(plateVisualGO);
    }

    private void OnPlateRemoved(object sender, EventArgs e)
    {
        GameObject plateGO = plateVisualGameObjectList[plateVisualGameObjectList.Count - 1];
        plateVisualGameObjectList.Remove(plateGO);
        Destroy(plateGO);
    }
}