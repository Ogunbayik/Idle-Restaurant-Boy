using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerAnimationController : MonoBehaviour
{
    private const string WALK_PARAMETER = "isWalk";
    private const string SIT_PARAMETER = "isSit";

    private CustomerMovement customer;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        customer = GetComponentInParent<CustomerMovement>();
    }

    private void Update()
    {
        var isWalking = customer.GetIsWalk();
        var isSit = customer.GetIsSit();

        if (isWalking)
            WalkAnimation(true);
        else
            WalkAnimation(false);

        if (isSit)
            SitIdleAnimation(true);
        else
            SitIdleAnimation(false);
    }

    public void WalkAnimation(bool isWalk)
    {
        animator.SetBool(WALK_PARAMETER, isWalk);
    }
    public void SitIdleAnimation(bool isSit)
    {
        animator.SetBool(SIT_PARAMETER, isSit);
    }
}
