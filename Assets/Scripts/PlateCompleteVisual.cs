using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectsSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectsSO_GameObject> kitchenObjectsSOGameObjectList;


    private void Start()
    {
        plateKitchenObject.OnIngridientAdded += PlateKitchenObject_OnIngridientAdded;

        foreach (KitchenObjectsSO_GameObject kitchenObjectsSOGameObject in kitchenObjectsSOGameObjectList)
        {
            kitchenObjectsSOGameObject.gameObject.SetActive(false);
        }
    }

    private void PlateKitchenObject_OnIngridientAdded(object sender, PlateKitchenObject.OnIngridientAddedEventArgs e)
    {
        foreach ( KitchenObjectsSO_GameObject kitchenObjectsSOGameObject in kitchenObjectsSOGameObjectList)
        {
            if(kitchenObjectsSOGameObject.kitchenObjectSO == e.kitchenObjectSO)
            {
                kitchenObjectsSOGameObject.gameObject.SetActive(true);
            }
        }
    }
}
