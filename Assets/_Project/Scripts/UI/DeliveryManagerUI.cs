using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private GameObject recipeTemplate;

    private void Awake()
    {
        recipeTemplate.SetActive(false);
    }

    private void Start()
    {
        DeliveryManager.instance.OnRecipeSpawned += OnRecipeSpawned;
        DeliveryManager.instance.OnRecipeCompleted += OnRecipeCompleted;

        UpdateVisual();
    }

    private void OnApplicationQuit()
    {
        DeliveryManager.instance.OnRecipeSpawned -= OnRecipeSpawned;
        DeliveryManager.instance.OnRecipeCompleted -= OnRecipeCompleted;
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container.transform)
        {
            if (child == recipeTemplate.transform)
                continue;

            Destroy(child.gameObject);
        }

        foreach( RecipeSO recipeSO in DeliveryManager.instance.GetWaitingRecipeSOList())
        {
            GameObject recipeGO = Instantiate(recipeTemplate, container.transform);
            recipeGO.SetActive(true);
            recipeGO.GetComponent<DeliveryManagerSingleUI>().SetRecipeSO(recipeSO);
        }
    }

    private void OnRecipeSpawned(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void OnRecipeCompleted(object sender, EventArgs e)
    {
        UpdateVisual();
    }
}