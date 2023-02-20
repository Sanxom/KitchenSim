using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private GameObject counterTopPoint;

    private KitchenObject kitchenObject;

    public void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            // Give the object to the counter(place on top)
            GameObject kitchenObjectGO = Instantiate(kitchenObjectSO.prefab, counterTopPoint.transform);
            kitchenObjectGO.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            // Give the object to the player
            kitchenObject.SetKitchenObjectParent(player);
        }
    }

    public GameObject GetKitchenObjectFollowGameObject()
    {
        return counterTopPoint;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
}