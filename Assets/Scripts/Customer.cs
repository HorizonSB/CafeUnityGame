using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : MonoBehaviour
{
    [SerializeField] private Transform leavePoint;

    private NavMeshAgent agent;

    private const string SIT_POINT_TAG = "SitPoint";

    private RecipeSO waitingRecipeSO;
    private SitPoint sitPoint;

    private bool isSitting = false;
    private bool madeOrder = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (HasFreePlace())
        {
            sitPoint.SetCustomer(this);
            agent.SetDestination(sitPoint.transform.position);
        }
        else
        {
            Leave();
        }
    }

    private void Update()
    {
        if (ReachPlace())
        {
            SetCustomerVisualToSeat();
            if (!madeOrder)
            {
                madeOrder = true;
                waitingRecipeSO = DeliveryManager.Instance.CreateOrder();
            }
        }
    }

    private bool HasFreePlace()
    {
        GameObject[] sitPoints = GameObject.FindGameObjectsWithTag(SIT_POINT_TAG);
        foreach(GameObject sitPoint in sitPoints)
        {
            if (!sitPoint.GetComponent<SitPoint>().HasCustomer())
            {
                this.sitPoint = sitPoint.GetComponent<SitPoint>();
                return true;
            }
        }
        return false;
    }

    private void Leave()
    {
        agent.SetDestination(leavePoint.position);
    }

    private bool ReachPlace()
    {
        if (sitPoint)
        {
            float distanceToSitPoint = Vector3.Distance(this.transform.position, sitPoint.transform.position);
            float distanceToSit = 1f;

            if (distanceToSitPoint <= distanceToSit)
            {
                isSitting = true;
                return true;
            }
        }
        return false;
    }

    public bool IsSitting()
    {
        return isSitting;
    }

    public void SetCustomerVisualToSeat()
    {
        Vector3 sitPointTransformPosition = new Vector3(sitPoint.transform.position.x, transform.position.y, sitPoint.transform.position.z);
        gameObject.transform.position = sitPoint.GetSitPointTransform().position;
        gameObject.transform.rotation = sitPoint.GetSitPointTransform().rotation;
    }
}
