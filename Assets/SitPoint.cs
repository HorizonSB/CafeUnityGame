using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitPoint : MonoBehaviour
{
    [SerializeField] private Transform sitPoint;

    private Customer customer;

    public bool HasCustomer()
    {
        if (customer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SetCustomer(Customer customer)
    {
        this.customer = customer;
    }

    public void ClearCustomer()
    {
        customer = null;
    }

    public Transform GetSitPointTransform()
    {
        return sitPoint.transform;
    }
}
