using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryManagerSingleUI : MonoBehaviour
{
    [SerializeField] private GameObject iconContainer;
    [SerializeField] private GameObject iconTemplate;
    [SerializeField] private TextMeshProUGUI recipeNameText;

    private void Awake()
    {
        iconTemplate.SetActive(false);
    }

    public void SetRecipeSO(RecipeSO recipeSO)
    {
        recipeNameText.text = recipeSO.recipeName;

        foreach (Transform child in iconContainer.transform)
        {
            if (child == iconTemplate.transform)
                continue;

            Destroy(child.gameObject);
        }

        foreach (KitchenObjectSO kitchenObjectSO in recipeSO.kitchenObjectSOList)
        {
            GameObject iconGO = Instantiate(iconTemplate, iconContainer.transform);
            iconGO.SetActive(true);
            iconGO.GetComponent<Image>().sprite = kitchenObjectSO.sprite;
        }
    }
}