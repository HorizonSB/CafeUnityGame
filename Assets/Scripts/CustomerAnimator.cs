using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnimator : MonoBehaviour
{
    private const string IS_SITTING = "IsSitting";

    private Animator animator;

    [SerializeField] private Customer customer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool(IS_SITTING, customer.IsSitting());
    }
}
