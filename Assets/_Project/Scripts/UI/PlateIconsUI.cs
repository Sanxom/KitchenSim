using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateIconsUI : MonoBehaviour
{
    [SerializeField] private GameObject iconTemplate;
    [SerializeField] private PlateKitchenObject plateKitchenObject;

    private void Awake()
    {
        iconTemplate.SetActive(false);
    }

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += OnIngredientAdded;
    }

    private void OnApplicationQuit()
    {
        plateKitchenObject.OnIngredientAdded -= OnIngredientAdded;
    }

    private void OnIngredientAdded(object sender, PlateKitchenObject.OnIngredientAddedEventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in transform)
        {
            if (child == iconTemplate.transform)
                continue;

            Destroy(child.gameObject);
        }

        foreach (KitchenObjectSO kitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
        {
            GameObject iconGO = Instantiate(iconTemplate, transform);
            iconGO.SetActive(true);
            iconGO.GetComponent<PlateIconSingleUI>().SetKitchenObjectSO(kitchenObjectSO);
        }
    }
}