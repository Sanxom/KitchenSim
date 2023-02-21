using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectSO_GameObjectList;
    [SerializeField] private PlateKitchenObject plateKitchenObject;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += OnIngredientAdded;

        foreach (KitchenObjectSO_GameObject kitchenObjectSOGameObject in kitchenObjectSO_GameObjectList)
        {
            kitchenObjectSOGameObject.gameObject.SetActive(false);
        }
    }

    private void OnApplicationQuit()
    {
        plateKitchenObject.OnIngredientAdded -= OnIngredientAdded;
    }

    private void OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        foreach (KitchenObjectSO_GameObject kitchenObjectSOGameObject in kitchenObjectSO_GameObjectList)
        {
            if (kitchenObjectSOGameObject.kitchenObjectSO == e.kitchenObjectSO)
            {
                kitchenObjectSOGameObject.gameObject.SetActive(true);
            }
        }
    }
}