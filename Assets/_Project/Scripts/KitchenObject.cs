using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO KitchenObjectSO { get => kitchenObjectSO; set => kitchenObjectSO = value; }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        if(this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }

        this.clearCounter = clearCounter;

        if (clearCounter.HasKitchenObject())
        {
            Debug.LogError("Counter already has a KitchenObject!");
        }

        clearCounter.SetKitchenObject(this);

        transform.parent = clearCounter.GetKitchenObjectFollowGameObject().transform;
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}