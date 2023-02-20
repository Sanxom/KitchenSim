using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent
{
    public GameObject GetKitchenObjectFollowGameObject();

    public KitchenObject GetKitchenObject();

    public bool HasKitchenObject();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public void ClearKitchenObject();
}